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
    public class SplitsTests
    {
        /// <summary>
        /// Tests splitting the VT sequences
        /// </summary>
        [Test]
        public void TestSplitVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            Splits.SplitVTSequences($"Hello!{EscapeChar}[38;5;43m").ShouldNotBeEmpty();
            Splits.SplitVTSequences($"{EscapeChar}]0;This is the title{BellChar}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the APC sequences
        /// </summary>
        [Test]
        public void TestSplitAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Splits.SplitAPCSequences($"Hello!{EscapeChar}_1{StringTerminator}").ShouldNotBeEmpty();
            Splits.SplitAPCSequences($"{EscapeChar}_1{StringTerminator}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the C1 sequences
        /// </summary>
        [Test]
        public void TestSplitC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Splits.SplitC1Sequences($"Hello!{EscapeChar}8").ShouldNotBeEmpty();
            Splits.SplitC1Sequences($"{EscapeChar}MHello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the CSI sequences
        /// </summary>
        [Test]
        public void TestSplitCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Splits.SplitCSISequences($"Hello!{EscapeChar}[37m").ShouldNotBeEmpty();
            Splits.SplitCSISequences($"{EscapeChar}[37mHello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the DCS sequences
        /// </summary>
        [Test]
        public void TestSplitDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Splits.SplitDCSSequences($"Hello!{EscapeChar}P3{StringTerminator}").ShouldNotBeEmpty();
            Splits.SplitDCSSequences($"{EscapeChar}P3{StringTerminator}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the ESC sequences
        /// </summary>
        [Test]
        public void TestSplitESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Splits.SplitESCSequences($"Hello!{EscapeChar}#4").ShouldNotBeEmpty();
            Splits.SplitESCSequences($"{EscapeChar}%GHello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the OSC sequences
        /// </summary>
        [Test]
        public void TestSplitOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Splits.SplitOSCSequences($"Hello!{EscapeChar}]0;Title{StringTerminator}").ShouldNotBeEmpty();
            Splits.SplitOSCSequences($"{EscapeChar}]0;Title{StringTerminator}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the PM sequences
        /// </summary>
        [Test]
        public void TestSplitPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Splits.SplitPMSequences($"Hello!{EscapeChar}^Kermit{StringTerminator}").ShouldNotBeEmpty();
            Splits.SplitPMSequences($"{EscapeChar}^Kermit{StringTerminator}Hello!").ShouldNotBeEmpty();
        }
    }
}