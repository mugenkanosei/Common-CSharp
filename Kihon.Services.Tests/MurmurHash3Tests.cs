// The MIT License (MIT)
//
// Copyright (c) 2014 mugenkanosei
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace Kihon.Services.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Moq;
    using Kihon.Services;

    [TestFixture]
    public class MurmurHash3Tests
    {
        [Test]
        public void ComputeHash32_Should_Return_The_Correct_Hash()
        {
            byte[] key = new byte[256];
            byte[] hashes = new byte[4*256];
            byte[] final;


            for (uint i = 0; i < 256; i++)
            {
                key[i] = (byte)i;

                byte[] results = MurmurHash3.ComputeHash32(key, i, 256U-i);
                hashes[i * 4] = results[0];
                hashes[i * 4 + 1] = results[1];
                hashes[i * 4 + 2] = results[2];
                hashes[i * 4 + 3] = results[3];
            }

            final = MurmurHash3.ComputeHash32(hashes, 0);

            uint result = 0;
            result ^= (uint)final[3] << 24;
            result ^= (uint)final[2] << 16;
            result ^= (uint)final[1] << 8;
            result ^= (uint)final[0];


            Assert.AreEqual(0xB0F57EE3, result);
        }
    }
}
