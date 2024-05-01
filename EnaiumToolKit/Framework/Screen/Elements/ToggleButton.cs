using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ToggleButton : BaseButton
{
    public bool Toggled;
    
    public Action<bool>? OnValueChanged = null;

    public ToggleButton(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        var color = Toggled ? Color.Green : Color.Red;
        Render2DUtils.DrawButton(b, x, y, Width, Height, color);
        FontUtils.DrawHvCentered(b, Title, x, y, Width, Height);
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        Toggled = !Toggled;
        OnValueChanged?.Invoke(Toggled);
        Game1.playSound(Toggled ? "drumkit6" : "drumkit5");
        base.MouseLeftClicked(x, y);
    }
}