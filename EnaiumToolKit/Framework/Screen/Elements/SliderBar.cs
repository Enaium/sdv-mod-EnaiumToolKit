using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class SliderBar : BaseButton
{
    private int _current;

    public int Current
    {
        get => _current;
        set
        {
            _current = value;
            _previous = value;
        }
    }

    private int _previous;

    private int _min;
    private int _max;

    public bool Dragging;

    public SliderBar(string title, string description, int min, int max) : base(title, description)
    {
        _min = min;
        _max = max;
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        if (_current != _previous)
        {
            Game1.playSound("shiny4");
            _previous = _current;
        }

        var blockWidth = 20;

        if (Hovered)
        {
            if (Dragging)
            {
                if (_max - _min != 0)
                {
                    _current = (int)(_min +
                                     MathHelper.Clamp((Game1.getMouseX() - x) / (float)(Width - blockWidth), 0, 1) *
                                     (_max - _min));
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
            sliderOffset = sliderOffset * (_current - _min) / (_max - _min);
        }
        else
        {
            sliderOffset = 0;
        }

        Render2DUtils.DrawButton(b, x + sliderOffset, y, blockWidth, Height, Color.Wheat);

        FontUtils.DrawHvCentered(b, $"{Title}:{_current}", x, y, Width, Height);
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