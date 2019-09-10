using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MMRando.Extensions
{
    public static class StringExtensions
    {
        public static string Wrap(this string str, int width, string newline)
        {
            var words = str.Split(' ');
            var lines = new List<string>();
            var currentLine = new List<string>();
            var currentLength = 0;
            foreach (var word in words)
            {
                var length = word.Count(c => HasWidth(c));
                if (currentLength + length > width)
                {
                    lines.Add(string.Join(" ", currentLine));
                    currentLength = 0;
                    currentLine.Clear();
                }
                currentLine.Add(word);
                currentLength += length + 1;
            }
            lines.Add(string.Join(" ", currentLine));
            return string.Join(newline, lines);
        }

        private static readonly ReadOnlyCollection<int> specialCharacters = new ReadOnlyCollection<int>(new int[]
        {
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x11, 0x12, 0x13, 0x19, 0x1E, 0xBF, 0xC2, 0xC3, 0xE0,
        });

        private static bool HasWidth(char c)
        {
            return !char.IsWhiteSpace(c) && !specialCharacters.Contains(c);
        }
    }
}
