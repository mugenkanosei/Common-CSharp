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
    /// This class is a generic class template for all EntityId classes.
    /// </summary>
    /// <typeparam name="T">The identity type.</typeparam>
    public class Identity<T>
    {
        /// <summary>
        /// Backing field used by the Value property.
        /// </summary>
        private string valueStore;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Identity{T}" /> class. 
        /// </summary>
        /// <param name="anIdentityString">
        /// A string representation of the identity.
        /// </param>
        public Identity(string anIdentityString)
        {
            this.Value = anIdentityString;
        }

        /// <summary>
        /// Gets the ID as a string.
        /// </summary>
        public string Value
        {
            get
            {
                return valueStore;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new System.ArgumentNullException();
                }

                valueStore = value;
            }
        }

        /// <summary>
        /// Compares the object on the left with the <see cref="Identity"/> on the right for value equality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="System.Object"/>
        /// The first object to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="Identity"/>
        /// The second identity to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the value of leftSide is the same as the value of rightSide; otherwise, false.
        /// </returns>
        public static bool operator ==(object leftSide, Identity<T> rightSide)
        {
            return leftSide as Identity<T> == rightSide;
        }

        /// <summary>
        /// Compares the object on the left with the <see cref="Identity"/> on the right for value inequality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="System.Object"/>
        /// The first object to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="Identity"/>
        /// The second identity to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the value of leftSide is different from the value of rightSide; otherwise, false.
        /// </returns>
        public static bool operator !=(object leftSide, Identity<T> rightSide)
        {
            return !(leftSide as Identity<T> == rightSide);
        }

        /// <summary>
        /// Compares the <see cref="Identity"/> on the left with the object on the right for value equality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="Identity"/>
        /// The first identity to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="System.Object"/>
        /// The second object to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the value of leftSide is the same as the value of rightSide; otherwise, false.
        /// </returns>
        public static bool operator ==(Identity<T> leftSide, object rightSide)
        {
            return leftSide == rightSide as Identity<T>;
        }

        /// <summary>
        /// Compares the <see cref="Identity"/> on the left with the object on the right for value inequality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="Identity"/>
        /// The first identity to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="System.Object"/>
        /// The second object to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the value of leftSide is different from the value of rightSide; otherwise, false.
        /// </returns>
        public static bool operator !=(Identity<T> leftSide, object rightSide)
        {
            return !(leftSide == rightSide as Identity<T>);
        }

        /// <summary>
        /// Compares the <see cref="Identity"/> on the left with the <see cref="Identity"/> on the right for value equality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="Identity"/>
        /// The first identity to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="Identity"/>
        /// The second identity to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the value of leftSide is the same as the value of rightSide; otherwise, false.
        /// </returns>
        public static bool operator ==(Identity<T> leftSide, Identity<T> rightSide)
        {
            if (object.ReferenceEquals(leftSide, rightSide))
            {
                return true;
            }

            if (((object)leftSide == null) || ((object)rightSide == null))
            {
                return false;
            }

            return leftSide.Value == rightSide.Value;
        }

        /// <summary>
        /// Compares the <see cref="Identity"/> on the left with the <see cref="Identity"/> on the right for value inequality.
        /// </summary>
        /// <param name="leftSide">
        /// Type: <see cref="Identity"/>
        /// The first identity to compare, or null.
        /// </param>
        /// <param name="rightSide">
        /// Type: <see cref="Identity"/>
        /// The second identity to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the value of leftSide is different from the value of rightSide; otherwise, false.
        /// </returns>
        public static bool operator !=(Identity<T> leftSide, Identity<T> rightSide)
        {
            return !(leftSide == rightSide);
        }

        /// <summary>
        /// Compares the referenced <see cref="System.Object"/> with the <see cref="Identity"/> for value equality.
        /// </summary>
        /// <param name="obj">
        /// Type: <see cref="System.Object"/>
        /// The object to compare, or null.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the referenced object is equal in value to this identity.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == obj as Identity<T>;
        }

        /// <summary>
        /// Compares the referenced <see cref="Identity"/> with the <see cref="Identity"/> for value equality.
        /// </summary>
        /// <param name="anIdentity">
        /// Type: <see cref="Identity"/>
        /// The identity to compare, or null
        /// </param>
        /// <returns>
        /// Type: <see cref="System.Boolean"/>
        /// <c>true</c> if the referenced identity is equal in value to this identity.
        /// </returns>
        public bool Equals(Identity<T> anIdentity)
        {
            return this == anIdentity;
        }

        /// <summary>
        /// Returns an integer hash code for the identity.
        /// </summary>
        /// <returns>
        /// Type: <see cref="System.Int32"/>
        /// Returns the same integer hash for two identity instances that are equal in both type and value.
        /// </returns>
        public override int GetHashCode()
        {
            string typeName = this.GetType().Name;
            string value = this.Value;

            byte[] data = Encoding.ASCII.GetBytes(typeName + value);

            byte[] hashCode = MurmurHash3.ComputeHash32(data, 0);

            return BitConverter.ToInt32(hashCode, 0);
        }
    }
}
