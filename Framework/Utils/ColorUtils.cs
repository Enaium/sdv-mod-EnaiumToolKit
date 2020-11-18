﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace EnaiumToolKit.Framework.Utils
{
    public class ColorUtils
    {
        private readonly NameType _name;
        private readonly Color _color;

        public static readonly List<ColorUtils> Colors = new List<ColorUtils>();

        private ColorUtils(NameType name, Color color)
        {
            _name = name;
            _color = color;
        }

        public ColorUtils()
        {
            Colors.Add(new ColorUtils(NameType.LightPink, new Color(255, 182, 193)));
            Colors.Add(new ColorUtils(NameType.Pink, new Color(255, 192, 203)));
            Colors.Add(new ColorUtils(NameType.Crimson, new Color(220, 20, 60)));
            Colors.Add(new ColorUtils(NameType.LavenderBlush, new Color(255, 240, 245)));
            Colors.Add(new ColorUtils(NameType.PaleVioletRed, new Color(219, 112, 147)));
            Colors.Add(new ColorUtils(NameType.HotPink, new Color(255, 105, 180)));
            Colors.Add(new ColorUtils(NameType.DeepPink, new Color(255, 20, 147)));
            Colors.Add(new ColorUtils(NameType.MediumVioletRed, new Color(199, 21, 133)));
            Colors.Add(new ColorUtils(NameType.Orchid, new Color(218, 112, 214)));
            Colors.Add(new ColorUtils(NameType.Thistle, new Color(216, 191, 216)));
            Colors.Add(new ColorUtils(NameType.Plum, new Color(221, 160, 221)));
            Colors.Add(new ColorUtils(NameType.Violet, new Color(238, 130, 238)));
            Colors.Add(new ColorUtils(NameType.Magenta, new Color(255, 0, 255)));
            Colors.Add(new ColorUtils(NameType.Fuchsia, new Color(255, 0, 255)));
            Colors.Add(new ColorUtils(NameType.DarkMagenta, new Color(139, 0, 139)));
            Colors.Add(new ColorUtils(NameType.Purple, new Color(128, 0, 128)));
            Colors.Add(new ColorUtils(NameType.MediumOrchid, new Color(186, 85, 211)));
            Colors.Add(new ColorUtils(NameType.DarkVoilet, new Color(148, 0, 211)));
            Colors.Add(new ColorUtils(NameType.DarkOrchid, new Color(153, 50, 204)));
            Colors.Add(new ColorUtils(NameType.Indigo, new Color(75, 0, 130)));
            Colors.Add(new ColorUtils(NameType.BlueViolet, new Color(138, 43, 226)));
            Colors.Add(new ColorUtils(NameType.MediumPurple, new Color(147, 112, 219)));
            Colors.Add(new ColorUtils(NameType.MediumSlateBlue, new Color(123, 104, 238)));
            Colors.Add(new ColorUtils(NameType.SlateBlue, new Color(106, 90, 205)));
            Colors.Add(new ColorUtils(NameType.DarkSlateBlue, new Color(72, 61, 139)));
            Colors.Add(new ColorUtils(NameType.Lavender, new Color(230, 230, 250)));
            Colors.Add(new ColorUtils(NameType.GhostWhite, new Color(248, 248, 255)));
            Colors.Add(new ColorUtils(NameType.Blue, new Color(0, 0, 255)));
            Colors.Add(new ColorUtils(NameType.MediumBlue, new Color(0, 0, 205)));
            Colors.Add(new ColorUtils(NameType.MidnightBlue, new Color(25, 25, 112)));
            Colors.Add(new ColorUtils(NameType.DarkBlue, new Color(0, 0, 139)));
            Colors.Add(new ColorUtils(NameType.Navy, new Color(0, 0, 128)));
            Colors.Add(new ColorUtils(NameType.RoyalBlue, new Color(65, 105, 225)));
            Colors.Add(new ColorUtils(NameType.CornflowerBlue, new Color(100, 149, 237)));
            Colors.Add(new ColorUtils(NameType.LightSteelBlue, new Color(176, 196, 222)));
            Colors.Add(new ColorUtils(NameType.LightSlateGray, new Color(119, 136, 153)));
            Colors.Add(new ColorUtils(NameType.SlateGray, new Color(112, 128, 144)));
            Colors.Add(new ColorUtils(NameType.DoderBlue, new Color(30, 144, 255)));
            Colors.Add(new ColorUtils(NameType.AliceBlue, new Color(240, 248, 255)));
            Colors.Add(new ColorUtils(NameType.SteelBlue, new Color(70, 130, 180)));
            Colors.Add(new ColorUtils(NameType.LightSkyBlue, new Color(135, 206, 250)));
            Colors.Add(new ColorUtils(NameType.SkyBlue, new Color(135, 206, 235)));
            Colors.Add(new ColorUtils(NameType.DeepSkyBlue, new Color(0, 191, 255)));
            Colors.Add(new ColorUtils(NameType.LightBLue, new Color(173, 216, 230)));
            Colors.Add(new ColorUtils(NameType.PowDerBlue, new Color(176, 224, 230)));
            Colors.Add(new ColorUtils(NameType.CadetBlue, new Color(95, 158, 160)));
            Colors.Add(new ColorUtils(NameType.Azure, new Color(240, 255, 255)));
            Colors.Add(new ColorUtils(NameType.LightCyan, new Color(225, 255, 255)));
            Colors.Add(new ColorUtils(NameType.PaleTurquoise, new Color(175, 238, 238)));
            Colors.Add(new ColorUtils(NameType.Cyan, new Color(0, 255, 255)));
            Colors.Add(new ColorUtils(NameType.Aqua, new Color(212, 242, 231)));
            Colors.Add(new ColorUtils(NameType.DarkTurquoise, new Color(0, 206, 209)));
            Colors.Add(new ColorUtils(NameType.DarkSlateGray, new Color(47, 79, 79)));
            Colors.Add(new ColorUtils(NameType.DarkCyan, new Color(0, 139, 139)));
            Colors.Add(new ColorUtils(NameType.Teal, new Color(0, 128, 128)));
            Colors.Add(new ColorUtils(NameType.MediumTurquoise, new Color(72, 209, 204)));
            Colors.Add(new ColorUtils(NameType.LightSeaGreen, new Color(32, 178, 170)));
            Colors.Add(new ColorUtils(NameType.Turquoise, new Color(64, 224, 208)));
            Colors.Add(new ColorUtils(NameType.Auqamarin, new Color(127, 255, 170)));
            Colors.Add(new ColorUtils(NameType.MediumAquamarine, new Color(0, 250, 154)));
            Colors.Add(new ColorUtils(NameType.MediumSpringGreen, new Color(0, 255, 127)));
            Colors.Add(new ColorUtils(NameType.MintCream, new Color(245, 255, 250)));
            Colors.Add(new ColorUtils(NameType.SpringGreen, new Color(60, 179, 113)));
            Colors.Add(new ColorUtils(NameType.SeaGreen, new Color(46, 139, 87)));
            Colors.Add(new ColorUtils(NameType.Honeydew, new Color(240, 255, 240)));
            Colors.Add(new ColorUtils(NameType.LightGreen, new Color(144, 238, 144)));
            Colors.Add(new ColorUtils(NameType.PaleGreen, new Color(152, 251, 152)));
            Colors.Add(new ColorUtils(NameType.DarkSeaGreen, new Color(143, 188, 143)));
            Colors.Add(new ColorUtils(NameType.LimeGreen, new Color(50, 205, 50)));
            Colors.Add(new ColorUtils(NameType.Lime, new Color(0, 255, 0)));
            Colors.Add(new ColorUtils(NameType.ForestGreen, new Color(34, 139, 34)));
            Colors.Add(new ColorUtils(NameType.Green, new Color(0, 128, 0)));
            Colors.Add(new ColorUtils(NameType.DarkGreen, new Color(0, 100, 0)));
            Colors.Add(new ColorUtils(NameType.Chartreuse, new Color(127, 255, 0)));
            Colors.Add(new ColorUtils(NameType.LawnGreen, new Color(124, 252, 0)));
            Colors.Add(new ColorUtils(NameType.GreenYellow, new Color(173, 255, 47)));
            Colors.Add(new ColorUtils(NameType.OliveDrab, new Color(85, 107, 47)));
            Colors.Add(new ColorUtils(NameType.Beige, new Color(245, 245, 220)));
            Colors.Add(new ColorUtils(NameType.LightGoldenrodYellow, new Color(250, 250, 210)));
            Colors.Add(new ColorUtils(NameType.Ivory, new Color(255, 255, 240)));
            Colors.Add(new ColorUtils(NameType.LightYellow, new Color(255, 255, 224)));
            Colors.Add(new ColorUtils(NameType.Yellow, new Color(255, 255, 0)));
            Colors.Add(new ColorUtils(NameType.Olive, new Color(128, 128, 0)));
            Colors.Add(new ColorUtils(NameType.DarkKhaki, new Color(189, 183, 107)));
            Colors.Add(new ColorUtils(NameType.LemonChiffon, new Color(255, 250, 205)));
            Colors.Add(new ColorUtils(NameType.PaleGodenrod, new Color(238, 232, 170)));
            Colors.Add(new ColorUtils(NameType.Khaki, new Color(240, 230, 140)));
            Colors.Add(new ColorUtils(NameType.Gold, new Color(255, 215, 0)));
            Colors.Add(new ColorUtils(NameType.Cornislk, new Color(255, 248, 220)));
            Colors.Add(new ColorUtils(NameType.GoldEnrod, new Color(218, 165, 32)));
            Colors.Add(new ColorUtils(NameType.FloralWhite, new Color(255, 250, 240)));
            Colors.Add(new ColorUtils(NameType.OldLace, new Color(253, 245, 230)));
            Colors.Add(new ColorUtils(NameType.Wheat, new Color(245, 222, 179)));
            Colors.Add(new ColorUtils(NameType.Moccasin, new Color(255, 228, 181)));
            Colors.Add(new ColorUtils(NameType.Orange, new Color(255, 165, 0)));
            Colors.Add(new ColorUtils(NameType.PapayaWhip, new Color(255, 239, 213)));
            Colors.Add(new ColorUtils(NameType.BlanchedAlmond, new Color(255, 235, 205)));
            Colors.Add(new ColorUtils(NameType.NavajoWhite, new Color(255, 222, 173)));
            Colors.Add(new ColorUtils(NameType.AntiqueWhite, new Color(250, 235, 215)));
            Colors.Add(new ColorUtils(NameType.Tan, new Color(210, 180, 140)));
            Colors.Add(new ColorUtils(NameType.BrulyWood, new Color(222, 184, 135)));
            Colors.Add(new ColorUtils(NameType.Bisque, new Color(255, 228, 196)));
            Colors.Add(new ColorUtils(NameType.DarkOrange, new Color(255, 140, 0)));
            Colors.Add(new ColorUtils(NameType.Linen, new Color(250, 240, 230)));
            Colors.Add(new ColorUtils(NameType.Peru, new Color(205, 133, 63)));
            Colors.Add(new ColorUtils(NameType.PeachPuff, new Color(255, 218, 185)));
            Colors.Add(new ColorUtils(NameType.SandyBrown, new Color(244, 164, 96)));
            Colors.Add(new ColorUtils(NameType.Chocolate, new Color(210, 105, 30)));
            Colors.Add(new ColorUtils(NameType.SaddleBrown, new Color(139, 69, 19)));
            Colors.Add(new ColorUtils(NameType.SeaShell, new Color(255, 245, 238)));
            Colors.Add(new ColorUtils(NameType.Sienna, new Color(160, 82, 45)));
            Colors.Add(new ColorUtils(NameType.LightSalmon, new Color(255, 160, 122)));
            Colors.Add(new ColorUtils(NameType.Coral, new Color(255, 127, 80)));
            Colors.Add(new ColorUtils(NameType.OrangeRed, new Color(255, 69, 0)));
            Colors.Add(new ColorUtils(NameType.DarkSalmon, new Color(233, 150, 122)));
            Colors.Add(new ColorUtils(NameType.Tomato, new Color(255, 99, 71)));
            Colors.Add(new ColorUtils(NameType.MistyRose, new Color(255, 228, 225)));
            Colors.Add(new ColorUtils(NameType.Salmon, new Color(250, 128, 114)));
            Colors.Add(new ColorUtils(NameType.Snow, new Color(255, 250, 250)));
            Colors.Add(new ColorUtils(NameType.LightCoral, new Color(240, 128, 128)));
            Colors.Add(new ColorUtils(NameType.RosyBrown, new Color(188, 143, 143)));
            Colors.Add(new ColorUtils(NameType.IndianRed, new Color(205, 92, 92)));
            Colors.Add(new ColorUtils(NameType.Red, new Color(255, 0, 0)));
            Colors.Add(new ColorUtils(NameType.Brown, new Color(165, 42, 42)));
            Colors.Add(new ColorUtils(NameType.FireBrick, new Color(178, 34, 34)));
            Colors.Add(new ColorUtils(NameType.DarkRed, new Color(139, 0, 0)));
            Colors.Add(new ColorUtils(NameType.Maroon, new Color(128, 0, 0)));
            Colors.Add(new ColorUtils(NameType.White, new Color(255, 255, 255)));
            Colors.Add(new ColorUtils(NameType.WhiteSmoke, new Color(245, 245, 245)));
            Colors.Add(new ColorUtils(NameType.Gainsboro, new Color(220, 220, 220)));
            Colors.Add(new ColorUtils(NameType.LightGrey, new Color(211, 211, 211)));
            Colors.Add(new ColorUtils(NameType.Silver, new Color(192, 192, 192)));
            Colors.Add(new ColorUtils(NameType.DarkGray, new Color(169, 169, 169)));
            Colors.Add(new ColorUtils(NameType.Gray, new Color(128, 128, 128)));
            Colors.Add(new ColorUtils(NameType.DimGray, new Color(105, 105, 105)));
            Colors.Add(new ColorUtils(NameType.Black, new Color(0, 0, 0)));
        }

        public static Color GetColorByNameType(NameType nameType)
        {
            foreach (var variable in Colors.Where(it => it._name == nameType))
            {
                return variable._color;
            }

            return new Color(0, 0, 0);
        }

        public static NameType GetNameTypeByColor(Color color)
        {
            foreach (var variable in Colors.Where(it => it._color == color))
            {
                return variable._name;
            }

            return NameType.Black;
        }

        public enum NameType
        {
            LightPink,
            Pink,
            Crimson,
            LavenderBlush,
            PaleVioletRed,
            HotPink,
            DeepPink,
            MediumVioletRed,
            Orchid,
            Thistle,
            Plum,
            Violet,
            Magenta,
            Fuchsia,
            DarkMagenta,
            Purple,
            MediumOrchid,
            DarkVoilet,
            DarkOrchid,
            Indigo,
            BlueViolet,
            MediumPurple,
            MediumSlateBlue,
            SlateBlue,
            DarkSlateBlue,
            Lavender,
            GhostWhite,
            Blue,
            MediumBlue,
            MidnightBlue,
            DarkBlue,
            Navy,
            RoyalBlue,
            CornflowerBlue,
            LightSteelBlue,
            LightSlateGray,
            SlateGray,
            DoderBlue,
            AliceBlue,
            SteelBlue,
            LightSkyBlue,
            SkyBlue,
            DeepSkyBlue,
            LightBLue,
            PowDerBlue,
            CadetBlue,
            Azure,
            LightCyan,
            PaleTurquoise,
            Cyan,
            Aqua,
            DarkTurquoise,
            DarkSlateGray,
            DarkCyan,
            Teal,
            MediumTurquoise,
            LightSeaGreen,
            Turquoise,
            Auqamarin,
            MediumAquamarine,
            MediumSpringGreen,
            MintCream,
            SpringGreen,
            SeaGreen,
            Honeydew,
            LightGreen,
            PaleGreen,
            DarkSeaGreen,
            LimeGreen,
            Lime,
            ForestGreen,
            Green,
            DarkGreen,
            Chartreuse,
            LawnGreen,
            GreenYellow,
            OliveDrab,
            Beige,
            LightGoldenrodYellow,
            Ivory,
            LightYellow,
            Yellow,
            Olive,
            DarkKhaki,
            LemonChiffon,
            PaleGodenrod,
            Khaki,
            Gold,
            Cornislk,
            GoldEnrod,
            FloralWhite,
            OldLace,
            Wheat,
            Moccasin,
            Orange,
            PapayaWhip,
            BlanchedAlmond,
            NavajoWhite,
            AntiqueWhite,
            Tan,
            BrulyWood,
            Bisque,
            DarkOrange,
            Linen,
            Peru,
            PeachPuff,
            SandyBrown,
            Chocolate,
            SaddleBrown,
            SeaShell,
            Sienna,
            LightSalmon,
            Coral,
            OrangeRed,
            DarkSalmon,
            Tomato,
            MistyRose,
            Salmon,
            Snow,
            LightCoral,
            RosyBrown,
            IndianRed,
            Red,
            Brown,
            FireBrick,
            DarkRed,
            Maroon,
            White,
            WhiteSmoke,
            Gainsboro,
            LightGrey,
            Silver,
            DarkGray,
            Gray,
            DimGray,
            Black
        }
    }
}