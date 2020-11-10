using System;
using EnaiumToolKit.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Screen.Elements
{
    public class ToggleButton : Element
    {
        private Boolean toggled;

        public ToggleButton(String title, String description, Boolean toggled = false) : base(title, description)
        {
            this.toggled = toggled;
        }

        public override void render(SpriteBatch b, int x, int y)
        {
            hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, width, height);
            
            Color color = Color.White;

            if (toggled)
            {
                color = Color.Green;
            }
            else
            {
                color = Color.Red;
            }

            if (hovered)
            {
                color = Color.Wheat;
            }

            Render2DUtils.drawRect(b, x, y, width, height, color);
            FontUtils.drawHVCentered(b, title, x + width / 2, y + height / 2);
        }
        
        public override void mouseLeftClicked(int x, int y)
        {
            toggled = !toggled;
            base.mouseLeftClicked(x, y);
        }
        
        public Boolean getToggled()
        {
            return toggled;
        }
    }
}