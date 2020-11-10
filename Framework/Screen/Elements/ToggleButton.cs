using System;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements
{
    public class ToggleButton : Element
    {
        private bool _toggled;

        public ToggleButton(string title, string description, bool toggled = false) : base(title, description)
        {
            _toggled = toggled;
        }

        public override void Render(SpriteBatch b, int x, int y)
        {
            Hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);

            Color color;

            if (_toggled)
            {
                color = Color.Green;
            }
            else
            {
                color = Color.Red;
            }

            if (Hovered)
            {
                color = Color.Wheat;
            }

            Render2DUtils.drawRect(b, x, y, Width, Height, color);
            FontUtils.DrawHvCentered(b, Title, x + Width / 2, y + Height / 2);
        }

        public override void MouseLeftClicked(int x, int y)
        {
            _toggled = !_toggled;
            base.MouseLeftClicked(x, y);
        }

        public bool GetToggled()
        {
            return _toggled;
        }
    }
}