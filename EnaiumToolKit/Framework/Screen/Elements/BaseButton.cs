using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class BaseButton : Element
{
    protected BaseButton(string? title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = new Rectangle(x, y, Width, Height).Contains(Game1.getMouseX(), Game1.getMouseY());
        if (Hovered)
        {
            b.DrawBoundsTexture(x, y, Width, Height);
        }
    }

    public override void MouseLeftClicked(int x, int y)
    {
        Game1.playSound("drumkit6");
        base.MouseLeftClicked(x, y);
    }
}