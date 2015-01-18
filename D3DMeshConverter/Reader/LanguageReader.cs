﻿/*
 * Copyright (c) 2015 Stefan Wijnker
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
 * IN THE SOFTWARE.
*/

using System.Collections.Generic;
using System.IO;

namespace JPAssetReader {
    public struct LanguageEntry {
        public string Name;
        public string Text;
    }

    public class LanguageReader : BaseReader {
        public List<LanguageEntry> entries;

        public override bool Read(uint subType, FileStream stream) {
            base.Read(subType, stream);

            entries = new List<LanguageEntry>();
            byte[] header = ReadChunk(0x4C);
            
            uint entryCount = ReadUint32();
            for (int i = 0; i < entryCount; i++) {
                entries.Add(ReadLanguageString());
            }

            byte[] footer = ReadChunk(0x24);
            uint unknown = ReadUint32(footer,0x4);
            
            return true;
        }

        private LanguageEntry ReadLanguageString() {
            string name = ReadString();
            string content = ReadString();
            uint u1 = ReadUint32();
            uint u2 = ReadUint32();
            return new LanguageEntry() { Name = name, Text = content };
        }
    }
}
