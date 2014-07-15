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
    public class IdentityTests
    {
        IdentityConcrete sut;
        string identityString;

        [SetUp]
        public void Init()
        {
            identityString = Guid.NewGuid().ToString();
            sut = new IdentityConcrete(identityString);
        }

        [TearDown]
        public void Dealloc()
        {
            sut = null;
            identityString = null;
        }

        [Test]
        [TestCase("1")]
        [TestCase("2")]
        public void Value_Should_Return_The_Identity_As_A_String(string identityString)
        {
            // given
            sut = new IdentityConcrete(identityString);

            // when
            string result = sut.Value;

            // then
            Assert.AreEqual(identityString, result);
        }

        [Test]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void Identity_Should_Not_Accept_A_Blank_IdentityString()
        {
            // given
            IdentityConcrete id = new IdentityConcrete("");
        }

        public class IdentityConcrete : Identity<IdentityConcrete>
        {
            public IdentityConcrete(string anIdentityString) : base(anIdentityString) { }
        }
    }
}
