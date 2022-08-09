/*
 * MIT License
 * 
 * Copyright (c) 2022 Aptivi
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.Text.RegularExpressions;

namespace VT.NET
{
    public static class Filters
    {
        /// <summary>
        /// Filters all of the VT sequences
        /// </summary>
        /// <param name="Text">The text that contains the VT sequences</param>
        /// <param name="replace">Replace the sequences with this text</param>
        /// <returns>The text that doesn't contain the VT sequences</returns>
        public static string FilterVTSequences(string Text, string replace = "")
        {
            // Filter all sequences
            Text = Regex.Replace(Text, RegexVTExpressions.AllVTSequences, replace);
            return Text;
        }
        
        /// <summary>
        /// Filters all of the CSI sequences
        /// </summary>
        /// <param name="Text">The text that contains the CSI sequences</param>
        /// <param name="replace">Replace the sequences with this text</param>
        /// <returns>The text that doesn't contain the CSI sequences</returns>
        public static string FilterCSISequences(string Text, string replace = "")
        {
            // Filter CSI sequences
            Text = Regex.Replace(Text, RegexVTExpressions.CSISequences, replace);
            return Text;
        }
        
        /// <summary>
        /// Filters all of the OSC sequences
        /// </summary>
        /// <param name="Text">The text that contains the OSC sequences</param>
        /// <param name="replace">Replace the sequences with this text</param>
        /// <returns>The text that doesn't contain the OSC sequences</returns>
        public static string FilterOSCSequences(string Text, string replace = "")
        {
            // Filter OSC sequences
            Text = Regex.Replace(Text, RegexVTExpressions.OSCSequences, replace);
            return Text;
        }
        
        /// <summary>
        /// Filters all of the ESC sequences
        /// </summary>
        /// <param name="Text">The text that contains the ESC sequences</param>
        /// <param name="replace">Replace the sequences with this text</param>
        /// <returns>The text that doesn't contain the ESC sequences</returns>
        public static string FilterESCSequences(string Text, string replace = "")
        {
            // Filter ESC sequences
            Text = Regex.Replace(Text, RegexVTExpressions.ESCSequences, replace);
            return Text;
        }
        
        /// <summary>
        /// Filters all of the APC sequences
        /// </summary>
        /// <param name="Text">The text that contains the APC sequences</param>
        /// <param name="replace">Replace the sequences with this text</param>
        /// <returns>The text that doesn't contain the APC sequences</returns>
        public static string FilterAPCSequences(string Text, string replace = "")
        {
            // Filter APC sequences
            Text = Regex.Replace(Text, RegexVTExpressions.APCSequences, replace);
            return Text;
        }
        
        /// <summary>
        /// Filters all of the DCS sequences
        /// </summary>
        /// <param name="Text">The text that contains the DCS sequences</param>
        /// <param name="replace">Replace the sequences with this text</param>
        /// <returns>The text that doesn't contain the DCS sequences</returns>
        public static string FilterDCSSequences(string Text, string replace = "")
        {
            // Filter DCS sequences
            Text = Regex.Replace(Text, RegexVTExpressions.DCSSequences, replace);
            return Text;
        }
        
        /// <summary>
        /// Filters all of the PM sequences
        /// </summary>
        /// <param name="Text">The text that contains the PM sequences</param>
        /// <param name="replace">Replace the sequences with this text</param>
        /// <returns>The text that doesn't contain the PM sequences</returns>
        public static string FilterPMSequences(string Text, string replace = "")
        {
            // Filter PM sequences
            Text = Regex.Replace(Text, RegexVTExpressions.PMSequences, replace);
            return Text;
        }
        
        /// <summary>
        /// Filters all of the C1 sequences
        /// </summary>
        /// <param name="Text">The text that contains the C1 sequences</param>
        /// <param name="replace">Replace the sequences with this text</param>
        /// <returns>The text that doesn't contain the C1 sequences</returns>
        public static string FilterC1Sequences(string Text, string replace = "")
        {
            // Filter C1 sequences
            Text = Regex.Replace(Text, RegexVTExpressions.C1Sequences, replace);
            return Text;
        }
    }
}
