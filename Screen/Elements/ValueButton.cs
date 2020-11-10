using System.Collections.Generic;
using EnaiumToolKit.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Screen.Elements
{
    public class ValueButton : Element
    {
        private int current;
        private int min;
        private int max;

        public ValueButton(string title, string description, int current, int min, int max) : base(title,
            description)
        {
            this.current = current;
            this.min = min;
            this.max = max;
        }

        public override void render(SpriteBatch b, int x, int y)
        {
            hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, width, height);

            Render2DUtils.drawRect(b, x, y, width, height, hovered ? Color.Wheat : Color.White);
            FontUtils.drawHVCentered(b, $"{title}:({min}-{max}){current}", x + width / 2, y + height / 2);
        }

        public override void mouseLeftClicked(int x, int y)
        {

            if (current < max)
            {
                current += 1;
            }

            base.mouseLeftClicked(x, y);
        }

        public override void mouseRightClicked(int x, int y)
        {
            
            if (current > min)
            {
                current -= 1;
            }
            
            base.mouseRightClicked(x, y);
        }
    }
}