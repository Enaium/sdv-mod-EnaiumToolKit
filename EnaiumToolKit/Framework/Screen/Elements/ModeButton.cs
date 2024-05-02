using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ModeButton : BaseButton
{
    [Obsolete]
    public List<string> modes = new();

    public List<string> Modes
    {
        get => modes;
        set => modes = value;
    }
    public string Current;
    
    public Action<string>? OnCurrentChanged;

    public ModeButton(string title, string? description) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Render2DUtils.DrawButton(b, x, y, Width, Height, Hovered ? Color.Wheat : Color.White);
        FontUtils.DrawHvCentered(b, $"{Title}:({GetCurrentIndex() + 1}/{modes.Count}){modes[GetCurrentIndex()]}", x, y,
            Width, Height);
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        try
        {
            Current = modes[GetCurrentIndex() + 1];
        }
        catch (Exception e)
        {
            Current = modes.First();
        }
        OnCurrentChanged?.Invoke(Current);

        Game1.playSound("drumkit6");
        base.MouseLeftClicked(x, y);
    }

    public override void MouseRightClicked(int x, int y)
    {
        try
        {
            Current = modes[GetCurrentIndex() - 1];
        }
        catch (Exception e)
        {
            Current = modes.Last();
        }
        OnCurrentChanged?.Invoke(Current);

        Game1.playSound("drumkit5");
        base.MouseRightClicked(x, y);
    }

    private int GetCurrentIndex()
    {
        var index = 0;
        foreach (var variable in modes)
        {
            if (variable.Equals(Current))
            {
                return index;
            }

            index++;
        }

        return index;
    }
}