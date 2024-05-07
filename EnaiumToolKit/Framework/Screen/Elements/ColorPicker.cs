using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ColorPicker : Element
{
    [Obsolete] public Color Color;

    public Color Current
    {
        get => Color;
        set => Color = value;
    }

    private readonly SliderBar _red = new("Red", null, 0, byte.MaxValue);

    private readonly SliderBar _green = new("Green", null, 0, byte.MaxValue);

    private readonly SliderBar _blue = new("Blue", null, 0, byte.MaxValue);

    private readonly SliderBar _alpha = new("Alpha", null, 0, byte.MaxValue);

    [Obsolete] public Action? OnColorChanged = null;

    public Action<Color>? OnCurrentChanged = null;

    public ColorPicker(string title, string? description, Color color) : base(title, description)
    {
        Color = color;
        _red.Current = color.R;
        _green.Current = color.G;
        _blue.Current = color.B;
        _alpha.Current = color.A;
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = new Rectangle(x, y, Width, Height).Contains(Game1.getMouseX(), Game1.getMouseY());
        b.Draw(Game1.staminaRect, new Rectangle(x, y, Width, Height),
            Color = new Color(_red.Current, _green.Current, _blue.Current, _alpha.Current));
        _red.Width = Width / 2;
        _red.Height = Height / 2;
        _red.Render(b, x, y);
        _green.Width = Width / 2;
        _green.Height = Height / 2;
        _green.Render(b, x + Width / 2, y);
        _blue.Width = Width / 2;
        _blue.Height = Height / 2;
        _blue.Render(b, x, y + Height / 2);
        _alpha.Width = Width / 2;
        _alpha.Height = Height / 2;
        _alpha.Render(b, x + Width / 2, y + Height / 2);

        var change = (int i) =>
        {
            OnColorChanged?.Invoke();
            OnCurrentChanged?.Invoke(Current);
        };

        _red.OnCurrentChanged = change;
        _green.OnCurrentChanged = change;
        _blue.OnCurrentChanged = change;
        _alpha.OnCurrentChanged = change;
        
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        if (_red.Hovered)
        {
            _red.MouseLeftClicked(x, y);
        }
        
        if (_green.Hovered)
        {
            _green.MouseLeftClicked(x, y);
        }

        if (_blue.Hovered)
        {
            _blue.MouseLeftClicked(x, y);
        }
        
        if (_alpha.Hovered)
        {
            _alpha.MouseLeftClicked(x, y);
        }
        base.MouseLeftClicked(x, y);
    }

    public override void MouseLeftReleased(int x, int y)
    {
        if (_red.Hovered)
        {
            _red.MouseLeftReleased(x, y);
        }
        
        if (_green.Hovered)
        {
            _green.MouseLeftReleased(x, y);
        }
        
        if (_blue.Hovered)
        {
            _blue.MouseLeftReleased(x, y);
        }
        
        if (_alpha.Hovered)
        {
            _alpha.MouseLeftReleased(x, y);
        }
        
        base.MouseLeftReleased(x, y);
    }

    public override void LostFocus(int x, int y)
    {
        _red.LostFocus(x, y);
        _green.LostFocus(x, y);
        _blue.LostFocus(x, y);
        _alpha.LostFocus(x, y);
        base.LostFocus(x, y);
    }
}