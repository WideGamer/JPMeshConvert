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

using System.Windows.Forms;

namespace JPAssetReader {
    public class OpenResourceDialog {
        private OpenFileDialog _dialog = null;

        public string FileName { get; private set; }

        public OpenResourceDialog(string initialDirectory, string title, string filter) {
            FileName = "";
            _dialog = new OpenFileDialog();
            _dialog.InitialDirectory = initialDirectory;
            _dialog.Title = title;//"Open JP Texture directory";
            _dialog.Filter = filter;//"JP Textures|*.dds|All files (*.*)|*.*";
            _dialog.FilterIndex = 0;
            _dialog.RestoreDirectory = true;
        }

        public bool Open() {
            // Only return true when the user opens a file
            if (_dialog.ShowDialog() == DialogResult.OK) {
                FileName = _dialog.FileName;
                return true;
            }

            return false;
        }
    }
}
