using System;
using System.Collections.Generic;
using System.Linq;

namespace MMR.Randomizer.Utils
{
    //-------------------------------------------------------------//

    // https://www.stum.de/2008/10/20/base36-encoderdecoder-in-c/
    // Edit: Slightly updated on 2011-03-29

    /// <summary>
    /// A Base36 De- and Encoder
    /// </summary>
    public static class Base36Utils
    {
        private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// Encode the given number into a Base36 string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static String Encode(long input)
        {
            if (input < 0) throw new ArgumentOutOfRangeException("input", input, "input cannot be negative");

            char[] clistarr = CharList.ToCharArray();
            var result = new Stack<char>();
            while (input != 0)
            {
                result.Push(clistarr[input % 36]);
                input /= 36;
            }
            return new string(result.ToArray());
        }

        /// <summary>
        /// Encode the given sequence of bytes into a Base36 string.
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <param name="sep">Separator character</param>
        /// <returns>String</returns>
        public static String EncodeBytes(byte[] bytes, char sep = '-')
        {
            var ints = ConvertUtils.BytesToIntArray(bytes);
            return EncodeIntArray(ints, sep);
        }

        /// <summary>
        /// Encode the given sequence of integers into a Base36 string.
        /// </summary>
        /// <param name="ints">Integers</param>
        /// <param name="sep">Separator character</param>
        /// <returns>String</returns>
        public static String EncodeIntArray(int[] ints, char sep = '-')
        {
            var partsEncoded = ints.Select(p => Base36Utils.Encode((uint)p)).ToArray();
            return string.Join(sep.ToString(), partsEncoded);
        }

        /// <summary>
        /// Decode the Base36 Encoded string into a number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Int64 Decode(string input)
        {
            var reversed = input.ToLower().Reverse();
            long result = 0;
            int pos = 0;
            foreach (char c in reversed)
            {
                result += CharList.IndexOf(c) * (long)Math.Pow(36, pos);
                pos++;
            }
            return result;
        }

        /// <summary>
        /// Decode the Base36 encoded string into bytes.
        /// </summary>
        /// <param name="input">Encoded string</param>
        /// <param name="sep">Separator character</param>
        /// <returns>Decoded bytes</returns>
        public static byte[] DecodeBytes(string input, char sep = '-')
        {
            var ints = DecodeIntArray(input, sep);
            return ConvertUtils.IntArrayToBytes(ints);
        }

        /// <summary>
        /// Decode the Base36 encoded string into an integer array.
        /// </summary>
        /// <param name="input">Encoded string</param>
        /// <param name="sep">Separator character</param>
        /// <returns>Decoded integer array</returns>
        public static int[] DecodeIntArray(string input, char sep = '-')
        {
            var fields = input.Split(sep);
            var results = fields.Select((field) => (int)Decode(field)).ToArray();
            return results;
        }
    }

}