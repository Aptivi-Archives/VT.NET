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

using Shouldly;

namespace VT.NET.Tests
{
    public class MatchesTests
    {
        /// <summary>
        /// Tests matching the VT sequences
        /// </summary>
        [Test]
        public void TestMatchVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            Matches.MatchVTSequences($"Hello!{EscapeChar}[38;5;43m").ShouldNotBeEmpty();
            Matches.MatchVTSequences($"{EscapeChar}]0;This is the title{BellChar}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests matching the APC sequences
        /// </summary>
        [Test]
        public void TestMatchAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Matches.MatchAPCSequences($"Hello!{EscapeChar}_1{StringTerminator}").ShouldNotBeEmpty();
            Matches.MatchAPCSequences($"{EscapeChar}_1{StringTerminator}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests matching the C1 sequences
        /// </summary>
        [Test]
        public void TestMatchC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Matches.MatchC1Sequences($"Hello!{EscapeChar}8").ShouldNotBeEmpty();
            Matches.MatchC1Sequences($"{EscapeChar}MHello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests matching the CSI sequences
        /// </summary>
        [Test]
        public void TestMatchCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Matches.MatchCSISequences($"Hello!{EscapeChar}[37m").ShouldNotBeEmpty();
            Matches.MatchCSISequences($"{EscapeChar}[37mHello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests matching the DCS sequences
        /// </summary>
        [Test]
        public void TestMatchDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Matches.MatchDCSSequences($"Hello!{EscapeChar}P3{StringTerminator}").ShouldNotBeEmpty();
            Matches.MatchDCSSequences($"{EscapeChar}P3{StringTerminator}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests matching the ESC sequences
        /// </summary>
        [Test]
        public void TestMatchESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Matches.MatchESCSequences($"Hello!{EscapeChar}#4").ShouldNotBeEmpty();
            Matches.MatchESCSequences($"{EscapeChar}%GHello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests matching the OSC sequences
        /// </summary>
        [Test]
        public void TestMatchOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Matches.MatchOSCSequences($"Hello!{EscapeChar}]0;Title{StringTerminator}").ShouldNotBeEmpty();
            Matches.MatchOSCSequences($"{EscapeChar}]0;Title{StringTerminator}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests matching the PM sequences
        /// </summary>
        [Test]
        public void TestMatchPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Matches.MatchPMSequences($"Hello!{EscapeChar}^Kermit{StringTerminator}").ShouldNotBeEmpty();
            Matches.MatchPMSequences($"{EscapeChar}^Kermit{StringTerminator}Hello!").ShouldNotBeEmpty();
        }
    }
}