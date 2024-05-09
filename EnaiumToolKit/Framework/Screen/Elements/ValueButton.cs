using EnaiumToolKit.Framework.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ValueButton : BaseButton
{
    public int Current;
    public int Min;
    public int Max;

    public Action<int>? OnCurrentChanged = null;

    public ValueButton(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        b.DrawButtonTexture(x, y, Width, Height, Hovered ? Color.Wheat : Color.White);
        b.DrawStringCenter($"{Title}:({Min}-{Max}){Current}", x, y, Width, Height);
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        if (Current < Max)
        {
            Current += 1;
        }
        else
        {
            Current = Min;
        }

        OnCurrentChanged?.Invoke(Current);

        Game1.playSound("drumkit6");
        base.MouseLeftClicked(x, y);
    }

    public override void MouseRightClicked(int x, int y)
    {
        if (Current > Min)
        {
            Current -= 1;
        }
        else
        {
            Current = Max;
        }

        OnCurrentChanged?.Invoke(Current);

        Game1.playSound("drumkit5");
        base.MouseRightClicked(x, y);
    }
}