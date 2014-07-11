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
        public void EqualityOperator_Should_Return_True_If_The_Left_Identity_And_Right_Identity_Sides_Are_Null()
        {
            // given
            IdentityConcrete leftNull = null;
            IdentityConcrete rightNull = null;

            // then
            Assert.AreEqual(true, leftNull == rightNull, "leftNull is not equal to rightNull");
            Assert.AreEqual(true, rightNull == leftNull, "rightNull is not equal to leftNull");
        }

        [Test]
        public void EqualityOperator_Should_Return_False_If_One_Side_Is_Null_And_The_Other_Is_Not_Null()
        {
            // then
            Assert.AreEqual(false, sut == null, "SUT is equal to null and should not");
            Assert.AreEqual(false, null == sut, "null is equal to SUT and should not");
        }

        [Test]
        public void EqualityOperator_Should_Return_False_If_The_Left_Identity_And_Right_Identity_Sides_Are_Not_Equal()
        {
            // given
            IdentityConcrete left = new IdentityConcrete("1");
            IdentityConcrete right = new IdentityConcrete("2");

            // then
            Assert.AreEqual(false, left == right, "left is equal to the right and should not");
            Assert.AreEqual(false, right == left, "right is equal to the left and should not");
        }

        [Test]
        public void EqualityOperator_Should_Return_True_If_The_Left_Identity_And_Right_Identity_Sides_Are_Equal()
        {
            // given
            IdentityConcrete identity1 = new IdentityConcrete("1");
            IdentityConcrete identity2 = new IdentityConcrete("1");
            object identity3 = new IdentityConcrete("1");
            IdentityConcrete identity1Copy = identity1;
            

            // then
            Assert.AreEqual(true, identity1 == identity1Copy, "identity1 is not equal to identity1Copy");
            Assert.AreEqual(true, identity1Copy == identity1, "identity1Copy is not equal to identity1");
            Assert.AreEqual(true, identity1 == identity2, "identity1 is not equal to identity2");
            Assert.AreEqual(true, identity2 == identity1, "identity2 is not equal to identity1");
            Assert.AreEqual(true, identity1 == identity3, "identity1 is not equal to identity3");
            Assert.AreEqual(true, identity3 == identity1, "identity3 is not equal to identity1");
        }

        [Test]
        public void EqualityOperator_Should_Return_False_If_One_Side_Is_Not_Derived_From_Identity()
        {
            // given
            object stringObject = "Test" as object;

            // then
            Assert.AreEqual(false, sut == stringObject, "sut is equal to stringObject");
            Assert.AreEqual(false, stringObject == sut, "stringObject is equal to sut");
        }

        [Test]
        public void InequalityOperator_Should_Return_False_If_The_Left_Identity_And_Right_Identity_Sides_Are_Null()
        {
            // given
            IdentityConcrete leftNull = null;
            IdentityConcrete rightNull = null;

            // then
            Assert.AreEqual(false, leftNull != rightNull, "leftNull is equal to rightNull");
            Assert.AreEqual(false, rightNull != leftNull, "rightNull is equal to leftNull");
        }

        [Test]
        public void InequalityOperator_Should_Return_True_If_One_Side_Is_Null_And_The_Other_Is_Not_Null()
        {
            // then
            Assert.AreEqual(true, sut != null, "SUT is not equal to null and should be");
            Assert.AreEqual(true, null != sut, "null is not equal to SUT and should be");
        }
        
        [Test]
        public void InequalityOperator_Should_Return_True_If_The_Left_Identity_And_Right_Identity_Sides_Are_Not_Equal()
        {
            // given
            IdentityConcrete left = new IdentityConcrete("1");
            IdentityConcrete right = new IdentityConcrete("2");

            // then
            Assert.AreEqual(true, left != right, "left is equal to the right and should not");
            Assert.AreEqual(true, right != left, "right is equal to the left and should not");
        }
        
        [Test]
        public void InequalityOperator_Should_Return_False_If_The_Left_Identity_And_Right_Identity_Sides_Are_Equal()
        {
            // given
            IdentityConcrete identity1 = new IdentityConcrete("1");
            IdentityConcrete identity2 = new IdentityConcrete("1");
            object identity3 = new IdentityConcrete("1");
            IdentityConcrete identity1Copy = identity1;

            // then
            Assert.AreEqual(false, identity1 != identity1Copy, "identity1 is equal to identity1Copy");
            Assert.AreEqual(false, identity1Copy != identity1, "identity1Copy is equal to identity1");
            Assert.AreEqual(false, identity1 != identity2, "identity1 is equal to identity2");
            Assert.AreEqual(false, identity2 != identity1, "identity2 is equal to identity1");
            Assert.AreEqual(false, identity1 != identity3, "identity1 is equal to identity3");
            Assert.AreEqual(false, identity3 != identity1, "identity3 is equal to identity1");
        }
        
        [Test]
        public void InequalityOperator_Should_Return_True_If_One_Side_Is_Not_Derived_From_Identity()
        {
            // given
            object stringObject = "Test" as object;

            // then
            Assert.AreEqual(true, sut != stringObject, "sut is equal to stringObject");
            Assert.AreEqual(true, stringObject != sut, "stringObject is equal to sut");
        }

        [Test]
        public void Equals_Should_Return_False_If_The_Parameter_Is_Null()
        {
            // given
            IdentityConcrete nullId = null;

            // when
            bool result = sut.Equals(nullId);

            // then
            Assert.AreEqual(false, result);
        }
        
        [Test]
        public void Equals_Should_Return_False_If_The_Two_Identities_Are_Not_Equal()
        {
            // given
            IdentityConcrete identity1 = new IdentityConcrete("1");
            IdentityConcrete identity2 = new IdentityConcrete("2");

            // then
            Assert.AreEqual(false, identity1.Equals(identity2), "left is equal to the right and should not");
            Assert.AreEqual(false, identity2.Equals(identity1), "right is equal to the left and should not");
        }
        
        [Test]
        public void Equals_Should_Return_True_If_The_Two_Identities_Are_Equal()
        {
            // given
            IdentityConcrete identity1 = new IdentityConcrete("1");
            IdentityConcrete identity2 = new IdentityConcrete("1");
            object identity3 = new IdentityConcrete("1");
            IdentityConcrete identity1Copy = identity1;

            // then
            Assert.AreEqual(true, identity1.Equals(identity1Copy), "identity1 is not equal to identity1Copy");
            Assert.AreEqual(true, identity1Copy.Equals(identity1), "identity1Copy is not equal to identity1");
            Assert.AreEqual(true, identity1.Equals(identity2), "identity1 is not equal to identity2");
            Assert.AreEqual(true, identity2.Equals(identity1), "identity2 is not equal to identity1");
            Assert.AreEqual(true, identity1.Equals(identity3), "identity1 is not equal to identity3");
            Assert.AreEqual(true, identity3.Equals(identity1), "identity3 is not equal to identity1");
        }

        [Test]
        public void Equals_Should_Return_False_If_The_Parameter_Is_Not_Derived_From_Identity()
        {
            // given
            object stringObject = "Test" as object;

            // then
            Assert.AreEqual(false, sut.Equals(stringObject), "sut is equal to stringObject");
        }

        [Test]
        public void GetHashCode_Should_Return_The_Same_Integer_For_Identities_With_The_Same_Value()
        {
            // given
            IdentityConcrete id1 = new IdentityConcrete("1");
            IdentityConcrete id2 = new IdentityConcrete("1");

            // when
            int id1HashCode = id1.GetHashCode();
            int id2HashCode = id2.GetHashCode();

            // then
            Assert.AreEqual(id1HashCode, id2HashCode);
        }

        [Test]
        public void GetHashCode_Should_Return_A_Different_Integer_For_Identities_With_Different_Values()
        {
            // given
            IdentityConcrete id1 = new IdentityConcrete("1");
            IdentityConcrete id2 = new IdentityConcrete("2");

            // when
            int id1HashCode = id1.GetHashCode();
            int id2HashCode = id2.GetHashCode();

            // then
            Assert.AreNotEqual(id1HashCode, id2HashCode);
        }

        [Test]
        public void GetHashCode_Should_Return_A_Different_Integer_For_Different_Identities_With_The_Same_Value()
        {
            // given
            IdentityConcrete id1 = new IdentityConcrete("1");
            IdentityConcreteTwo id2 = new IdentityConcreteTwo("1");

            // when
            int id1HashCode = id1.GetHashCode();
            int id2HashCode = id2.GetHashCode();

            // then
            Assert.AreNotEqual(id1HashCode, id2HashCode);
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
            public IdentityConcrete(string anIdentityString) : base(anIdentityString) {}
        }

        public class IdentityConcreteTwo : Identity<IdentityConcreteTwo>
        {
            public IdentityConcreteTwo(string blah) : base(blah) { }
        }
    }
}
