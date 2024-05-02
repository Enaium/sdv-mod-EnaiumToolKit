using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class ComboBox<T> : BaseButton
{
    private bool _isOpen;
    public List<T?> Items { get; set; } = new();
    public T? Current { get; set; }

    public Action<T?>? OnCurrentChanged { get; set; }


    public ComboBox(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        IClickableMenu.drawTextureBox(b, Game1.mouseCursors, OptionsDropDown.dropDownBGSource, x, y, Width, Height,
            Color.White, 4f, false);
        if (Current != null)
        {
            FontUtils.DrawHvCentered(b, Current.ToString()!, x, y, Width, Height);
        }

        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        if (Hovered)
        {
            _isOpen = !_isOpen;
        }
        base.MouseLeftClicked(x, y);
    }
}