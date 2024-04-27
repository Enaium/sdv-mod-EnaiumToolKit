using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Components;

public class ScrollBar : BaseButton
{
    private int _min;
    private int _max;
    private int _current;
    private int _previous;
    private bool _dragging;

    public int Min
    {
        get => _min;
        set => _min = value;
    }

    public int Max
    {
        get => _max;
        set => _max = value;
    }

    public int Current
    {
        get => _current;
        set => _current = value;
    }

    public Action OnValueChanged = () => { };

    public ScrollBar(int x, int y, int width, int height) : base(null, null, x, y, width, height)
    {
    }

    public override void Render(SpriteBatch b)
    {
        if (_current != _previous)
        {
            Game1.playSound("shiny4");
            _previous = _current;
        }

        IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(403, 383, 6, 6), X, Y, Width, Height,
            Color.White, 4f, false);

        var blockHeight = 20;

        if (Hovered)
        {
            if (_dragging)
            {
                if (_max - _min != 0)
                {
                    _current = MathHelper.Clamp((Game1.getMouseY() - Y) * (_max - _min) / (Height - blockHeight) + _min,
                        _min, _max);
                    OnValueChanged.Invoke();
                }
            }
        }
        else
        {
            _dragging = false;
        }

        var sliderOffset = Height - blockHeight;

        if (_max - _min != 0)
        {
            sliderOffset = sliderOffset * (_current - _min) / (_max - _min);
        }
        else
        {
            sliderOffset = 0;
        }

        Render2DUtils.DrawButton(b, X, Y + sliderOffset, Width, blockHeight, Color.Wheat);

        base.Render(b);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        _dragging = true;
    }

    public override void MouseLeftReleased(int x, int y)
    {
        _dragging = false;
    }
}