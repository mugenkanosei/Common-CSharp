using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using Kihon.Services;

namespace Kihon.Services.Tests
{
    class ValueTests
    {
        ValueConcreteOne sut;
        string valueState;

        [SetUp]
        public void Init()
        {
            valueState = Guid.NewGuid().ToString();
            sut = new ValueConcreteOne(valueState);
        }

        [TearDown]
        public void Dealloc()
        {
            sut = null;
            valueState = null;
        }

        [Test]
        public void EqualityOperator_Should_Return_True_If_The_Left_Value_And_Right_Value_Sides_Are_Null()
        {
            // given
            ValueConcreteOne leftNull = null;
            ValueConcreteOne rightNull = null;

            // then
            Assert.IsTrue(leftNull == rightNull, "leftNull is not equal to rightNull");
            Assert.IsTrue(rightNull == leftNull, "rightNull is not equal to leftNull");
        }
        
        [Test]
        public void EqualityOperator_Should_Return_False_If_One_Side_Is_Null_And_The_Other_Is_Not_Null()
        {
            // then
            Assert.IsFalse(sut == null, "SUT is equal to null and should not");
            Assert.IsFalse(null == sut, "null is equal to SUT and should not");
        }
        
        [Test]
        public void EqualityOperator_Should_Return_False_If_The_Left_Value_And_Right_Value_Sides_Are_Not_Equal()
        {
            // given
            ValueConcreteOne left = new ValueConcreteOne("1");
            ValueConcreteOne right = new ValueConcreteOne("2");

            // then
            Assert.IsFalse(left == right, "left is equal to the right and should not");
            Assert.IsFalse(right == left, "right is equal to the left and should not");
        }
        
        [Test]
        public void EqualityOperator_Should_Return_True_If_The_Left_Value_And_Right_Value_Sides_Are_Equal()
        {
            // given
            ValueConcreteOne value1 = new ValueConcreteOne("1");
            ValueConcreteOne value2 = new ValueConcreteOne("1");
            object value3 = new ValueConcreteOne("1");
            ValueConcreteOne value1Copy = value1;


            // then
            Assert.IsTrue(value1 == value1Copy, "value1 is not equal to value1Copy");
            Assert.IsTrue(value1Copy == value1, "value1Copy is not equal to identity1");
            Assert.IsTrue(value1 == value2, "value1 is not equal to value2");
            Assert.IsTrue(value2 == value1, "value2 is not equal to value1");
            Assert.IsTrue(value1 == value3, "value1 is not equal to value3");
            Assert.IsTrue(value3 == value1, "value3 is not equal to value1");
        }
        
        [Test]
        public void EqualityOperator_Should_Return_False_If_One_Side_Is_Not_The_Same_Type()
        {
            // given
            object stringObject = "Test" as object;

            // then
            Assert.IsFalse(sut == stringObject, "sut is equal to stringObject");
            Assert.IsFalse(stringObject == sut, "stringObject is equal to sut");
        }
        
        [Test]
        public void InequalityOperator_Should_Return_False_If_The_Left_Value_And_Right_Value_Sides_Are_Null()
        {
            // given
            ValueConcreteOne leftNull = null;
            ValueConcreteOne rightNull = null;

            // then
            Assert.IsFalse(leftNull != rightNull, "leftNull is equal to rightNull");
            Assert.IsFalse(rightNull != leftNull, "rightNull is equal to leftNull");
        }
        
        [Test]
        public void InequalityOperator_Should_Return_True_If_One_Side_Is_Null_And_The_Other_Is_Not_Null()
        {
            // then
            Assert.AreEqual(true, sut != null, "SUT is not equal to null and should be");
            Assert.AreEqual(true, null != sut, "null is not equal to SUT and should be");
        }

        [Test]
        public void InequalityOperator_Should_Return_True_If_The_Left_Value_And_Right_Value_Sides_Are_Not_Equal()
        {
            // given
            ValueConcreteOne left = new ValueConcreteOne("1");
            ValueConcreteOne right = new ValueConcreteOne("2");

            // then
            Assert.IsTrue(left != right, "left is equal to the right and should not");
            Assert.IsTrue(right != left, "right is equal to the left and should not");
        }

        [Test]
        public void InequalityOperator_Should_Return_False_If_The_Left_Value_And_Right_Value_Sides_Are_Equal()
        {
            // given
            ValueConcreteOne value1 = new ValueConcreteOne("1");
            ValueConcreteOne value2 = new ValueConcreteOne("1");
            object value3 = new ValueConcreteOne("1");
            ValueConcreteOne value1Copy = value1;

            // then
            Assert.IsFalse(value1 != value1Copy, "value1 is equal to value1Copy");
            Assert.IsFalse(value1Copy != value1, "value1Copy is equal to value1");
            Assert.IsFalse(value1 != value2, "value1 is equal to value2");
            Assert.IsFalse(value2 != value1, "value2 is equal to value1");
            Assert.IsFalse(value1 != value3, "value1 is equal to value3");
            Assert.IsFalse(value3 != value1, "value3 is equal to value1");
        }

