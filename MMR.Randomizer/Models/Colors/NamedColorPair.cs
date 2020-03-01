using System;
using System.Drawing;

namespace MMR.Randomizer.Models.Colors
{
    /// <summary>
    /// Named pair of colors.
    /// </summary>
    public class NamedColorPair
    {
        /// <summary>
        /// Color pair values.
        /// </summary>
        public Tuple<Color, Color> Colors { get; private set; }

        /// <summary>
        /// Name of color pair.
        /// </summary>
        public string Name { get; private set; }

        public NamedColorPair(string name, Color color1, Color color2)
        {
            this.Name = name;
            this.Colors = new Tuple<Color, Color>(color1, color2);
        }

        public NamedColorPair(string name, Color color)
            : this(name, color, color)
        {
        }

        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Get a new <see cref="NamedColorPair"/> with the colors reversed.
        /// </summary>
        /// <returns>Pair</returns>
        public NamedColorPair Reverse()
        {
            return new NamedColorPair(this.Name, this.Colors.Item2, this.Colors.Item1);
        }
    }
}
