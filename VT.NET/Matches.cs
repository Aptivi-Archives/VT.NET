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
        public static MatchCollection MatchVTSequences(string Text)
        {
            // Match all sequences
            return Regex.Matches(Text, RegexVTExpressions.AllVTSequences);
        }
        
        /// <summary>
        /// Matches all of the CSI sequences
        /// </summary>
        /// <param name="Text">The text that contains the CSI sequences</param>
        /// <returns>The text that doesn't contain the CSI sequences</returns>
        public static MatchCollection MatchCSISequences(string Text)
        {
            // Match CSI sequences
            return Regex.Matches(Text, RegexVTExpressions.CSISequences);
        }
        
        /// <summary>
        /// Matches all of the OSC sequences
        /// </summary>
        /// <param name="Text">The text that contains the OSC sequences</param>
        /// <returns>The text that doesn't contain the OSC sequences</returns>
        public static MatchCollection MatchOSCSequences(string Text)
        {
            // Match OSC sequences
            return Regex.Matches(Text, RegexVTExpressions.OSCSequences);
        }
        
        /// <summary>
        /// Matches all of the ESC sequences
        /// </summary>
        /// <param name="Text">The text that contains the ESC sequences</param>
        /// <returns>The text that doesn't contain the ESC sequences</returns>
        public static MatchCollection MatchESCSequences(string Text)
        {
            // Match ESC sequences
            return Regex.Matches(Text, RegexVTExpressions.ESCSequences);
        }
        
        /// <summary>
        /// Matches all of the APC sequences
        /// </summary>
        /// <param name="Text">The text that contains the APC sequences</param>
        /// <returns>The text that doesn't contain the APC sequences</returns>
        public static MatchCollection MatchAPCSequences(string Text)
        {
            // Match APC sequences
            return Regex.Matches(Text, RegexVTExpressions.APCSequences);
        }
        
        /// <summary>
        /// Matches all of the DCS sequences
        /// </summary>
        /// <param name="Text">The text that contains the DCS sequences</param>
        /// <returns>The text that doesn't contain the DCS sequences</returns>
        public static MatchCollection MatchDCSSequences(string Text)
        {
            // Match DCS sequences
            return Regex.Matches(Text, RegexVTExpressions.DCSSequences);
        }
        
        /// <summary>
        /// Matches all of the PM sequences
        /// </summary>
        /// <param name="Text">The text that contains the PM sequences</param>
        /// <returns>The text that doesn't contain the PM sequences</returns>
        public static MatchCollection MatchPMSequences(string Text)
        {
            // Match PM sequences
            return Regex.Matches(Text, RegexVTExpressions.PMSequences);
        }
        
        /// <summary>
        /// Matches all of the C1 sequences
        /// </summary>
        /// <param name="Text">The text that contains the C1 sequences</param>
        /// <returns>The text that doesn't contain the C1 sequences</returns>
        public static MatchCollection MatchC1Sequences(string Text)
        {
            // Match C1 sequences
            return Regex.Matches(Text, RegexVTExpressions.C1Sequences);
        }
    }
}