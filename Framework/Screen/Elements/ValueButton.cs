using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements
{
    public class ValueButton : Element
    {
        private int _current;
        private int min;
        private int max;

        public ValueButton(string title, string description, int current, int min, int max) : base(title,
            description)
        {
            this._current = current;
            this.min = min;
            this.max = max;
        }

        public override void Render(SpriteBatch b, int x, int y)
        {
            Hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);

            Render2DUtils.drawRect(b, x, y, Width, Height, Hovered ? Color.Wheat : Color.White);
            FontUtils.DrawHvCentered(b, $"{Title}:({min}-{max}){_current}", x + Width / 2, y + Height / 2);
        }

        public override void MouseLeftClicked(int x, int y)
        {
            if (_current < max)
            {
                _current += 1;
            }

            base.MouseLeftClicked(x, y);
        }

        public override void MouseRightClicked(int x, int y)
        {
            if (_current > min)
            {
                _current -= 1;
            }

            base.MouseRightClicked(x, y);
        }
    }
}