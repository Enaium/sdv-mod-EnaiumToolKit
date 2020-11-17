using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;
using StardewValley.Objects;

namespace EnaiumToolKit.Framework.Screen.Elements
{
    public class ColorSelect : Element
    {
        private int _hoverColorSelection;
        public int Color;

        public ColorSelect(string title, string description) : base(title, description)
        {
        }

        public Color GetColorFromSelection(int selection)
        {
            switch (selection)
            {
                case 1:
                    return new Color(85, 85, byte.MaxValue);
                case 2:
                    return new Color(119, 191, byte.MaxValue);
                case 3:
                    return new Color(0, 170, 170);
                case 4:
                    return new Color(0, 234, 175);
                case 5:
                    return new Color(0, 170, 0);
                case 6:
                    return new Color(159, 236, 0);
                case 7:
                    return new Color(byte.MaxValue, 234, 18);
                case 8:
                    return new Color(byte.MaxValue, 167, 18);
                case 9:
                    return new Color(byte.MaxValue, 105, 18);
                case 10:
                    return new Color(byte.MaxValue, 0, 0);
                case 11:
                    return new Color(135, 0, 35);
                case 12:
                    return new Color(byte.MaxValue, 173, 199);
                case 13:
                    return new Color(byte.MaxValue, 117, 195);
                case 14:
                    return new Color(172, 0, 198);
                case 15:
                    return new Color(143, 0, byte.MaxValue);
                case 16:
                    return new Color(89, 11, 142);
                case 17:
                    return new Color(64, 64, 64);
                case 18:
                    return new Color(100, 100, 100);
                case 19:
                    return new Color(200, 200, 200);
                case 20:
                    return new Color(254, 254, 254);
                default:
                    return Microsoft.Xna.Framework.Color.Black;
            }
        }

        public override void Render(SpriteBatch b, int x, int y)
        {
            Hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);

            for (var selection = 0; selection < 21; ++selection)
            {
                const int colorSize = 28;
                var colorX = x + IClickableMenu.borderWidth / 2 - colorSize / 2 + selection * 38;
                var colorY = y + IClickableMenu.borderWidth / 2;
                b.Draw(Game1.staminaRect, new Rectangle(colorX, colorY, colorSize, colorSize),
                    GetColorFromSelection(selection));

                if (Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), colorX, colorY, colorSize, colorSize))
                {
                    IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(375, 357, 3, 3), colorX - 4,
                        colorY - 4, 36, 36, Microsoft.Xna.Framework.Color.Black, 4f, false);
                    _hoverColorSelection = selection;
                }

                if (selection == Color)
                {
                    IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(375, 357, 3, 3), colorX - 4,
                        colorY - 4, 36, 36, Microsoft.Xna.Framework.Color.Red, 4f, false);
                }
            }
        }

        public override void MouseLeftClicked(int x, int y)
        {
            if (_hoverColorSelection != -1)
                Color = _hoverColorSelection;
            base.MouseLeftClicked(x, y);
        }
    }
}