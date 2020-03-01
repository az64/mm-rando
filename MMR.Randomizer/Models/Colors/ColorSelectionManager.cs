using MMR.Randomizer.Asm;
using MMR.Randomizer.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MMR.Randomizer.Models.Colors
{
    /// <summary>
    /// Color selection manager, which provides an item list for ComboBox components.
    /// </summary>
    public class ColorSelectionManager
    {
        //private static IEnumerable<ColorSelectionManager> ColorSelectionManagers = new List<ColorSelectionManager>()
        //{
        public static ColorSelectionManager Hearts = new ColorSelectionManager(HudColorPresets.Hearts())
        {
            UseSameRandomColor = true,
            Prepended = NullChoice("Customized"),
        };
        public static ColorSelectionManager MagicMeter = new ColorSelectionManager(HudColorPresets.MagicMeter())
        {
            Prepended = NullChoice("Customized"),
        };
        //};

        static ColorSelectionManager()
        {

        }

        /// <summary>
        /// Color pairs, used with "Random Choice" <see cref="ColorSelectionFuncItem"/>.
        /// </summary>
        public NamedColorPair[] Pairs { get; private set; } = new NamedColorPair[0];

        /// <summary>
        /// Whether or not to include the "Completely Random" <see cref="ColorSelectionFuncItem"/>.
        /// </summary>
        public bool UseCompletelyRandom { get; set; } = true;

        /// <summary>
        /// Whether or not to include the "Random Choice" <see cref="ColorSelectionFuncItem"/>.
        /// </summary>
        public bool UseRandomChoice { get; set; } = true;

        /// <summary>
        /// Whether or not to use the same random color in a color pair when generating a completely random pair.
        /// </summary>
        public bool UseSameRandomColor { get; set; } = false;

        /// <summary>
        /// Whether or not to show <see cref="NamedColorPair"/> items.
        /// </summary>
        public bool ShowPairItems { get; set; } = false;

        /// <summary>
        /// Prepended item, likely used for a <see cref="ColorSelectionFuncItem"/> which returns null.
        /// </summary>
        ColorSelectionItem Prepended { get; set; }

        public ColorSelectionManager(NamedColorPair[] pairs)
        {
            this.Pairs = pairs;
        }

        /// <summary>
        /// Get all items to be used in a ComboBox component.
        /// </summary>
        /// <returns></returns>
        public ColorSelectionItem[] GetItems()
        {
            var list = new List<ColorSelectionItem>();
            if (this.Prepended != null)
                list.Add(this.Prepended);
            if (this.UseRandomChoice && this.Pairs.Length > 0)
                list.Add(this.RandomChoice());
            if (this.UseCompletelyRandom)
                list.Add(this.CompletelyRandom());
            if (this.ShowPairItems)
            {
                var pairItems = this.Pairs.Select((pair) => new ColorSelectionPairItem(pair));
                list.AddRange(pairItems);
            }
            return list.ToArray();
        }

        /// <summary>
        /// Set the prepended item as a <see cref="ColorSelectionFuncItem"/> which returns null.
        /// </summary>
        /// <param name="name">Item name</param>
        public void PrependNull(string name)
        {
            this.Prepended = NullChoice(name);
        }

        /// <summary>
        /// Get a <see cref="ColorSelectionFuncItem"/> which returns null.
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns>Item</returns>
        static ColorSelectionFuncItem NullChoice(string name)
        {
            return new ColorSelectionFuncItem(name, (random) => null);
        }

        /// <summary>
        /// Get a <see cref="ColorSelectionFuncItem"/> which returns a random color pair given the available <see cref="NamedColorPair"/> pairings.
        /// </summary>
        /// <returns>Item</returns>
        ColorSelectionFuncItem RandomChoice()
        {
            return new ColorSelectionFuncItem("Random Choice", (random) =>
            {
                var selected = RandomUtils.Select(Pairs, random);
                return selected.Colors;
            });
        }

        /// <summary>
        /// Get a <see cref="ColorSelectionFuncItem"/> which returns a completely random color pair.
        /// </summary>
        /// <returns>Item</returns>
        ColorSelectionFuncItem CompletelyRandom()
        {
            if (UseSameRandomColor)
            {
                return new ColorSelectionFuncItem("Completely Random", (random) =>
                {
                    var color = RandomUtils.GetRandomColor(random);
                    return new Tuple<Color, Color>(color, color);
                });
            }
            else
            {
                return new ColorSelectionFuncItem("Completely Random", (random) =>
                {
                    var color1 = RandomUtils.GetRandomColor(random);
                    var color2 = RandomUtils.GetRandomColor(random);
                    return new Tuple<Color, Color>(color1, color2);
                });
            }
        }
    }

    /// <summary>
    /// Color selection item which has a name and method to obtain a color pair.
    /// </summary>
    public abstract class ColorSelectionItem
    {
        public abstract string Name { get; }
        public abstract Tuple<Color, Color> GetColors(Random random);

        public override string ToString()
        {
            return this.Name;
        }
    }

    /// <summary>
    /// Color selection item which uses an underlying <see cref="NamedColorPair"/>.
    /// </summary>
    public class ColorSelectionPairItem : ColorSelectionItem
    {
        /// <summary>
        /// Underlying color pair.
        /// </summary>
        public NamedColorPair Colors { get; private set; }

        public override string Name => this.Colors.Name;

        public ColorSelectionPairItem(NamedColorPair colors)
        {
            this.Colors = colors;
        }

        public override Tuple<Color, Color> GetColors(Random random)
        {
            return this.Colors.Colors;
        }
    }

    /// <summary>
    /// Color selection item with custom behaviour when requesting colors.
    /// </summary>
    public class ColorSelectionFuncItem : ColorSelectionItem
    {
        /// <summary>
        /// Custom function used to obtain the color pair.
        /// </summary>
        public Func<Random, Tuple<Color, Color>> Function { get; private set; }

        public override string Name { get; }

        public ColorSelectionFuncItem(string name, Func<Random, Tuple<Color, Color>> func)
        {
            this.Name = name;
            this.Function = func;
        }

        public override Tuple<Color, Color> GetColors(Random random)
        {
            return this.Function(random);
        }
    }
}
