using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ColorButton : Element
{
    public Color Color;

    public ColorButton(string title, string description) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = Render2DUtils.IsHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);
        b.Draw(Game1.staminaRect, new Rectangle(x, y, Width, Height), Color);
        FontUtils.DrawHvCentered(b, Title, x + Width / 2, y + Height / 2);
    }
}