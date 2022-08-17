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
    public class QueriesTests
    {
        /// <summary>
        /// Tests checking to see if the string contains the VT sequences
        /// </summary>
        [Test]
        public void TestIsMatchVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            Queries.IsMatchVTSequences($"Hello!{EscapeChar}[38;5;43m").ShouldBeTrue();
            Queries.IsMatchVTSequences($"{EscapeChar}]0;This is the title{BellChar}Hello!").ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the APC sequences
        /// </summary>
        [Test]
        public void TestIsMatchAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Queries.IsMatchAPCSequences($"Hello!{EscapeChar}_1{StringTerminator}").ShouldBeTrue();
            Queries.IsMatchAPCSequences($"{EscapeChar}_1{StringTerminator}Hello!").ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the C1 sequences
        /// </summary>
        [Test]
        public void TestIsMatchC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Queries.IsMatchC1Sequences($"Hello!{EscapeChar}8").ShouldBeTrue();
            Queries.IsMatchC1Sequences($"{EscapeChar}MHello!").ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the CSI sequences
        /// </summary>
        [Test]
        public void TestIsMatchCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Queries.IsMatchCSISequences($"Hello!{EscapeChar}[37m").ShouldBeTrue();
            Queries.IsMatchCSISequences($"{EscapeChar}[37mHello!").ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the DCS sequences
        /// </summary>
        [Test]
        public void TestIsMatchDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Queries.IsMatchDCSSequences($"Hello!{EscapeChar}P3{StringTerminator}").ShouldBeTrue();
            Queries.IsMatchDCSSequences($"{EscapeChar}P3{StringTerminator}Hello!").ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the ESC sequences
        /// </summary>
        [Test]
        public void TestIsMatchESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Queries.IsMatchESCSequences($"Hello!{EscapeChar}#4").ShouldBeTrue();
            Queries.IsMatchESCSequences($"{EscapeChar}%GHello!").ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the OSC sequences
        /// </summary>
        [Test]
        public void TestIsMatchOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Queries.IsMatchOSCSequences($"Hello!{EscapeChar}]0;Title{StringTerminator}").ShouldBeTrue();
            Queries.IsMatchOSCSequences($"{EscapeChar}]0;Title{StringTerminator}Hello!").ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the PM sequences
        /// </summary>
        [Test]
        public void TestIsMatchPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Queries.IsMatchPMSequences($"Hello!{EscapeChar}^Kermit{StringTerminator}").ShouldBeTrue();
            Queries.IsMatchPMSequences($"{EscapeChar}^Kermit{StringTerminator}Hello!").ShouldBeTrue();
        }
    }
}