using System;
using EnaiumToolKit.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Screen.Elements
{
    public class Button : Element
    {
        public Button(String title, String description) : base(title, description)
        {
        }

        public override void render(SpriteBatch b, int x, int y)
        {
            hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, width, height);

            Render2DUtils.drawRect(b, x, y, width, height, hovered ? Color.Wheat : Color.White);
            FontUtils.drawHVCentered(b, title, x + width / 2, y + height / 2);
        }

        public Action onLeftClicked = () => { };

        public override void mouseLeftClicked(int x, int y)
        {
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
    }
}