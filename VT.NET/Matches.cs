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
    public static class Matches 
    {
        /// <summary>
        /// Matches all of the VT sequences
        /// </summary>
        /// <param name="Text">The text that contains the VT sequences</param>
        /// <returns>The text that doesn't contain the VT sequences</returns>
        public static MatchCollection MatchVTSequences(string Text) => MatchVTSequences(Text, RegexOptions.None);

        /// <summary>
        /// Matches all of the VT sequences
        /// </summary>
        /// <param name="Text">The text that contains the VT sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the VT sequences</returns>
        public static MatchCollection MatchVTSequences(string Text, RegexOptions options)
        {
            // Match all sequences
            return Regex.Matches(Text, RegexVTExpressions.AllVTSequences, options);
        }

        /// <summary>
        /// Matches all of the CSI sequences
        /// </summary>
        /// <param name="Text">The text that contains the CSI sequences</param>
        /// <returns>The text that doesn't contain the CSI sequences</returns>
        public static MatchCollection MatchCSISequences(string Text) => MatchCSISequences(Text, RegexOptions.None);

        /// <summary>
        /// Matches all of the CSI sequences
        /// </summary>
        /// <param name="Text">The text that contains the CSI sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the CSI sequences</returns>
        public static MatchCollection MatchCSISequences(string Text, RegexOptions options)
        {
            // Match CSI sequences
            return Regex.Matches(Text, RegexVTExpressions.CSISequences, options);
        }
        
        /// <summary>
        /// Matches all of the OSC sequences
        /// </summary>
        /// <param name="Text">The text that contains the OSC sequences</param>
        /// <returns>The text that doesn't contain the OSC sequences</returns>
        public static MatchCollection MatchOSCSequences(string Text) => MatchOSCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Matches all of the OSC sequences
        /// </summary>
        /// <param name="Text">The text that contains the OSC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the OSC sequences</returns>
        public static MatchCollection MatchOSCSequences(string Text, RegexOptions options)
        {
            // Match OSC sequences
            return Regex.Matches(Text, RegexVTExpressions.OSCSequences, options);
        }
        
        /// <summary>
        /// Matches all of the ESC sequences
        /// </summary>
        /// <param name="Text">The text that contains the ESC sequences</param>
        /// <returns>The text that doesn't contain the ESC sequences</returns>
        public static MatchCollection MatchESCSequences(string Text) => MatchESCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Matches all of the ESC sequences
        /// </summary>
        /// <param name="Text">The text that contains the ESC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the ESC sequences</returns>
        public static MatchCollection MatchESCSequences(string Text, RegexOptions options)
        {
            // Match ESC sequences
            return Regex.Matches(Text, RegexVTExpressions.ESCSequences, options);
        }
        
        /// <summary>
        /// Matches all of the APC sequences
        /// </summary>
        /// <param name="Text">The text that contains the APC sequences</param>
        /// <returns>The text that doesn't contain the APC sequences</returns>
        public static MatchCollection MatchAPCSequences(string Text) => MatchAPCSequences(Text, RegexOptions.None);

        /// <summary>
        /// Matches all of the APC sequences
        /// </summary>
        /// <param name="Text">The text that contains the APC sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the APC sequences</returns>
        public static MatchCollection MatchAPCSequences(string Text, RegexOptions options)
        {
            // Match APC sequences
            return Regex.Matches(Text, RegexVTExpressions.APCSequences, options);
        }
        
        /// <summary>
        /// Matches all of the DCS sequences
        /// </summary>
        /// <param name="Text">The text that contains the DCS sequences</param>
        /// <returns>The text that doesn't contain the DCS sequences</returns>
        public static MatchCollection MatchDCSSequences(string Text) => MatchDCSSequences(Text, RegexOptions.None);

        /// <summary>
        /// Matches all of the DCS sequences
        /// </summary>
        /// <param name="Text">The text that contains the DCS sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the DCS sequences</returns>
        public static MatchCollection MatchDCSSequences(string Text, RegexOptions options)
        {
            // Match DCS sequences
            return Regex.Matches(Text, RegexVTExpressions.DCSSequences, options);
        }
        
        /// <summary>
        /// Matches all of the PM sequences
        /// </summary>
        /// <param name="Text">The text that contains the PM sequences</param>
        /// <returns>The text that doesn't contain the PM sequences</returns>
        public static MatchCollection MatchPMSequences(string Text) => MatchPMSequences(Text, RegexOptions.None);

        /// <summary>
        /// Matches all of the PM sequences
        /// </summary>
        /// <param name="Text">The text that contains the PM sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the PM sequences</returns>
        public static MatchCollection MatchPMSequences(string Text, RegexOptions options)
        {
            // Match PM sequences
            return Regex.Matches(Text, RegexVTExpressions.PMSequences, options);
        }
        
        /// <summary>
        /// Matches all of the C1 sequences
        /// </summary>
        /// <param name="Text">The text that contains the C1 sequences</param>
        /// <returns>The text that doesn't contain the C1 sequences</returns>
        public static MatchCollection MatchC1Sequences(string Text) => MatchC1Sequences(Text, RegexOptions.None);

        /// <summary>
        /// Matches all of the C1 sequences
        /// </summary>
        /// <param name="Text">The text that contains the C1 sequences</param>
        /// <param name="options">Regular expression options</param>
        /// <returns>The text that doesn't contain the C1 sequences</returns>
        public static MatchCollection MatchC1Sequences(string Text, RegexOptions options)
        {
            // Match C1 sequences
            return Regex.Matches(Text, RegexVTExpressions.C1Sequences, options);
        }
    }
}