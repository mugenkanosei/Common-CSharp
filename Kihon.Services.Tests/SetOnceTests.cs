using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kihon.Services;
using NUnit.Framework;
using Moq;

namespace Kihon.Services.Tests
{
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
