using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class Label : Element
{
    public Label(string title, string description) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = Render2DUtils.IsHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);
        FontUtils.DrawHvCentered(b, Title, x, y, Width, Height);
    }
}