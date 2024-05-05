using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class Button : BaseButton
{
    public Button(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Render2DUtils.DrawButton(b, x, y, Width, Height, Color.Wheat);
        FontUtils.DrawHvCentered(b, Title!, x, y, Width, Height);
        base.Render(b, x, y);
    }
}