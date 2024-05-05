using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Components;

public class Button : BaseButton
{
    public Button(string title, string description, int x, int y, int width, int height) : base(title, description, x,
        y, width, height)
    {
    }

    public override void Render(SpriteBatch b)
    {
        b.DrawButtonTexture(X, Y, Width, Height, Hovered ? Color.Wheat : Color.White);
        b.DrawStringCenter(Title!, Bounds);
        base.Render(b);
    }
}