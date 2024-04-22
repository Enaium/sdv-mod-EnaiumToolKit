using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Components;

public class ArrowButton : BaseButton
{
    public bool Up = true;
    public static readonly int Width = 44;
    public static readonly int Height = 48;

    public ArrowButton(int x, int y) : base("", "", x, y, 44, 48)
    {
    }

    public override void Render(SpriteBatch b)
    {
        Utility.drawWithShadow(b, Game1.mouseCursors, new Vector2(X, Y), new Rectangle(421, Up ? 459 : 472, 11, 12),
            Color.White, 0.0f, Vector2.Zero, 4f, false, 0.15f);
        base.Render(b);
    }
}