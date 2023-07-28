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

namespace VT.NET.Builder
{
    /// <summary>
    /// VT sequence builder tools
    /// </summary>
    public static class VtSequenceBuilderTools
    {
        /// <summary>
        /// Builds a VT sequence using specific types
        /// </summary>
        /// <param name="specificType"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string BuildVtSequence(VtSequenceSpecificTypes specificType, params object[] arguments)
        {
            string result;

            // Check the type
            if (!Enum.IsDefined(typeof(VtSequenceSpecificTypes), specificType))
                throw new Exception($"Cannot build VT sequence for nonexistent type {Convert.ToInt32(specificType)}");

            // Now, get the method and the sequence regex using reflection
            var regexGettingType = new Regex("(?<=[a-z0-9])[A-Z].*");
            string typeName = $"{regexGettingType.Replace(specificType.ToString(), "")}Sequences";
            string generatorName = $"Generate{specificType}";
            var sequencesType = Type.GetType($"VT.NET.Builder.Types.{typeName}");
            var sequenceRegexGenerator = sequencesType.GetMethod(generatorName);

            // Now, get the sequence
            result = sequenceRegexGenerator.Invoke(null, arguments).ToString();
            return result;
        }
    }
}
