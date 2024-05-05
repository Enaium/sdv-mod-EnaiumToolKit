using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class SliderBar : BaseButton
{
    public int Current { get; set; }
    
    private readonly int _min;
    private readonly int _max;

    public bool Dragging;

    public Action? OnValueChanged = null;
    public Action<int>? OnCurrentChanged = null;

    public SliderBar(string? title, string? description, int min, int max) : base(title, description)
    {
        _min = min;
        _max = max;
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        var previous = Current;

        var blockWidth = 20;

        if (Hovered)
        {
            if (Dragging)
            {
                if (_max - _min != 0)
                {
                    Current = MathHelper.Clamp((Game1.getMouseX() - x) * (_max - _min) / (Width - blockWidth) + _min,
                        _min, _max);
                    OnValueChanged?.Invoke();
                    OnCurrentChanged?.Invoke(Current);
                    if (previous != Current)
                    {
                        Game1.playSound("shiny4");
                    }
                }
            }
        }
        else
        {
            Dragging = false;
        }

        var sliderOffset = Width - blockWidth;

        if (_max - _min != 0)
        {
            sliderOffset = sliderOffset * (Current - _min) / (_max - _min);
        }
        else
        {
            sliderOffset = 0;
        }

        Render2DUtils.DrawButton(b, x + sliderOffset, y, blockWidth, Height, Color.Wheat);

        if (Title != null)
        {
            FontUtils.DrawHvCentered(b, $"{Title}:{Current}", x, y, Width, Height);   
        }
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        Dragging = true;
    }

    public override void MouseLeftReleased(int x, int y)
    {
        Dragging = false;
    }
}