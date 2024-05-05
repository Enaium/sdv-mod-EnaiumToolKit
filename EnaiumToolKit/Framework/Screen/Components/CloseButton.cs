using EnaiumToolKit.Framework.Extensions;
using Microsoft.Xna.Framework.Graphics;

namespace EnaiumToolKit.Framework.Screen.Components;

public class CloseButton : BaseButton
{
    public static readonly int Width = 48;
    public static readonly int Height = 48;

    public CloseButton(int x, int y) : base(null, null, x, y, Width, Height)
    {
    }

    public override void Render(SpriteBatch b)
    {
        b.DrawCloseTexture(X, Y);
        base.Render(b);
    }
}