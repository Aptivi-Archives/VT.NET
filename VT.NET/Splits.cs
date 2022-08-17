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

using System.Text.RegularExpressions;

namespace VT.NET
{
    public static class Splits 
    {
        /// <summary>
        /// Splits all of the VT sequences
        /// </summary>
        /// <param name="Text">The text that contains the VT sequences</param>
        /// <returns>The text that doesn't contain the VT sequences</returns>
        public static string[] SplitVTSequences(string Text) => SplitVTSequences(Text, RegexOptions.None);

        /// <summary>
        /// Splits all of the VT sequences
        /// </summary>
        /// <param name="Text">The text that contains the VT sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the VT sequences</returns>
        public static string[] SplitVTSequences(string Text, RegexOptions options)
        {
            // Split all sequences
            return Regex.Split(Text, RegexVTExpressions.AllVTSequences, options);
        }

        /// <summary>
        /// Splits all of the CSI sequences
        /// </summary>
        /// <param name="Text">The text that contains the CSI sequences</param>
        /// <returns>The text that doesn't contain the CSI sequences</returns>
        public static string[] SplitCSISequences(string Text) => SplitCSISequences(Text, RegexOptions.None);

        /// <summary>
        /// Splits all of the CSI sequences
        /// </summary>
        /// <param name="Text">The text that contains the CSI sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the CSI sequences</returns>
        public static string[] SplitCSISequences(string Text, RegexOptions options)
        {
            // Split CSI sequences
            return Regex.Split(Text, RegexVTExpressions.CSISequences, options);
        }

        /// <summary>
        /// Splits all of the OSC sequences
        /// </summary>
        /// <param name="Text">The text that contains the OSC sequences</param>
        /// <returns>The text that doesn't contain the OSC sequences</returns>
        public static string[] SplitOSCSequences(string Text) => SplitOSCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Splits all of the OSC sequences
        /// </summary>
        /// <param name="Text">The text that contains the OSC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the OSC sequences</returns>
        public static string[] SplitOSCSequences(string Text, RegexOptions options)
        {
            // Split OSC sequences
            return Regex.Split(Text, RegexVTExpressions.OSCSequences, options);
        }
        
        /// <summary>
        /// Splits all of the ESC sequences
        /// </summary>
        /// <param name="Text">The text that contains the ESC sequences</param>
        /// <returns>The text that doesn't contain the ESC sequences</returns>
        public static string[] SplitESCSequences(string Text) => SplitESCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Splits all of the ESC sequences
        /// </summary>
        /// <param name="Text">The text that contains the ESC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the ESC sequences</returns>
        public static string[] SplitESCSequences(string Text, RegexOptions options)
        {
            // Split ESC sequences
            return Regex.Split(Text, RegexVTExpressions.ESCSequences, options);
        }
        
        /// <summary>
        /// Splits all of the APC sequences
        /// </summary>
        /// <param name="Text">The text that contains the APC sequences</param>
        /// <returns>The text that doesn't contain the APC sequences</returns>
        public static string[] SplitAPCSequences(string Text) => SplitAPCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Splits all of the APC sequences
        /// </summary>
        /// <param name="Text">The text that contains the APC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the APC sequences</returns>
        public static string[] SplitAPCSequences(string Text, RegexOptions options)
        {
            // Split APC sequences
            return Regex.Split(Text, RegexVTExpressions.APCSequences, options);
        }
        
        /// <summary>
        /// Splits all of the DCS sequences
        /// </summary>
        /// <param name="Text">The text that contains the DCS sequences</param>
        /// <returns>The text that doesn't contain the DCS sequences</returns>
        public static string[] SplitDCSSequences(string Text) => SplitDCSSequences(Text, RegexOptions.None);

        /// <summary>
        /// Splits all of the DCS sequences
        /// </summary>
        /// <param name="Text">The text that contains the DCS sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the DCS sequences</returns>
        public static string[] SplitDCSSequences(string Text, RegexOptions options)
        {
            // Split DCS sequences
            return Regex.Split(Text, RegexVTExpressions.DCSSequences, options);
        }
        
        /// <summary>
        /// Splits all of the PM sequences
        /// </summary>
        /// <param name="Text">The text that contains the PM sequences</param>
        /// <returns>The text that doesn't contain the PM sequences</returns>
        public static string[] SplitPMSequences(string Text) => SplitPMSequences(Text, RegexOptions.None);

        /// <summary>
        /// Splits all of the PM sequences
        /// </summary>
        /// <param name="Text">The text that contains the PM sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the PM sequences</returns>
        public static string[] SplitPMSequences(string Text, RegexOptions options)
        {
            // Split PM sequences
            return Regex.Split(Text, RegexVTExpressions.PMSequences, options);
        }
        
        /// <summary>
        /// Splits all of the C1 sequences
        /// </summary>
        /// <param name="Text">The text that contains the C1 sequences</param>
        /// <returns>The text that doesn't contain the C1 sequences</returns>
        public static string[] SplitC1Sequences(string Text) => SplitC1Sequences(Text, RegexOptions.None);

        /// <summary>
        /// Splits all of the C1 sequences
        /// </summary>
        /// <param name="Text">The text that contains the C1 sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the C1 sequences</returns>
        public static string[] SplitC1Sequences(string Text, RegexOptions options)
        {
            // Split C1 sequences
            return Regex.Split(Text, RegexVTExpressions.C1Sequences, options);
        }
    }
}