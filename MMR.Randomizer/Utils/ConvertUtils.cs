using System.Collections.Generic;
using System.IO;

namespace MMR.Randomizer.Utils
{
    public static class ConvertUtils
    {
        /// <summary>
        /// Convert a byte array into an integer array (big-endian).
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Integers</returns>
        public static int[] BytesToIntArray(byte[] bytes)
        {
            var list = new List<int>();

            var extra = bytes.Length % 4 != 0;
            var count = bytes.Length / 4;

            if (extra)
                count += 1;

            for (var i = 0; i < count; i++)
            {
                var value = BytesToInt(bytes, i * 4);
                list.Add(value);
            }

            return list.ToArray();
        }

        /// <summary>
        /// Convert bytes to an integer (big-endian).
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <param name="index">Index into bytes array</param>
        /// <returns>Integer</returns>
        public static int BytesToInt(byte[] bytes, int index = 0)
        {
            int value = 0;
            var length = bytes.Length - index;
            if (length >= 4)
                value = (bytes[index] << 24) | (bytes[index + 1] << 16) | (bytes[index + 2] << 8) | bytes[index + 3];
            else if (length == 3)
                value = (bytes[index] << 24) | (bytes[index + 1] << 16) | (bytes[index + 2] << 8);
            else if (length == 2)
                value = (bytes[index] << 24) | (bytes[index + 1] << 16);
            else if (length == 1)
                value = bytes[index] << 24;
            return value;
        }

        /// <summary>
        /// Convert integers to a byte array (big-endian).
        /// </summary>
        /// <param name="ints">Integers</param>
        /// <returns>Bytes</returns>
        public static byte[] IntArrayToBytes(int[] ints)
        {
            using (var memoryStream = new MemoryStream())
            using (var writer = new BinaryWriter(memoryStream))
            {
                foreach (var value in ints)
                {
                    var bytes = IntToBytes(value);
                    writer.Write(bytes);
                }

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Convert an integer to bytes (big-endian).
        /// </summary>
        /// <param name="value">Integer</param>
        /// <returns>Bytes</returns>
        public static byte[] IntToBytes(int value)
        {
            var bytes = new byte[4];
            bytes[0] = (byte)((value >> 24) & 0xFF);
            bytes[1] = (byte)((value >> 16) & 0xFF);
            bytes[2] = (byte)((value >> 8) & 0xFF);
            bytes[3] = (byte)(value & 0xFF);
            return bytes;
        }
    }
}
