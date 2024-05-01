﻿using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ValueButton : BaseButton
{
    public int Current;
    public int Min;
    public int Max;
    
    public Action<int>? OnValueChanged = null;

    public ValueButton(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Render2DUtils.DrawButton(b, x, y, Width, Height, Hovered ? Color.White : Color.Wheat);
        FontUtils.DrawHvCentered(b, $"{Title}:({Min}-{Max}){Current}", x, y, Width, Height);
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
        
        OnValueChanged?.Invoke(Current);

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
        
        OnValueChanged?.Invoke(Current);

        Game1.playSound("drumkit5");
        base.MouseRightClicked(x, y);
    }
}