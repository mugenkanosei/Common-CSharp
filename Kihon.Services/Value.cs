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

namespace Kihon.Services
{
    using System;
    using System.Text;

    /// <summary>
    /// This class is a generic class template for all value classes.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public abstract class Value<T> where T : class
    {
        /// <summary>
        /// Compares the object on the left with the <see cref="Value"/> on the right for value equality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="System.Object"/>
        /// The first object to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="Value"/>
        /// The second value to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the leftSide and rightSide have value equality; otherwise, false.
        /// </returns>
        public static bool operator ==(object leftSide, Value<T> rightSide)
        {
            return leftSide as Value<T> == rightSide;
        }

        /// <summary>
        /// Compares the object on the left with the <see cref="Value"/> on the right for value inequality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="System.Object"/>
        /// The first object to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="Value"/>
        /// The second value to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the leftSide and rightSide do not have value equality; otherwise, false.
        /// </returns>
        public static bool operator !=(object leftSide, Value<T> rightSide)
        {
            return !(leftSide as Value<T> == rightSide);
        }

        /// <summary>
        /// Compares the <see cref="Value"/> on the left with the object on the right for value equality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="Value"/>
        /// The first value to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="System.Object"/>
        /// The second object to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the leftSide and rightSide have value equality; otherwise, false.
        /// </returns>
        public static bool operator ==(Value<T> leftSide, object rightSide)
        {
            return leftSide == rightSide as Value<T>;
        }

        /// <summary>
        /// Compares the <see cref="Value"/> on the left with the object on the right for value inequality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="Value"/>
        /// The first value to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="System.Object"/>
        /// The second object to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the leftSide and rightSide do not have value equality; otherwise, false.
        /// </returns>
        public static bool operator !=(Value<T> leftSide, object rightSide)
        {
            return !(leftSide == rightSide as Value<T>);
        }

        /// <summary>
        /// Compares the <see cref="Value"/> on the left with the <see cref="Value"/> on the right for value equality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="Value"/>
        /// The first value to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="Value"/>
        /// The second value to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the leftSide and rightSide have value equality; otherwise, false.
        /// </returns>
        public static bool operator ==(Value<T> leftSide, Value<T> rightSide)
        {
            if (System.Object.ReferenceEquals(leftSide, rightSide))
            {
                return true;
            }

            if (((object)leftSide == null) || ((object)rightSide == null))
            {
                return false;
            }

            return leftSide.CompareEquality(rightSide as T);
        }

        /// <summary>
        /// Compares the <see cref="Value"/> on the left with the <see cref="Value"/> on the right for value inequality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="Value"/>
        /// The first value to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="Value"/>
        /// The second value to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the leftSide and rightSide do not have value equality; otherwise, false.
        /// </returns>
        public static bool operator !=(Value<T> leftSide, Value<T> rightSide)
        {
            return !(leftSide == rightSide);
        }

        /// <summary>
        /// Compares the referenced <see cref="System.Object"/> with the <see cref="Value"/> for value equality.
        /// </summary>
        /// <param name="obj">
        /// Type: <see cref="System.Object"/>
        /// The object to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the referenced object is equal in value.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == obj as Value<T>;
        }

        /// <summary>
        /// Compares the referenced <see cref="Identity"/> with the <see cref="Identity"/> for value equality.
        /// </summary>
        /// <param name="value">
        /// Type: <see cref="Value"/>
        /// The identity to compare, or null
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the referenced value is equal in value.
        /// </returns>
        public bool Equals(Value<T> value)
        {
            return this == value;
        }

        /// <summary>
        /// Returns an integer hash code for the value.
        /// </summary>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// Returns the same integer hash for two value instances that are equal in both type and value.
        /// </returns>
        public override int GetHashCode()
        {
            string typeName = this.GetType().Name;

            byte[] data = Encoding.ASCII.GetBytes(typeName + ValueStateAsString());

            byte[] hashCode = MurmurHash3.ComputeHash32(data, 0);

            return BitConverter.ToInt32(hashCode, 0);
        }


        protected abstract bool CompareEquality(T obj);

        protected abstract string ValueStateAsString();
    }
}
