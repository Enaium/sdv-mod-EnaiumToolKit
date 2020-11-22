using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Components
{
    public class Button : Component
    {
        public Button(string title, string description, int x, int y, int width, int height) : base(title, description,
            x, y, width, height)
        {
        }

        public override void Render(SpriteBatch b)
        {
            Hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), X, Y, Width, Height);

            Render2DUtils.drawRect(b, X, Y, Width, Height, Hovered ? Color.Wheat : Color.White);
            FontUtils.DrawHvCentered(b, Title, X + Width / 2, Y + Height / 2);
        }
    }
    
    
}