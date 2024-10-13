using EnaiumToolKit.Framework.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ModeButton : BaseButton
{
    public List<string> Modes { get; set; } = new();

    public string Current;

    public Action<string>? OnCurrentChanged;

    public ModeButton(string title, string? description) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        b.DrawButtonTexture(x, y, Width, Height, Hovered ? Color.Wheat : Color.White);
        b.DrawStringCenter($"{Title}:({GetCurrentIndex() + 1}/{Modes.Count}){Modes[GetCurrentIndex()]}", x, y, Width,
            Height);
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        try
        {
            Current = Modes[GetCurrentIndex() + 1];
        }
        catch (Exception e)
        {
            Current = Modes.First();
        }

        OnCurrentChanged?.Invoke(Current);
        base.MouseLeftClicked(x, y);
    }

    public override void MouseRightClicked(int x, int y)
    {
        try
        {
            Current = Modes[GetCurrentIndex() - 1];
        }
        catch (Exception e)
        {
            Current = Modes.Last();
        }

        OnCurrentChanged?.Invoke(Current);

        Game1.playSound("drumkit5");
        base.MouseRightClicked(x, y);
    }

    private int GetCurrentIndex()
    {
        var index = 0;
        foreach (var variable in Modes)
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