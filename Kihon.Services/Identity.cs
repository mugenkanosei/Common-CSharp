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
    public class Identity<T> : Value<Identity<T>>
    {
        /// <summary>
        /// Backing field used by the Value property.
        /// </summary>
        private readonly SetOnce<string> valueStore = new SetOnce<string>("valueStore");

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
                    throw new System.ArgumentNullException("Identity cannot be empty or null.");
                }

                valueStore.Value = value;
            }
        }

        protected override bool CompareEquality(Identity<T> obj)
        {
            return this.Value == obj.Value;
        }

        protected override string ValueStateAsString()
        {
            return this.Value;
        }
    }
}
