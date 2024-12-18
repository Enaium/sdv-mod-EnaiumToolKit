﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Components;

public class ArrowButton : BaseButton
{
    public DirectionType Direction = DirectionType.Up;
    public new const int Width = 48;
    public new const int Height = 48;

    public ArrowButton(int x, int y) : base(null, null, x, y, Width, Height)
    {
    }

    public override void Render(SpriteBatch b)
    {
        Rectangle rectangle = Direction switch
        {
            DirectionType.Up => new Rectangle(421, 459, 11, 12),
            DirectionType.Down => new Rectangle(421, 472, 11, 12),
            DirectionType.Left => new Rectangle(352, 494, 12, 11),
            DirectionType.Right => new Rectangle(365, 494, 12, 11),
            _ => new Rectangle(421, 459, 11, 12)
        };
        Utility.drawWithShadow(b, Game1.mouseCursors, new Vector2(X, Y), rectangle,
            Color.White, 0.0f, Vector2.Zero, 4f, false, 0.15f);
        base.Render(b);
    }

    public enum DirectionType
    {
        Up,
        Down,
        Left,
        Right
    }
}