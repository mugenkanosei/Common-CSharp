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
    using Kihon.Services;
    using NUnit.Framework;
    using Moq;

    [TestFixture]
    class SetOnceTests
    {
        [Test]
        public void Value_Can_Be_Set()
        {
            // given
            SetOnce<int> sut = new SetOnce<int>("sut");

            // when
            sut.Value = 1;

            // then
            Assert.AreEqual(1, sut);
        }

        [Test]
        public void Value_Can_Be_Changed_From_Default_Value()
        {
            // given
            SetOnce<int> sut = new SetOnce<int>("sut", 1);
            Assert.AreEqual(1, sut);

            // when
            sut.Value = 2;

            // then
            Assert.AreEqual(2, sut);
        }

        [Test]
        [ExpectedException(typeof(AlreadySetException), ExpectedMessage = "The value \"sut\" has already been set.")]
        public void Value_Can_Not_Be_Set_Twice()
        {
            // given
            SetOnce<int> sut = new SetOnce<int>("sut");
            sut.Value = 1;
            Assert.AreEqual(1, sut);

            // when
            sut.Value = 2;
        }

        [Test]
        [ExpectedException(typeof(AlreadySetException), ExpectedMessage = "The value \"sut\" has already been set.")]
        public void Value_Can_Not_Be_Set_Twice_From_Default_Value()
        {
            // given
            SetOnce<int> sut = new SetOnce<int>("sut", 1);
            Assert.AreEqual(1, sut);
            sut.Value = 2;
            Assert.AreEqual(2, sut);

            // when
            sut.Value = 3;
        }

        [Test]
        [ExpectedException(typeof(ValueNotSetException))]
        public void Throw_An_Execption_When_Getting_An_Empty_Value()
        {
            // given
            SetOnce<int> sut = new SetOnce<int>("sut");

            // when
            int result = sut;
            Console.WriteLine(result);
        }
    }
}
