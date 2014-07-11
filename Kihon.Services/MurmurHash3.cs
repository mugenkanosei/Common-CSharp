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

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MurmurHash3
    {
        /// <summary>
        /// Static method that computes the 32bit hash for the provided byte array.
        /// </summary>
        /// <param name="key">
        /// An array of bytes to be hashed.
        /// </param>
        /// <param name="seed">
        /// An optional seed value to see the hash. If no value is provided, seed defaults to 0.
        /// </param>
        /// <returns>
        /// Returns a four element byte array of the hash value.
        /// </returns>
        public static byte[] ComputeHash32(byte[] key, uint seed = 0)
        {
            return ComputeHash32(key, (uint)key.Length, seed);
        }

        /// <summary>
        /// Static method that computes the 32bit hash for the provided byte array.
        /// </summary>
        /// <param name="key">
        /// An array of bytes to be hashed.
        /// </param>
        /// <param name="length">
        /// The length of the byte array.
        /// </param>
        /// <param name="seed">
        /// An optional seed value to see the hash. If no value is provided, seed defaults to 0.
        /// </param>
        /// <returns>
        /// Returns a four element byte array of the hash value.
        /// </returns>
        public static byte[] ComputeHash32(byte[] key, uint length, uint seed = 0)
        {
            const uint C1 = 0xcc9e2d51;
            const uint C2 = 0x1b873593;
            const int R1 = 15;
            const int R2 = 13;
            const uint M = 5;
            const uint N = 0xe6546b64;

            uint hash = seed;

            uint readsize = 4;

            uint blocks = length / readsize;

            for (int i = 0; i < blocks; i++)
            {
                uint k = BitConverter.ToUInt32(key, i * 4);

                k *= C1;
                k = ROTL32(k, R1);
                k *= C2;

                hash = hash ^ k;
                hash = ROTL32(hash, R2);
                hash = (hash * M) + N;
            }

            uint k1 = 0;

            switch (length & 3)
            {
                case 3:
                    k1 ^= (uint)key[(blocks * 4) + 2] << 16;
                    goto case 2;
                case 2:
                    k1 ^= (uint)key[(blocks * 4) + 1] << 8;
                    goto case 1;
                case 1:
                    k1 ^= (uint)key[blocks * 4];
                    k1 = k1 * C1;
                    k1 = ROTL32(k1, R1);
                    k1 = k1 * C2;
                    hash = hash ^ k1;
                    break;
            }

            hash = hash ^ length;
            hash = hash ^ (hash >> 16);
            hash *= 0x85ebca6b;
            hash ^= hash >> 13;
            hash *= 0xc2b2ae35;
            hash ^= hash >> 16;

            return BitConverter.GetBytes(hash);
        }

        /// <summary>
        /// Performs a circular shift.
        /// </summary>
        /// <param name="integerToShift">
        /// Type: <see cref="System.UInt32"/>
        /// The unsigned integer to shift
        /// </param>
        /// <param name="bitsToShiftBy">
        /// Type: <see cref="System.Int32"/>
        /// The number of bits to shift by.
        /// </param>
        /// <returns>
        /// Type: <see cref="System.UInt32"/>
        /// Returns the input shifted by the specified bytes.
        /// </returns>
        private static uint ROTL32(uint integerToShift, int bitsToShiftBy)
        {
            return (integerToShift << bitsToShiftBy) | (integerToShift >> (32 - bitsToShiftBy));
        }
    }
}
