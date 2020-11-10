using System;
using EnaiumToolKit.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Screen.Elements
{
    public class Toggle : Element
    {
        private Boolean toggled;

        public Toggle(String title, String description, Boolean toggled) : base(title, description)
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

        public Action onLeftClicked = () => { };

        public override void mouseLeftClicked(int x, int y)
        {
            toggled = !toggled;
            onLeftClicked.Invoke();
            base.mouseLeftClicked(x, y);
        }

        public Action onLeftReleased = () => { };

        public override void mouseLeftReleased(int x, int y)
        {
            onLeftReleased.Invoke();
            base.mouseLeftReleased(x, y);
        }

        public Action onRightClicked = () => { };

        public override void mouseRightClicked(int x, int y)
        {
            onRightClicked.Invoke();
            base.mouseRightClicked(x, y);
        }

        public Boolean getToggled()
        {
            return toggled;
        }
    }
}