using EnaiumToolKit.Framework.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ToggleButton : BaseButton
{
    public bool Current { get; set; }

    public Action<bool>? OnCurrentChanged = null;

    public ToggleButton(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        var color = Current ? Color.Green : Color.Red;
        b.DrawButtonTexture(x, y, Width, Height, color);
        b.DrawStringCenter(Title!, x, y, Width, Height);
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        Current = !Current;
        OnCurrentChanged?.Invoke(Current);
        if (!Current)
        {
            Game1.playSound("drumkit5");
        }

        base.MouseLeftClicked(x, y);
    }
}