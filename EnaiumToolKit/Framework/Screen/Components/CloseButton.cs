using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Components;

public class CloseButton : BaseButton
{
    public static readonly int Width = 48;
    public static readonly int Height = 48;

    public CloseButton(int x, int y) : base("", "", x, y, Width, Height)
    {
    }

    public override void Render(SpriteBatch b)
    {
        Utility.drawWithShadow(b, Game1.mouseCursors, new Vector2(X, Y), new Rectangle(337, 494, 12, 12),
            Color.White, 0.0f, Vector2.Zero, 4f, false, 0.15f);
        base.Render(b);
    }
}