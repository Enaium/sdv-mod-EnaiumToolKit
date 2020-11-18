using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace EnaiumToolKit.Framework.Utils
{
    public class ColorUtils
    {
        public readonly NameType Name;
        public readonly Color Color;
        public readonly List<ColorUtils> Colors = new List<ColorUtils>();
        public static readonly ColorUtils Instance = new ColorUtils();

        private ColorUtils(NameType name, Color color)
        {
            Name = name;
            Color = color;
        }

        private ColorUtils()
        {
            Colors.Add(new ColorUtils(NameType.Gainsboro, new Color(220, 220, 220)));
            Colors.Add(new ColorUtils(NameType.Lightgray, new Color(211, 211, 211)));
            Colors.Add(new ColorUtils(NameType.Silver, new Color(192, 192, 192)));
            Colors.Add(new ColorUtils(NameType.Darkgray, new Color(169, 169, 169)));
            Colors.Add(new ColorUtils(NameType.Gray, new Color(128, 128, 128)));
            Colors.Add(new ColorUtils(NameType.Dimgray, new Color(105, 105, 105)));
            Colors.Add(new ColorUtils(NameType.Lightslategray, new Color(119, 136, 153)));
            Colors.Add(new ColorUtils(NameType.Slategray, new Color(112, 128, 144)));
            Colors.Add(new ColorUtils(NameType.Darkslategray, new Color(47, 79, 79)));
            Colors.Add(new ColorUtils(NameType.Black, new Color(0, 0, 0)));
            Colors.Add(new ColorUtils(NameType.Indianred, new Color(205, 92, 92)));
            Colors.Add(new ColorUtils(NameType.Lightcoral, new Color(240, 128, 128)));
            Colors.Add(new ColorUtils(NameType.Salmon, new Color(250, 128, 114)));
            Colors.Add(new ColorUtils(NameType.Darksalmon, new Color(233, 150, 122)));
            Colors.Add(new ColorUtils(NameType.Lightsalmon, new Color(255, 160, 122)));
            Colors.Add(new ColorUtils(NameType.Crimson, new Color(220, 20, 60)));
            Colors.Add(new ColorUtils(NameType.Red, new Color(255, 0, 0)));
            Colors.Add(new ColorUtils(NameType.Firebrick, new Color(178, 34, 34)));
            Colors.Add(new ColorUtils(NameType.Darkred, new Color(139, 0, 0)));
            Colors.Add(new ColorUtils(NameType.Coral, new Color(255, 127, 80)));
            Colors.Add(new ColorUtils(NameType.Tomato, new Color(255, 99, 71)));
            Colors.Add(new ColorUtils(NameType.Orangered, new Color(255, 69, 0)));
            Colors.Add(new ColorUtils(NameType.Darkorange, new Color(255, 140, 0)));
            Colors.Add(new ColorUtils(NameType.Orange, new Color(255, 165, 0)));
            Colors.Add(new ColorUtils(NameType.Cornsilk, new Color(255, 248, 220)));
            Colors.Add(new ColorUtils(NameType.Blanchedalmond, new Color(255, 235, 205)));
            Colors.Add(new ColorUtils(NameType.Bisque, new Color(255, 228, 196)));
            Colors.Add(new ColorUtils(NameType.Navajowhite, new Color(255, 222, 173)));
            Colors.Add(new ColorUtils(NameType.Wheat, new Color(245, 222, 179)));
            Colors.Add(new ColorUtils(NameType.Burlywood, new Color(222, 184, 135)));
            Colors.Add(new ColorUtils(NameType.Tan, new Color(210, 180, 140)));
            Colors.Add(new ColorUtils(NameType.Rosybrown, new Color(188, 143, 143)));
            Colors.Add(new ColorUtils(NameType.Sandybrown, new Color(244, 164, 96)));
            Colors.Add(new ColorUtils(NameType.Goldenrod, new Color(218, 165, 32)));
            Colors.Add(new ColorUtils(NameType.Darkgoldenrod, new Color(184, 134, 11)));
            Colors.Add(new ColorUtils(NameType.Peru, new Color(205, 133, 63)));
            Colors.Add(new ColorUtils(NameType.Chocolate, new Color(210, 105, 30)));
            Colors.Add(new ColorUtils(NameType.Saddlebrown, new Color(139, 69, 19)));
            Colors.Add(new ColorUtils(NameType.Sienna, new Color(160, 82, 45)));
            Colors.Add(new ColorUtils(NameType.Brown, new Color(165, 42, 42)));
            Colors.Add(new ColorUtils(NameType.Maroon, new Color(128, 0, 0)));
            Colors.Add(new ColorUtils(NameType.Aqua, new Color(0, 255, 255)));
            Colors.Add(new ColorUtils(NameType.Cyan, new Color(0, 255, 255)));
            Colors.Add(new ColorUtils(NameType.Lightcyan, new Color(224, 255, 255)));
            Colors.Add(new ColorUtils(NameType.Paleturquoise, new Color(175, 238, 238)));
            Colors.Add(new ColorUtils(NameType.Aquamarine, new Color(127, 255, 212)));
            Colors.Add(new ColorUtils(NameType.Turquoise, new Color(64, 224, 208)));
            Colors.Add(new ColorUtils(NameType.Mediumturquoise, new Color(72, 209, 204)));
            Colors.Add(new ColorUtils(NameType.Darkturquoise, new Color(0, 206, 209)));
            Colors.Add(new ColorUtils(NameType.Cadetblue, new Color(95, 158, 160)));
            Colors.Add(new ColorUtils(NameType.Steelblue, new Color(70, 130, 180)));
            Colors.Add(new ColorUtils(NameType.Lightsteelblue, new Color(176, 196, 222)));
            Colors.Add(new ColorUtils(NameType.Powderblue, new Color(176, 224, 230)));
            Colors.Add(new ColorUtils(NameType.Lightblue, new Color(173, 216, 230)));
            Colors.Add(new ColorUtils(NameType.Skyblue, new Color(135, 206, 235)));
            Colors.Add(new ColorUtils(NameType.Lightskyblue, new Color(135, 206, 250)));
            Colors.Add(new ColorUtils(NameType.Deepskyblue, new Color(0, 191, 255)));
            Colors.Add(new ColorUtils(NameType.Dodgerblue, new Color(30, 144, 255)));
            Colors.Add(new ColorUtils(NameType.Cornflowerblue, new Color(100, 149, 237)));
            Colors.Add(new ColorUtils(NameType.Mediumslateblue, new Color(123, 104, 238)));
            Colors.Add(new ColorUtils(NameType.Royalblue, new Color(65, 105, 225)));
            Colors.Add(new ColorUtils(NameType.Blue, new Color(0, 0, 255)));
            Colors.Add(new ColorUtils(NameType.Mediumblue, new Color(0, 0, 205)));
            Colors.Add(new ColorUtils(NameType.Darkblue, new Color(0, 0, 139)));
            Colors.Add(new ColorUtils(NameType.Navy, new Color(0, 0, 128)));
            Colors.Add(new ColorUtils(NameType.Midnightblue, new Color(25, 25, 112)));
            Colors.Add(new ColorUtils(NameType.Greenyellow, new Color(173, 255, 47)));
            Colors.Add(new ColorUtils(NameType.Chartreuse, new Color(127, 255, 0)));
            Colors.Add(new ColorUtils(NameType.Lawngreen, new Color(124, 252, 0)));
            Colors.Add(new ColorUtils(NameType.Lime, new Color(0, 255, 0)));
            Colors.Add(new ColorUtils(NameType.Limegreen, new Color(50, 205, 50)));
            Colors.Add(new ColorUtils(NameType.Palegreen, new Color(152, 251, 152)));
            Colors.Add(new ColorUtils(NameType.Lightgreen, new Color(144, 238, 144)));
            Colors.Add(new ColorUtils(NameType.Mediumspringgreen, new Color(0, 250, 154)));
            Colors.Add(new ColorUtils(NameType.Springgreen, new Color(0, 255, 127)));
            Colors.Add(new ColorUtils(NameType.Mediumseagreen, new Color(60, 179, 113)));
            Colors.Add(new ColorUtils(NameType.Seagreen, new Color(46, 139, 87)));
            Colors.Add(new ColorUtils(NameType.Forestgreen, new Color(34, 139, 34)));
            Colors.Add(new ColorUtils(NameType.Green, new Color(0, 128, 0)));
            Colors.Add(new ColorUtils(NameType.Darkgreen, new Color(0, 100, 0)));
            Colors.Add(new ColorUtils(NameType.Yellowgreen, new Color(154, 205, 50)));
            Colors.Add(new ColorUtils(NameType.Olivedrab, new Color(107, 142, 35)));
            Colors.Add(new ColorUtils(NameType.Olive, new Color(128, 128, 0)));
            Colors.Add(new ColorUtils(NameType.Darkolivegreen, new Color(85, 107, 47)));
            Colors.Add(new ColorUtils(NameType.Mediumaquamarine, new Color(102, 205, 170)));
            Colors.Add(new ColorUtils(NameType.Darkseagreen, new Color(143, 188, 139)));
            Colors.Add(new ColorUtils(NameType.Lightseagreen, new Color(32, 178, 170)));
            Colors.Add(new ColorUtils(NameType.Darkcyan, new Color(0, 139, 139)));
            Colors.Add(new ColorUtils(NameType.Teal, new Color(0, 128, 128)));
            Colors.Add(new ColorUtils(NameType.Pink, new Color(255, 192, 203)));
            Colors.Add(new ColorUtils(NameType.Lightpink, new Color(255, 182, 193)));
            Colors.Add(new ColorUtils(NameType.Hotpink, new Color(255, 105, 180)));
            Colors.Add(new ColorUtils(NameType.Deeppink, new Color(255, 20, 147)));
            Colors.Add(new ColorUtils(NameType.Mediumvioletred, new Color(199, 21, 133)));
            Colors.Add(new ColorUtils(NameType.Palevioletred, new Color(219, 112, 147)));
            Colors.Add(new ColorUtils(NameType.Lavender, new Color(230, 230, 250)));
            Colors.Add(new ColorUtils(NameType.Thistle, new Color(216, 191, 216)));
            Colors.Add(new ColorUtils(NameType.Plum, new Color(221, 160, 221)));
            Colors.Add(new ColorUtils(NameType.Violet, new Color(238, 130, 238)));
            Colors.Add(new ColorUtils(NameType.Orchid, new Color(218, 112, 214)));
            Colors.Add(new ColorUtils(NameType.Fuchsia, new Color(255, 0, 255)));
            Colors.Add(new ColorUtils(NameType.Magenta, new Color(255, 0, 255)));
            Colors.Add(new ColorUtils(NameType.Mediumorchid, new Color(186, 85, 211)));
            Colors.Add(new ColorUtils(NameType.Mediumpurple, new Color(147, 112, 219)));
            Colors.Add(new ColorUtils(NameType.Rebeccapurple, new Color(102, 51, 153)));
            Colors.Add(new ColorUtils(NameType.Blueviolet, new Color(138, 43, 226)));
            Colors.Add(new ColorUtils(NameType.Darkviolet, new Color(148, 0, 211)));
            Colors.Add(new ColorUtils(NameType.Darkorchid, new Color(153, 50, 204)));
            Colors.Add(new ColorUtils(NameType.Darkmagenta, new Color(139, 0, 139)));
            Colors.Add(new ColorUtils(NameType.Purple, new Color(128, 0, 128)));
            Colors.Add(new ColorUtils(NameType.Indigo, new Color(75, 0, 130)));
            Colors.Add(new ColorUtils(NameType.Slateblue, new Color(106, 90, 205)));
            Colors.Add(new ColorUtils(NameType.Darkslateblue, new Color(72, 61, 139)));
            Colors.Add(new ColorUtils(NameType.White, new Color(255, 255, 255)));
            Colors.Add(new ColorUtils(NameType.Snow, new Color(255, 250, 250)));
            Colors.Add(new ColorUtils(NameType.Honeydew, new Color(240, 255, 240)));
            Colors.Add(new ColorUtils(NameType.Mintcream, new Color(245, 255, 250)));
            Colors.Add(new ColorUtils(NameType.Azure, new Color(240, 255, 255)));
            Colors.Add(new ColorUtils(NameType.Aliceblue, new Color(240, 248, 255)));
            Colors.Add(new ColorUtils(NameType.Ghostwhite, new Color(248, 248, 255)));
            Colors.Add(new ColorUtils(NameType.Whitesmoke, new Color(245, 245, 245)));
            Colors.Add(new ColorUtils(NameType.Seashell, new Color(255, 245, 238)));
            Colors.Add(new ColorUtils(NameType.Beige, new Color(245, 245, 220)));
            Colors.Add(new ColorUtils(NameType.Oldlace, new Color(253, 245, 230)));
            Colors.Add(new ColorUtils(NameType.Floralwhite, new Color(255, 250, 240)));
            Colors.Add(new ColorUtils(NameType.Ivory, new Color(255, 255, 240)));
            Colors.Add(new ColorUtils(NameType.Antiquewhite, new Color(250, 235, 215)));
            Colors.Add(new ColorUtils(NameType.Linen, new Color(250, 240, 230)));
            Colors.Add(new ColorUtils(NameType.Lavenderblush, new Color(255, 240, 245)));
            Colors.Add(new ColorUtils(NameType.Mistyrose, new Color(255, 228, 225)));
            Colors.Add(new ColorUtils(NameType.Gold, new Color(255, 215, 0)));
            Colors.Add(new ColorUtils(NameType.Yellow, new Color(255, 255, 0)));
            Colors.Add(new ColorUtils(NameType.Lightyellow, new Color(255, 255, 224)));
            Colors.Add(new ColorUtils(NameType.Lemonchiffon, new Color(255, 250, 205)));
            Colors.Add(new ColorUtils(NameType.Lightgoldenrodyellow, new Color(250, 250, 210)));
            Colors.Add(new ColorUtils(NameType.Papayawhip, new Color(255, 239, 213)));
            Colors.Add(new ColorUtils(NameType.Moccasin, new Color(255, 228, 181)));
            Colors.Add(new ColorUtils(NameType.Peachpuff, new Color(255, 218, 185)));
            Colors.Add(new ColorUtils(NameType.Palegoldenrod, new Color(238, 232, 170)));
            Colors.Add(new ColorUtils(NameType.Khaki, new Color(240, 230, 140)));
            Colors.Add(new ColorUtils(NameType.Darkkhaki, new Color(189, 183, 107)));
        }

        public Color Get(NameType nameType)
        {
            foreach (var variable in Colors.Where(it => it.Name == nameType))
            {
                return variable.Color;
            }

            return new Color(0, 0, 0);
        }

        public NameType Get(Color color)
        {
            foreach (var variable in Colors.Where(it => it.Color == color))
            {
                return variable.Name;
            }

            return NameType.Black;
        }

        public enum NameType
        {
            Gainsboro,
            Lightgray,
            Silver,
            Darkgray,
            Gray,
            Dimgray,
            Lightslategray,
            Slategray,
            Darkslategray,
            Black,
            Indianred,
            Lightcoral,
            Salmon,
            Darksalmon,
            Lightsalmon,
            Crimson,
            Red,
            Firebrick,
            Darkred,
            Coral,
            Tomato,
            Orangered,
            Darkorange,
            Orange,
            Cornsilk,
            Blanchedalmond,
            Bisque,
            Navajowhite,
            Wheat,
            Burlywood,
            Tan,
            Rosybrown,
            Sandybrown,
            Goldenrod,
            Darkgoldenrod,
            Peru,
            Chocolate,
            Saddlebrown,
            Sienna,
            Brown,
            Maroon,
            Aqua,
            Cyan,
            Lightcyan,
            Paleturquoise,
            Aquamarine,
            Turquoise,
            Mediumturquoise,
            Darkturquoise,
            Cadetblue,
            Steelblue,
            Lightsteelblue,
            Powderblue,
            Lightblue,
            Skyblue,
            Lightskyblue,
            Deepskyblue,
            Dodgerblue,
            Cornflowerblue,
            Mediumslateblue,
            Royalblue,
            Blue,
            Mediumblue,
            Darkblue,
            Navy,
            Midnightblue,
            Greenyellow,
            Chartreuse,
            Lawngreen,
            Lime,
            Limegreen,
            Palegreen,
            Lightgreen,
            Mediumspringgreen,
            Springgreen,
            Mediumseagreen,
            Seagreen,
            Forestgreen,
            Green,
            Darkgreen,
            Yellowgreen,
            Olivedrab,
            Olive,
            Darkolivegreen,
            Mediumaquamarine,
            Darkseagreen,
            Lightseagreen,
            Darkcyan,
            Teal,
            Pink,
            Lightpink,
            Hotpink,
            Deeppink,
            Mediumvioletred,
            Palevioletred,
            Lavender,
            Thistle,
            Plum,
            Violet,
            Orchid,
            Fuchsia,
            Magenta,
            Mediumorchid,
            Mediumpurple,
            Rebeccapurple,
            Blueviolet,
            Darkviolet,
            Darkorchid,
            Darkmagenta,
            Purple,
            Indigo,
            Slateblue,
            Darkslateblue,
            White,
            Snow,
            Honeydew,
            Mintcream,
            Azure,
            Aliceblue,
            Ghostwhite,
            Whitesmoke,
            Seashell,
            Beige,
            Oldlace,
            Floralwhite,
            Ivory,
            Antiquewhite,
            Linen,
            Lavenderblush,
            Mistyrose,
            Gold,
            Yellow,
            Lightyellow,
            Lemonchiffon,
            Lightgoldenrodyellow,
            Papayawhip,
            Moccasin,
            Peachpuff,
            Palegoldenrod,
            Khaki,
            Darkkhaki
        }
    }
}