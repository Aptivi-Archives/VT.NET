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
    public class FiltersTests
    {
        /// <summary>
        /// Tests filtering the VT sequences
        /// </summary>
        [Test]
        public void TestFilterVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            Filters.FilterVTSequences($"Hello!{EscapeChar}[38;5;43m").ShouldBe("Hello!");
            Filters.FilterVTSequences($"{EscapeChar}]0;This is the title{BellChar}Hello!").ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the APC sequences
        /// </summary>
        [Test]
        public void TestFilterAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Filters.FilterAPCSequences($"Hello!{EscapeChar}_1{StringTerminator}").ShouldBe("Hello!");
            Filters.FilterAPCSequences($"{EscapeChar}_1{StringTerminator}Hello!").ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the C1 sequences
        /// </summary>
        [Test]
        public void TestFilterC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Filters.FilterC1Sequences($"Hello!{EscapeChar}8").ShouldBe("Hello!");
            Filters.FilterC1Sequences($"{EscapeChar}MHello!").ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the CSI sequences
        /// </summary>
        [Test]
        public void TestFilterCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Filters.FilterCSISequences($"Hello!{EscapeChar}[37m").ShouldBe("Hello!");
            Filters.FilterCSISequences($"{EscapeChar}[37mHello!").ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the DCS sequences
        /// </summary>
        [Test]
        public void TestFilterDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Filters.FilterDCSSequences($"Hello!{EscapeChar}P3{StringTerminator}").ShouldBe("Hello!");
            Filters.FilterDCSSequences($"{EscapeChar}P3{StringTerminator}Hello!").ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the ESC sequences
        /// </summary>
        [Test]
        public void TestFilterESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            Filters.FilterESCSequences($"Hello!{EscapeChar}#4").ShouldBe("Hello!");
            Filters.FilterESCSequences($"{EscapeChar}%GHello!").ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the OSC sequences
        /// </summary>
        [Test]
        public void TestFilterOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Filters.FilterOSCSequences($"Hello!{EscapeChar}]0;Title{StringTerminator}").ShouldBe("Hello!");
            Filters.FilterOSCSequences($"{EscapeChar}]0;Title{StringTerminator}Hello!").ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the PM sequences
        /// </summary>
        [Test]
        public void TestFilterPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            Filters.FilterPMSequences($"Hello!{EscapeChar}^Kermit{StringTerminator}").ShouldBe("Hello!");
            Filters.FilterPMSequences($"{EscapeChar}^Kermit{StringTerminator}Hello!").ShouldBe("Hello!");
        }
    }
}