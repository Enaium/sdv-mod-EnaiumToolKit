using EnaiumToolKit.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Screen.Elements
{
    public class Label : Element
    {
        public Label(string title, string description) : base(title, description)
        {
        }

        public override void render(SpriteBatch b, int x, int y)
        {
            hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, width, height);
            FontUtils.drawHVCentered(b, title, x + width / 2, y + height / 2);
        }
    }
}