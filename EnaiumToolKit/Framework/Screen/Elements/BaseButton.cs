using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class BaseButton : Element
{
    protected BaseButton(string? title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        if (Hovered)
        {
            b.DrawBoundsTexture(x, y, Width, Height);
        }

        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        Game1.playSound("drumkit6");
        base.MouseLeftClicked(x, y);
    }
}