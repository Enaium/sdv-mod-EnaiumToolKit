using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class Label : Element
{
    public Label(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = new Rectangle(x, y, Width, Height).Contains(Game1.getMouseX(), Game1.getMouseY());
        b.DrawStringCenter(Title!, x, y, Width, Height);
    }
}