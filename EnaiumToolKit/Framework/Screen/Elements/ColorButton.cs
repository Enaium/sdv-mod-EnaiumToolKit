using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ColorButton : BaseButton
{
    public Color Color;

    public ColorButton(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        b.Draw(Game1.staminaRect, new Rectangle(x, y, Width, Height), Color);
        FontUtils.DrawHvCentered(b, Title, x, y, Width, Height);
        base.Render(b, x, y);
    }
}