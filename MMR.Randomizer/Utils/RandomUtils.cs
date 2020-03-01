using System;
using System.Drawing;

namespace MMR.Randomizer.Utils
{
    public class RandomUtils
    {
        /// <summary>
        /// Select a random item from an array.
        /// </summary>
        /// <typeparam name="T">Array type</typeparam>
        /// <param name="items">Array</param>
        /// <param name="random">Random</param>
        /// <returns>Random item</returns>
        public static T Select<T>(T[] items, Random random)
        {
            var index = random.Next(items.Length);
            return items[index];
        }

        /// <summary>
        /// Generate a random color.
        /// </summary>
        /// <param name="random">Random</param>
        /// <returns>Color</returns>
        public static Color GetRandomColor(Random random)
        {
            var bytes = new byte[3];
            random.NextBytes(bytes);
            return Color.FromArgb(bytes[0], bytes[1], bytes[2]);
        }
    }
}