        [Test]
        public void InequalityOperator_Should_Return_True_If_One_Side_Is_Not_The_Same_Type()
        {
            // given
            object stringObject = "Test" as object;

            // then
            Assert.IsTrue(sut != stringObject, "sut is equal to stringObject");
            Assert.IsTrue(stringObject != sut, "stringObject is equal to sut");
        }

        [Test]
        public void Equals_Should_Return_False_If_The_Parameter_Is_Null()
        {
            // given
            ValueConcreteOne nullId = null;

            // when
            bool result = sut.Equals(nullId);

            // then
            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_Should_Return_False_If_The_Two_Values_Are_Not_Equal()
        {
            // given
            ValueConcreteOne value1 = new ValueConcreteOne("1");
            ValueConcreteOne value2 = new ValueConcreteOne("2");

            // then
            Assert.IsFalse(value1.Equals(value2), "left is equal to the right and should not");
            Assert.IsFalse(value2.Equals(value1), "right is equal to the left and should not");
        }

        [Test]
        public void Equals_Should_Return_True_If_The_Two_Values_Are_Equal()
        {
            // given
            ValueConcreteOne value1 = new ValueConcreteOne("1");
            ValueConcreteOne value2 = new ValueConcreteOne("1");
            object value3 = new ValueConcreteOne("1");
            ValueConcreteOne value1Copy = value1;

            // then
            Assert.IsTrue(value1.Equals(value1Copy), "value1 is not equal to value1Copy");
            Assert.IsTrue(value1Copy.Equals(value1), "value1Copy is not equal to value1");
            Assert.IsTrue(value1.Equals(value2), "value1 is not equal to value2");
            Assert.IsTrue(value2.Equals(value1), "value2 is not equal to value1");
            Assert.IsTrue(value1.Equals(value3), "value1 is not equal to value3");
            Assert.IsTrue(value3.Equals(value1), "value3 is not equal to value1");
        }

        [Test]
        public void Equals_Should_Return_False_If_The_Parameter_Is_Not_The_Same_Type()
        {
            // given
            object stringObject = "Test" as object;

            // then
            Assert.IsFalse(sut.Equals(stringObject), "sut is equal to stringObject");
        }

        [Test]
        public void GetHashCode_Should_Return_The_Same_Integer_For_Values_With_The_Same_Value_Equality()
        {
            // given
            ValueConcreteOne value1 = new ValueConcreteOne("1");
            ValueConcreteOne value2 = new ValueConcreteOne("1");

            // when
            int value1HashCode = value1.GetHashCode();
            int value2HashCode = value2.GetHashCode();

            // then
            Assert.AreEqual(value1HashCode, value2HashCode);
        }

        [Test]
        public void GetHashCode_Should_Return_A_Different_Integer_For_Values_With_Different_Value_Equality()
        {
            // given
            ValueConcreteOne value1 = new ValueConcreteOne("1");
            ValueConcreteOne value2 = new ValueConcreteOne("2");

            // when
            int value1HashCode = value1.GetHashCode();
            int value2HashCode = value2.GetHashCode();

            // then
            Assert.AreNotEqual(value1HashCode, value2HashCode);
        }

        [Test]
        public void GetHashCode_Should_Return_A_Different_Integer_For_Different_Values_With_The_Same_Value_Equality()
        {
            // given
            ValueConcreteOne value1 = new ValueConcreteOne("1");
            ValueConcreteTwo value2 = new ValueConcreteTwo("1");

            // when
            int value1HashCode = value1.GetHashCode();
            int value2HashCode = value2.GetHashCode();

            // then
            Assert.AreNotEqual(value1HashCode, value2HashCode);
        }

        public class ValueConcreteOne : Value<ValueConcreteOne>
        {
            private string myVariable;

            public ValueConcreteOne(string var)
            {
                myVariable = var;
            }

            protected override bool CompareEquality(ValueConcreteOne obj)
            {
                
                return myVariable == obj.myVariable;
            }

            protected override string ValueStateAsString()
            {
                return myVariable;
            }
        }

        public class ValueConcreteTwo : Value<ValueConcreteTwo>
        {
            private string myVariable;

            public ValueConcreteTwo(string var)
            {
                myVariable = var;
            }

            protected override bool CompareEquality(ValueConcreteTwo obj)
            {
                return myVariable == obj.myVariable;
            }

            protected override string ValueStateAsString()
            {
                return myVariable;
            }
        }

    }
}
