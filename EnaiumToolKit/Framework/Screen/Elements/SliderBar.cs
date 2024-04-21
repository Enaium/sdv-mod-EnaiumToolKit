using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class SliderBar : Element
{
    public int Current;

    private int _min;
    private int _max;

    private int _sliderOffset;
    private bool _dragging;

    public SliderBar(string title, string description, int min, int max) : base(title, description)
    {
        _min = min;
        _max = max;
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = Render2DUtils.IsHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);

        if (Hovered)
        {
            if (_dragging)
            {
                _sliderOffset = MathHelper.Clamp(Game1.getMouseX() - x, 0, Width - 20);
                Current = (int)(_min + MathHelper.Clamp((Game1.getMouseX() - x) / (float)Width, 0, 1) * (_max - _min));
            }
        }
        else
        {
            _dragging = false;
        }

        Render2DUtils.DrawButton(b, x + _sliderOffset, y, 20, Height, Color.Wheat);

        FontUtils.DrawHvCentered(b, $"{Title}:{Current}", x, y, Width, Height);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        _dragging = true;
        base.MouseLeftClicked(x, y);
    }

    public override void MouseLeftReleased(int x, int y)
    {
        _dragging = false;
        base.MouseLeftReleased(x, y);
    }
}