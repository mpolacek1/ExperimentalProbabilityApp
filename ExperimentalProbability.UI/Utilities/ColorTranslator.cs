using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;
using ExperimentalProbability.Contracts.Properties.Resources.Colors;
using Xceed.Wpf.Toolkit;

namespace ExperimentalProbability.UI.Utilities
{
    public static class ColorTranslator
    {
        public static readonly ReadOnlyDictionary<string, string> ColorNames = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>()
            {
                { "#FFF0F8FF", Resources.AliceBlue },
                { "#FFFAEBD7", Resources.AntiqueWhite },
                { "#FF7FFFD4", Resources.Aquamarine },
                { "#FFF0FFFF", Resources.Azure },
                { "#FFF5F5DC", Resources.Beige },
                { "#FFFFE4C4", Resources.Bisque },
                { "#FF000000", Resources.Black },
                { "#FFFFEBCD", Resources.BlanchedAlmond },
                { "#FF0000FF", Resources.Blue },
                { "#FF8A2BE2", Resources.BlueViolet },
                { "#FFA52A2A", Resources.Brown },
                { "#FFDEB887", Resources.BurlyWood },
                { "#FF5F9EA0", Resources.CadetBlue },
                { "#FF7FFF00", Resources.Chartreuse },
                { "#FFD2691E", Resources.Chocolate },
                { "#FFFF7F50", Resources.Coral },
                { "#FF6495ED", Resources.CornflowerBlue },
                { "#FFFFF8DC", Resources.Cornsilk },
                { "#FFDC143C", Resources.Crimson },
                { "#FF00FFFF", Resources.Cyan },
                { "#FF00008B", Resources.DarkBlue },
                { "#FF008B8B", Resources.DarkCyan },
                { "#FFB886BB", Resources.DarkGoldenrod },
                { "#FFA9A9A9", Resources.DarkGray },
                { "#FF006400", Resources.DarkGreen },
                { "#FFBDB76B", Resources.DarkKhaki },
                { "#FF8B008B", Resources.DarkMagenta },
                { "#FF556B2F", Resources.DarkOliveGreen },
                { "#FFFF8C00", Resources.DarkOrange },
                { "#FF9932CC", Resources.DarkOrchid },
                { "#FF8B0000", Resources.DarkRed },
                { "#FFE9967A", Resources.DarkSalmon },
                { "#FF8FBC8B", Resources.DarkSeaGreen },
                { "#FF483D8B", Resources.DarkSlateBlue },
                { "#FF2F4F4F", Resources.DarkSlateGray },
                { "#FF00CED1", Resources.DarkTurquoise },
                { "#FF9400D3", Resources.DarkViolet },
                { "#FFFF1493", Resources.DeepPink },
                { "#FF00BFFF", Resources.DeepSkyBlue },
                { "#FF696969", Resources.DimGray },
                { "#FF1E90FF", Resources.DodgerBlue },
                { "#FFB22222", Resources.Firebrick },
                { "#FFFFFAF0", Resources.FloralWhite },
                { "#FF228B22", Resources.ForestGreen },
                { "#FFDCDCDC", Resources.Gainsboro },
                { "#FFF8F8FF", Resources.GhostWhite },
                { "#FFFFD700", Resources.Gold },
                { "#FFDAA520", Resources.Goldenrod },
                { "#FF808080", Resources.Gray },
                { "#FF008000", Resources.Green },
                { "#FFADFF2F", Resources.GreenYellow },
                { "#FFF0FFF0", Resources.Honeydew },
                { "#FFFF69B4", Resources.HotPink },
                { "#FFCD5C5C", Resources.IndianRed },
                { "#FF4B0082", Resources.Indigo },
                { "#FFFFFFF0", Resources.Ivory },
                { "#FFF0E68C", Resources.Khaki },
                { "#FFE6E6FA", Resources.Lavender },
                { "#FFFFF0F5", Resources.LavenderBlush },
                { "#FF7CFC00", Resources.LawnGreen },
                { "#FFFFFACD", Resources.LemonChiffon },
                { "#FFADD8E6", Resources.LightBlue },
                { "#FFF08080", Resources.LightCoral },
                { "#FFE0FFFF", Resources.LightCyan },
                { "#FFFAFAD2", Resources.LightGoldenrodYellow },
                { "#FFD3D3D3", Resources.LightGray },
                { "#FF90EE90", Resources.LightGreen },
                { "#FFFFB6C1", Resources.LightPink },
                { "#FFFFA07A", Resources.LightSalmon },
                { "#FF20B2AA", Resources.LightSeaGreen },
                { "#FF87CEFA", Resources.LightSkyBlue },
                { "#FF778899", Resources.LightSlateGray },
                { "#FFB0C4DE", Resources.LightSteelBlue },
                { "#FFFFFFE0", Resources.LightYellow },
                { "#FF00FF00", Resources.Lime },
                { "#FF32CD32", Resources.LimeGreen },
                { "#FFFAF0E6", Resources.Linen },
                { "#FFFF00FF", Resources.Magenta },
                { "#FF800000", Resources.Maroon },
                { "#FF66CDAA", Resources.MediumAquamarine },
                { "#FF0000CD", Resources.MediumBlue },
                { "#FFBA55D3", Resources.MediumOrchid },
                { "#FF9370DB", Resources.MediumPurple },
                { "#FF3CB371", Resources.MediumSeaGreen },
                { "#FF7B68EE", Resources.MediumSlateBlue },
                { "#FF00FA9A", Resources.MediumSpringGreen },
                { "#FF48D1CC", Resources.MediumTurquoise },
                { "#FFC71585", Resources.MediumVioletRed },
                { "#FF191970", Resources.MidnightBlue },
                { "#FFF5FFFA", Resources.MintCream },
                { "#FFFFE4E1", Resources.MistyRose },
                { "#FFFFE4B5", Resources.Moccasin },
                { "#FFFFDEAD", Resources.NavajoWhite },
                { "#FF000080", Resources.Navy },
                { "#FFFDF5E6", Resources.OldLace },
                { "#FF808000", Resources.Olive },
                { "#FF6B8E23", Resources.OliveDrab },
                { "#FFFFA500", Resources.Orange },
                { "#FFFF4500", Resources.OrangeRed },
                { "#FFDA70D6", Resources.Orchid },
                { "#FFEEE8AA", Resources.PaleGoldenrod },
                { "#FF98FB98", Resources.PaleGreen },
                { "#FFAFEEEE", Resources.PaleTurquoise },
                { "#FFDB7093", Resources.PaleVioletRed },
                { "#FFFFEFD5", Resources.PapayaWhip },
                { "#FFFFDAB9", Resources.PeachPuff },
                { "#FFCD853F", Resources.Peru },
                { "#FFFFC0CB", Resources.Pink },
                { "#FFDDA0DD", Resources.Plum },
                { "#FFB0E0E6", Resources.PowderBlue },
                { "#FF800080", Resources.Purple },
                { "#FFFF0000", Resources.Red },
                { "#FFBC8F8F", Resources.RosyBrown },
                { "#FF4169E1", Resources.RoyalBlue },
                { "#FF8B4513", Resources.SaddleBrown },
                { "#FFFA8072", Resources.Salmon },
                { "#FFF4A460", Resources.SandyBrown },
                { "#FF2E8B57", Resources.SeaGreen },
                { "#FFFFF5EE", Resources.SeaShell },
                { "#FFA0522D", Resources.Sienna },
                { "#FFC0C0C0", Resources.Silver },
                { "#FF87CEEB", Resources.SkyBlue },
                { "#FF6A5ACD", Resources.SlateBlue },
                { "#FF708090", Resources.SlateGray },
                { "#FFFFFAFA", Resources.Snow },
                { "#FF00FF7F", Resources.SpringGreen },
                { "#FF4682B4", Resources.SteelBlue },
                { "#FFD2B48C", Resources.Tan },
                { "#FF008080", Resources.Teal },
                { "#FFD8BFD8", Resources.Thistle },
                { "#FFFF6347", Resources.Tomato },
                { "#FF40E0D0", Resources.Turquoise },
                { "#FFEE82EE", Resources.Violet },
                { "#FFF5DEB3", Resources.Wheat },
                { "#FFFFFFFF", Resources.White },
                { "#FFF5F5F5", Resources.WhiteSmoke },
                { "#FFFFFF00", Resources.Yellow },
                { "#FF9ACD32", Resources.YellowGreen },
            });

        public static List<ColorItem> GenerateDefaultAvailableColors()
        {
            var colors = new List<ColorItem>();

            foreach (var color in ColorNames)
            {
                colors.Add(new ColorItem(CreateColorFromString(color.Key), color.Value));
            }

            return colors;
        }

        public static Color CreateColorFromString(string value)
        {
            var argb = GetARGBValuesFromString(value.Remove(0, 1));

            return Color.FromArgb(argb[0], argb[1], argb[2], argb[3]);
        }

        private static byte[] GetARGBValuesFromString(string value)
        {
            var argbValues = new List<byte>(4);

            foreach (var hex in SplitStringToFourHexValues(value))
            {
                argbValues.Add(Convert.ToByte(hex, 16));
            }

            return argbValues.ToArray();
        }

        private static string[] SplitStringToFourHexValues(string value)
        {
            var hexValues = new List<string>(4);

            for (int i = default; i < value.Length; i++)
            {
                if (i == default || i % 2 == default)
                {
                    hexValues.Add(new string(value.ToCharArray(i, 2)));
                }
            }

            return hexValues.ToArray();
        }
    }
}
