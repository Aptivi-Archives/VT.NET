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
using System.Text.RegularExpressions;
using VT.NET.Tools;

namespace VT.NET.Tests
{
    public class VtSequenceToolsTests
    {
        /// <summary>
        /// Tests splitting the VT sequences
        /// </summary>
        [Test]
        public void TestSplitVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            char StringTerminator = Convert.ToChar(0x9c);
            string vtSequence1 = $"{EscapeChar}[38;5;43m";
            string vtSequence2 = $"{EscapeChar}_1{StringTerminator}";
            string vtSequence3 = $"{EscapeChar}]0;Hi!{BellChar}";
            VtSequenceTools.SplitVTSequences($"Hello!{vtSequence1}").ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"Hel{vtSequence2}lo!").ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"{vtSequence3}Hello!").ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the APC sequences
        /// </summary>
        [Test]
        public void TestSplitAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}_1{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.APC;
            VtSequenceTools.SplitVTSequences($"Hello!{vtSequence1}", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"{vtSequence1}Hello!", requestedType).ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the C1 sequences
        /// </summary>
        [Test]
        public void TestSplitC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}8";
            string vtSequence2 = $"{EscapeChar}M";
            VtSequenceType requestedType = VtSequenceType.C1;
            VtSequenceTools.SplitVTSequences($"Hello!{vtSequence1}", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"{vtSequence2}Hello!", requestedType).ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the CSI sequences
        /// </summary>
        [Test]
        public void TestSplitCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}[37m";
            VtSequenceType requestedType = VtSequenceType.CSI;
            VtSequenceTools.SplitVTSequences($"Hello!{vtSequence1}", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"{vtSequence1}Hello!", requestedType).ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the DCS sequences
        /// </summary>
        [Test]
        public void TestSplitDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}P3{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.DCS;
            VtSequenceTools.SplitVTSequences($"Hello!{vtSequence1}", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"{vtSequence1}Hello!", requestedType).ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the ESC sequences
        /// </summary>
        [Test]
        public void TestSplitESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}#4";
            string vtSequence2 = $"{EscapeChar}%G";
            VtSequenceType requestedType = VtSequenceType.ESC;
            VtSequenceTools.SplitVTSequences($"Hello!{vtSequence1}", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"{vtSequence2}Hello!", requestedType).ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the OSC sequences
        /// </summary>
        [Test]
        public void TestSplitOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}]0;Title{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.OSC;
            VtSequenceTools.SplitVTSequences($"Hello!{vtSequence1}", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"{vtSequence1}Hello!", requestedType).ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests splitting the PM sequences
        /// </summary>
        [Test]
        public void TestSplitPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}^Kermit{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.PM;
            VtSequenceTools.SplitVTSequences($"Hello!{vtSequence1}", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldNotBeEmpty();
            VtSequenceTools.SplitVTSequences($"{vtSequence1}Hello!", requestedType).ShouldNotBeEmpty();
        }

        /// <summary>
        /// Tests filtering the VT sequences
        /// </summary>
        [Test]
        public void TestFilterVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            char StringTerminator = Convert.ToChar(0x9c);
            string vtSequence1 = $"{EscapeChar}[38;5;43m";
            string vtSequence2 = $"{EscapeChar}_1{StringTerminator}";
            string vtSequence3 = $"{EscapeChar}]0;This is the title{BellChar}";
            VtSequenceTools.FilterVTSequences($"Hello!{vtSequence1}").ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"Hel{vtSequence2}lo!").ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"{vtSequence3}Hello!").ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the APC sequences
        /// </summary>
        [Test]
        public void TestFilterAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}_1{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.APC;
            VtSequenceTools.FilterVTSequences($"Hello!{vtSequence1}", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"{vtSequence1}Hello!", "", requestedType).ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the C1 sequences
        /// </summary>
        [Test]
        public void TestFilterC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}8";
            string vtSequence2 = $"{EscapeChar}M";
            VtSequenceType requestedType = VtSequenceType.C1;
            VtSequenceTools.FilterVTSequences($"Hello!{vtSequence1}", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"Hel{vtSequence1}lo!", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"{vtSequence2}Hello!", "", requestedType).ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the CSI sequences
        /// </summary>
        [Test]
        public void TestFilterCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}[37m";
            VtSequenceType requestedType = VtSequenceType.CSI;
            VtSequenceTools.FilterVTSequences($"Hello!{vtSequence1}", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"Hel{vtSequence1}lo!", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"{vtSequence1}Hello!", "", requestedType).ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the DCS sequences
        /// </summary>
        [Test]
        public void TestFilterDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}P3{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.DCS;
            VtSequenceTools.FilterVTSequences($"Hello!{vtSequence1}", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"Hel{vtSequence1}lo!", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"{vtSequence1}Hello!", "", requestedType).ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the ESC sequences
        /// </summary>
        [Test]
        public void TestFilterESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}#4";
            string vtSequence2 = $"{EscapeChar}%G";
            VtSequenceType requestedType = VtSequenceType.ESC;
            VtSequenceTools.FilterVTSequences($"Hello!{vtSequence1}", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"Hel{vtSequence1}lo!", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"{vtSequence2}Hello!", "", requestedType).ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the OSC sequences
        /// </summary>
        [Test]
        public void TestFilterOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}]0;Title{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.OSC;
            VtSequenceTools.FilterVTSequences($"Hello!{vtSequence1}", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"Hel{vtSequence1}lo!", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"{vtSequence1}Hello!", "", requestedType).ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests filtering the PM sequences
        /// </summary>
        [Test]
        public void TestFilterPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}^Kermit{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.PM;
            VtSequenceTools.FilterVTSequences($"Hello!{vtSequence1}", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"Hel{vtSequence1}lo!", "", requestedType).ShouldBe("Hello!");
            VtSequenceTools.FilterVTSequences($"{vtSequence1}Hello!", "", requestedType).ShouldBe("Hello!");
        }

        /// <summary>
        /// Tests matching the VT sequences
        /// </summary>
        [Test]
        public void TestMatchVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            char StringTerminator = Convert.ToChar(0x9c);
            string vtSequence1 = $"{EscapeChar}[38;5;43m";
            string vtSequence2 = $"{EscapeChar}_1{StringTerminator}";
            string vtSequence3 = $"{EscapeChar}]0;Hi!{BellChar}";
            MatchCollection[] matchCollections1 = VtSequenceTools.MatchVTSequences($"Hello!{vtSequence1}");
            MatchCollection[] matchCollections2 = VtSequenceTools.MatchVTSequences($"Hel{vtSequence2}lo!");
            MatchCollection[] matchCollections3 = VtSequenceTools.MatchVTSequences($"{vtSequence3}Hello!");
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1.ShouldHaveSingleItem();
            matchCollections2.ShouldHaveSingleItem();
            matchCollections3.ShouldHaveSingleItem();
            matchCollections1[0].ShouldNotBeEmpty();
            matchCollections2[0].ShouldNotBeEmpty();
            matchCollections3[0].ShouldNotBeEmpty();
            matchCollections1[0].ShouldHaveSingleItem();
            matchCollections2[0].ShouldHaveSingleItem();
            matchCollections3[0].ShouldHaveSingleItem();
        }

        /// <summary>
        /// Tests matching the APC sequences
        /// </summary>
        [Test]
        public void TestMatchAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}_1{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.APC;
            MatchCollection[] matchCollections1 = VtSequenceTools.MatchVTSequences($"Hello!{vtSequence1}", requestedType);
            MatchCollection[] matchCollections2 = VtSequenceTools.MatchVTSequences($"Hel{vtSequence1}lo!", requestedType);
            MatchCollection[] matchCollections3 = VtSequenceTools.MatchVTSequences($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1.ShouldHaveSingleItem();
            matchCollections2.ShouldHaveSingleItem();
            matchCollections3.ShouldHaveSingleItem();
            matchCollections1[0].ShouldNotBeEmpty();
            matchCollections2[0].ShouldNotBeEmpty();
            matchCollections3[0].ShouldNotBeEmpty();
            matchCollections1[0].ShouldHaveSingleItem();
            matchCollections2[0].ShouldHaveSingleItem();
            matchCollections3[0].ShouldHaveSingleItem();
        }

        /// <summary>
        /// Tests matching the C1 sequences
        /// </summary>
        [Test]
        public void TestMatchC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}8";
            string vtSequence2 = $"{EscapeChar}M";
            VtSequenceType requestedType = VtSequenceType.C1;
            MatchCollection[] matchCollections1 = VtSequenceTools.MatchVTSequences($"Hello!{vtSequence1}", requestedType);
            MatchCollection[] matchCollections2 = VtSequenceTools.MatchVTSequences($"Hel{vtSequence1}lo!", requestedType);
            MatchCollection[] matchCollections3 = VtSequenceTools.MatchVTSequences($"{vtSequence2}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1.ShouldHaveSingleItem();
            matchCollections2.ShouldHaveSingleItem();
            matchCollections3.ShouldHaveSingleItem();
            matchCollections1[0].ShouldNotBeEmpty();
            matchCollections2[0].ShouldNotBeEmpty();
            matchCollections3[0].ShouldNotBeEmpty();
            matchCollections1[0].ShouldHaveSingleItem();
            matchCollections2[0].ShouldHaveSingleItem();
            matchCollections3[0].ShouldHaveSingleItem();
        }

        /// <summary>
        /// Tests matching the CSI sequences
        /// </summary>
        [Test]
        public void TestMatchCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}[37m";
            VtSequenceType requestedType = VtSequenceType.CSI;
            MatchCollection[] matchCollections1 = VtSequenceTools.MatchVTSequences($"Hello!{vtSequence1}", requestedType);
            MatchCollection[] matchCollections2 = VtSequenceTools.MatchVTSequences($"Hel{vtSequence1}lo!", requestedType);
            MatchCollection[] matchCollections3 = VtSequenceTools.MatchVTSequences($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1.ShouldHaveSingleItem();
            matchCollections2.ShouldHaveSingleItem();
            matchCollections3.ShouldHaveSingleItem();
            matchCollections1[0].ShouldNotBeEmpty();
            matchCollections2[0].ShouldNotBeEmpty();
            matchCollections3[0].ShouldNotBeEmpty();
            matchCollections1[0].ShouldHaveSingleItem();
            matchCollections2[0].ShouldHaveSingleItem();
            matchCollections3[0].ShouldHaveSingleItem();
        }

        /// <summary>
        /// Tests matching the DCS sequences
        /// </summary>
        [Test]
        public void TestMatchDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}P3{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.DCS;
            MatchCollection[] matchCollections1 = VtSequenceTools.MatchVTSequences($"Hello!{vtSequence1}", requestedType);
            MatchCollection[] matchCollections2 = VtSequenceTools.MatchVTSequences($"Hel{vtSequence1}lo!", requestedType);
            MatchCollection[] matchCollections3 = VtSequenceTools.MatchVTSequences($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1.ShouldHaveSingleItem();
            matchCollections2.ShouldHaveSingleItem();
            matchCollections3.ShouldHaveSingleItem();
            matchCollections1[0].ShouldNotBeEmpty();
            matchCollections2[0].ShouldNotBeEmpty();
            matchCollections3[0].ShouldNotBeEmpty();
            matchCollections1[0].ShouldHaveSingleItem();
            matchCollections2[0].ShouldHaveSingleItem();
            matchCollections3[0].ShouldHaveSingleItem();
        }

        /// <summary>
        /// Tests matching the ESC sequences
        /// </summary>
        [Test]
        public void TestMatchESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}#4";
            string vtSequence2 = $"{EscapeChar}%G";
            VtSequenceType requestedType = VtSequenceType.ESC;
            MatchCollection[] matchCollections1 = VtSequenceTools.MatchVTSequences($"Hello!{vtSequence1}", requestedType);
            MatchCollection[] matchCollections2 = VtSequenceTools.MatchVTSequences($"Hel{vtSequence1}lo!", requestedType);
            MatchCollection[] matchCollections3 = VtSequenceTools.MatchVTSequences($"{vtSequence2}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1.ShouldHaveSingleItem();
            matchCollections2.ShouldHaveSingleItem();
            matchCollections3.ShouldHaveSingleItem();
            matchCollections1[0].ShouldNotBeEmpty();
            matchCollections2[0].ShouldNotBeEmpty();
            matchCollections3[0].ShouldNotBeEmpty();
            matchCollections1[0].ShouldHaveSingleItem();
            matchCollections2[0].ShouldHaveSingleItem();
            matchCollections3[0].ShouldHaveSingleItem();
        }

        /// <summary>
        /// Tests matching the OSC sequences
        /// </summary>
        [Test]
        public void TestMatchOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}]0;Title{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.OSC;
            MatchCollection[] matchCollections1 = VtSequenceTools.MatchVTSequences($"Hello!{vtSequence1}", requestedType);
            MatchCollection[] matchCollections2 = VtSequenceTools.MatchVTSequences($"Hel{vtSequence1}lo!", requestedType);
            MatchCollection[] matchCollections3 = VtSequenceTools.MatchVTSequences($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1.ShouldHaveSingleItem();
            matchCollections2.ShouldHaveSingleItem();
            matchCollections3.ShouldHaveSingleItem();
            matchCollections1[0].ShouldNotBeEmpty();
            matchCollections2[0].ShouldNotBeEmpty();
            matchCollections3[0].ShouldNotBeEmpty();
            matchCollections1[0].ShouldHaveSingleItem();
            matchCollections2[0].ShouldHaveSingleItem();
            matchCollections3[0].ShouldHaveSingleItem();
        }

        /// <summary>
        /// Tests matching the PM sequences
        /// </summary>
        [Test]
        public void TestMatchPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}^Kermit{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.PM;
            MatchCollection[] matchCollections1 = VtSequenceTools.MatchVTSequences($"Hello!{vtSequence1}", requestedType);
            MatchCollection[] matchCollections2 = VtSequenceTools.MatchVTSequences($"Hel{vtSequence1}lo!", requestedType);
            MatchCollection[] matchCollections3 = VtSequenceTools.MatchVTSequences($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1.ShouldHaveSingleItem();
            matchCollections2.ShouldHaveSingleItem();
            matchCollections3.ShouldHaveSingleItem();
            matchCollections1[0].ShouldNotBeEmpty();
            matchCollections2[0].ShouldNotBeEmpty();
            matchCollections3[0].ShouldNotBeEmpty();
            matchCollections1[0].ShouldHaveSingleItem();
            matchCollections2[0].ShouldHaveSingleItem();
            matchCollections3[0].ShouldHaveSingleItem();
        }

        /// <summary>
        /// Tests checking to see if the string contains the VT sequences
        /// </summary>
        [Test]
        public void TestIsMatchVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            char StringTerminator = Convert.ToChar(0x9c);
            string vtSequence1 = $"{EscapeChar}[38;5;43m";
            string vtSequence2 = $"{EscapeChar}_1{StringTerminator}";
            string vtSequence3 = $"{EscapeChar}]0;Hi!{BellChar}";
            VtSequenceTools.IsMatchVTSequences($"Hello!{vtSequence1}").ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"Hel{vtSequence2}lo!").ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"{vtSequence3}Hello!").ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the APC sequences
        /// </summary>
        [Test]
        public void TestIsMatchAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}_1{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.APC;
            VtSequenceTools.IsMatchVTSequences($"Hello!{vtSequence1}", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"{vtSequence1}Hello!", requestedType).ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the C1 sequences
        /// </summary>
        [Test]
        public void TestIsMatchC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}8";
            string vtSequence2 = $"{EscapeChar}M";
            VtSequenceType requestedType = VtSequenceType.C1;
            VtSequenceTools.IsMatchVTSequences($"Hello!{vtSequence1}", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"{vtSequence2}Hello!", requestedType).ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the CSI sequences
        /// </summary>
        [Test]
        public void TestIsMatchCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}[37m";
            VtSequenceType requestedType = VtSequenceType.CSI;
            VtSequenceTools.IsMatchVTSequences($"Hello!{vtSequence1}", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"{vtSequence1}Hello!", requestedType).ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the DCS sequences
        /// </summary>
        [Test]
        public void TestIsMatchDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}P3{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.DCS;
            VtSequenceTools.IsMatchVTSequences($"Hello!{vtSequence1}", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"{vtSequence1}Hello!", requestedType).ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the ESC sequences
        /// </summary>
        [Test]
        public void TestIsMatchESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}#4";
            string vtSequence2 = $"{EscapeChar}%G";
            VtSequenceType requestedType = VtSequenceType.ESC;
            VtSequenceTools.IsMatchVTSequences($"Hello!{vtSequence1}", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"{vtSequence2}Hello!", requestedType).ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the OSC sequences
        /// </summary>
        [Test]
        public void TestIsMatchOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}]0;Title{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.OSC;
            VtSequenceTools.IsMatchVTSequences($"Hello!{vtSequence1}", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"{vtSequence1}Hello!", requestedType).ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the PM sequences
        /// </summary>
        [Test]
        public void TestIsMatchPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}^Kermit{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.PM;
            VtSequenceTools.IsMatchVTSequences($"Hello!{vtSequence1}", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"Hel{vtSequence1}lo!", requestedType).ShouldBeTrue();
            VtSequenceTools.IsMatchVTSequences($"{vtSequence1}Hello!", requestedType).ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the VT sequences
        /// </summary>
        [Test]
        public void TestIsMatchSpecificVTSequences()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            char StringTerminator = Convert.ToChar(0x9c);
            string vtSequence1 = $"{EscapeChar}[38;5;43m";
            string vtSequence2 = $"{EscapeChar}_1{StringTerminator}";
            string vtSequence3 = $"{EscapeChar}]0;Hi!{BellChar}";
            var matchCollections1 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hello!{vtSequence1}");
            var matchCollections2 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hel{vtSequence2}lo!");
            var matchCollections3 = VtSequenceTools.IsMatchVTSequencesSpecific($"{vtSequence3}Hello!");
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1[VtSequenceType.CSI].ShouldBeTrue();
            matchCollections2[VtSequenceType.APC].ShouldBeTrue();
            matchCollections3[VtSequenceType.OSC].ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the APC sequences
        /// </summary>
        [Test]
        public void TestIsMatchSpecificAPCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}_1{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.APC;
            var matchCollections1 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hello!{vtSequence1}", requestedType);
            var matchCollections2 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hel{vtSequence1}lo!", requestedType);
            var matchCollections3 = VtSequenceTools.IsMatchVTSequencesSpecific($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1[VtSequenceType.APC].ShouldBeTrue();
            matchCollections2[VtSequenceType.APC].ShouldBeTrue();
            matchCollections3[VtSequenceType.APC].ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the C1 sequences
        /// </summary>
        [Test]
        public void TestIsMatchSpecificC1Sequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}8";
            string vtSequence2 = $"{EscapeChar}M";
            VtSequenceType requestedType = VtSequenceType.C1;
            var matchCollections1 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hello!{vtSequence1}", requestedType);
            var matchCollections2 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hel{vtSequence1}lo!", requestedType);
            var matchCollections3 = VtSequenceTools.IsMatchVTSequencesSpecific($"{vtSequence2}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1[VtSequenceType.C1].ShouldBeTrue();
            matchCollections2[VtSequenceType.C1].ShouldBeTrue();
            matchCollections3[VtSequenceType.C1].ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the CSI sequences
        /// </summary>
        [Test]
        public void TestIsMatchSpecificCSISequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}[37m";
            VtSequenceType requestedType = VtSequenceType.CSI;
            var matchCollections1 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hello!{vtSequence1}", requestedType);
            var matchCollections2 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hel{vtSequence1}lo!", requestedType);
            var matchCollections3 = VtSequenceTools.IsMatchVTSequencesSpecific($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1[VtSequenceType.CSI].ShouldBeTrue();
            matchCollections2[VtSequenceType.CSI].ShouldBeTrue();
            matchCollections3[VtSequenceType.CSI].ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the DCS sequences
        /// </summary>
        [Test]
        public void TestIsMatchSpecificDCSSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}P3{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.DCS;
            var matchCollections1 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hello!{vtSequence1}", requestedType);
            var matchCollections2 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hel{vtSequence1}lo!", requestedType);
            var matchCollections3 = VtSequenceTools.IsMatchVTSequencesSpecific($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1[VtSequenceType.DCS].ShouldBeTrue();
            matchCollections2[VtSequenceType.DCS].ShouldBeTrue();
            matchCollections3[VtSequenceType.DCS].ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the ESC sequences
        /// </summary>
        [Test]
        public void TestIsMatchSpecificESCSequences()
        {
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}#4";
            string vtSequence2 = $"{EscapeChar}%G";
            VtSequenceType requestedType = VtSequenceType.ESC;
            var matchCollections1 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hello!{vtSequence1}", requestedType);
            var matchCollections2 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hel{vtSequence1}lo!", requestedType);
            var matchCollections3 = VtSequenceTools.IsMatchVTSequencesSpecific($"{vtSequence2}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1[VtSequenceType.ESC].ShouldBeTrue();
            matchCollections2[VtSequenceType.ESC].ShouldBeTrue();
            matchCollections3[VtSequenceType.ESC].ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the OSC sequences
        /// </summary>
        [Test]
        public void TestIsMatchSpecificOSCSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}]0;Title{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.OSC;
            var matchCollections1 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hello!{vtSequence1}", requestedType);
            var matchCollections2 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hel{vtSequence1}lo!", requestedType);
            var matchCollections3 = VtSequenceTools.IsMatchVTSequencesSpecific($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1[VtSequenceType.OSC].ShouldBeTrue();
            matchCollections2[VtSequenceType.OSC].ShouldBeTrue();
            matchCollections3[VtSequenceType.OSC].ShouldBeTrue();
        }

        /// <summary>
        /// Tests checking to see if the string contains the PM sequences
        /// </summary>
        [Test]
        public void TestIsMatchSpecificPMSequences()
        {
            char StringTerminator = Convert.ToChar(0x9c);
            char EscapeChar = Convert.ToChar(0x1b);
            string vtSequence1 = $"{EscapeChar}^Kermit{StringTerminator}";
            VtSequenceType requestedType = VtSequenceType.PM;
            var matchCollections1 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hello!{vtSequence1}", requestedType);
            var matchCollections2 = VtSequenceTools.IsMatchVTSequencesSpecific($"Hel{vtSequence1}lo!", requestedType);
            var matchCollections3 = VtSequenceTools.IsMatchVTSequencesSpecific($"{vtSequence1}Hello!", requestedType);
            matchCollections1.ShouldNotBeEmpty();
            matchCollections2.ShouldNotBeEmpty();
            matchCollections3.ShouldNotBeEmpty();
            matchCollections1[VtSequenceType.PM].ShouldBeTrue();
            matchCollections2[VtSequenceType.PM].ShouldBeTrue();
            matchCollections3[VtSequenceType.PM].ShouldBeTrue();
        }

        /// <summary>
        /// Tests determining the VT sequence type from the given text
        /// </summary>
        [Test]
        public void TestDetermineTypeFromText()
        {
            char BellChar = Convert.ToChar(0x7);
            char EscapeChar = Convert.ToChar(0x1b);
            char StringTerminator = Convert.ToChar(0x9c);
            string vtSequence1 = $"{EscapeChar}[38;5;43m";
            string vtSequence2 = $"{EscapeChar}_1{StringTerminator}";
            string vtSequence3 = $"{EscapeChar}]0;Hi!{BellChar}";
            VtSequenceTools.DetermineTypeFromText($"Hello!{vtSequence1}").ShouldBe(VtSequenceType.CSI);
            VtSequenceTools.DetermineTypeFromText($"Hel{vtSequence2}lo!").ShouldBe(VtSequenceType.APC);
            VtSequenceTools.DetermineTypeFromText($"{vtSequence3}Hello!").ShouldBe(VtSequenceType.OSC);
            VtSequenceTools.DetermineTypeFromText($"Hello!").ShouldBe(VtSequenceType.None);
        }
    }
}