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
    public static class Queries
    {
        /// <summary>
        /// Does the string contain all of the VT sequences
        /// </summary>
        /// <param name="Text">The text that contains the VT sequences</param>
        /// <returns>The text that doesn't contain the VT sequences</returns>
        public static bool IsMatchVTSequences(string Text) => IsMatchVTSequences(Text, RegexOptions.None);

        /// <summary>
        /// Does the string contain all of the VT sequences
        /// </summary>
        /// <param name="Text">The text that contains the VT sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the VT sequences</returns>
        public static bool IsMatchVTSequences(string Text, RegexOptions options)
        {
            // IsMatch all sequences
            return Regex.IsMatch(Text, RegexVTExpressions.AllVTSequences, options);
        }

        /// <summary>
        /// Does the string contain all of the CSI sequences
        /// </summary>
        /// <param name="Text">The text that contains the CSI sequences</param>
        /// <returns>The text that doesn't contain the CSI sequences</returns>
        public static bool IsMatchCSISequences(string Text) => IsMatchCSISequences(Text, RegexOptions.None);

        /// <summary>
        /// Does the string contain all of the CSI sequences
        /// </summary>
        /// <param name="Text">The text that contains the CSI sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the CSI sequences</returns>
        public static bool IsMatchCSISequences(string Text, RegexOptions options)
        {
            // IsMatch CSI sequences
            return Regex.IsMatch(Text, RegexVTExpressions.CSISequences, options);
        }
        
        /// <summary>
        /// Does the string contain all of the OSC sequences
        /// </summary>
        /// <param name="Text">The text that contains the OSC sequences</param>
        /// <returns>The text that doesn't contain the OSC sequences</returns>
        public static bool IsMatchOSCSequences(string Text) => IsMatchOSCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Does the string contain all of the OSC sequences
        /// </summary>
        /// <param name="Text">The text that contains the OSC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the OSC sequences</returns>
        public static bool IsMatchOSCSequences(string Text, RegexOptions options)
        {
            // IsMatch OSC sequences
            return Regex.IsMatch(Text, RegexVTExpressions.OSCSequences, options);
        }
        
        /// <summary>
        /// Does the string contain all of the ESC sequences
        /// </summary>
        /// <param name="Text">The text that contains the ESC sequences</param>
        /// <returns>The text that doesn't contain the ESC sequences</returns>
        public static bool IsMatchESCSequences(string Text) => IsMatchESCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Does the string contain all of the ESC sequences
        /// </summary>
        /// <param name="Text">The text that contains the ESC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the ESC sequences</returns>
        public static bool IsMatchESCSequences(string Text, RegexOptions options)
        {
            // IsMatch ESC sequences
            return Regex.IsMatch(Text, RegexVTExpressions.ESCSequences, options);
        }
        
        /// <summary>
        /// Does the string contain all of the APC sequences
        /// </summary>
        /// <param name="Text">The text that contains the APC sequences</param>
        /// <returns>The text that doesn't contain the APC sequences</returns>
        public static bool IsMatchAPCSequences(string Text) => IsMatchAPCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Does the string contain all of the APC sequences
        /// </summary>
        /// <param name="Text">The text that contains the APC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the APC sequences</returns>
        public static bool IsMatchAPCSequences(string Text, RegexOptions options)
        {
            // IsMatch APC sequences
            return Regex.IsMatch(Text, RegexVTExpressions.APCSequences, options);
        }
        
        /// <summary>
        /// Does the string contain all of the DCS sequences
        /// </summary>
        /// <param name="Text">The text that contains the DCS sequences</param>
        /// <returns>The text that doesn't contain the DCS sequences</returns>
        public static bool IsMatchDCSSequences(string Text) => IsMatchDCSSequences(Text, RegexOptions.None);

        /// <summary>
        /// Does the string contain all of the DCS sequences
        /// </summary>
        /// <param name="Text">The text that contains the DCS sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the DCS sequences</returns>
        public static bool IsMatchDCSSequences(string Text, RegexOptions options)
        {
            // IsMatch DCS sequences
            return Regex.IsMatch(Text, RegexVTExpressions.DCSSequences, options);
        }
        
        /// <summary>
        /// Does the string contain all of the PM sequences
        /// </summary>
        /// <param name="Text">The text that contains the PM sequences</param>
        /// <returns>The text that doesn't contain the PM sequences</returns>
        public static bool IsMatchPMSequences(string Text) => IsMatchPMSequences(Text, RegexOptions.None);

        /// <summary>
        /// Does the string contain all of the PM sequences
        /// </summary>
        /// <param name="Text">The text that contains the PM sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the PM sequences</returns>
        public static bool IsMatchPMSequences(string Text, RegexOptions options)
        {
            // IsMatch PM sequences
            return Regex.IsMatch(Text, RegexVTExpressions.PMSequences, options);
        }
        
        /// <summary>
        /// Does the string contain all of the C1 sequences
        /// </summary>
        /// <param name="Text">The text that contains the C1 sequences</param>
        /// <returns>The text that doesn't contain the C1 sequences</returns>
        public static bool IsMatchC1Sequences(string Text) => IsMatchC1Sequences(Text, RegexOptions.None);

        /// <summary>
        /// Does the string contain all of the C1 sequences
        /// </summary>
        /// <param name="Text">The text that contains the C1 sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the C1 sequences</returns>
        public static bool IsMatchC1Sequences(string Text, RegexOptions options)
        {
            // IsMatch C1 sequences
            return Regex.IsMatch(Text, RegexVTExpressions.C1Sequences, options);
        }
    }
}