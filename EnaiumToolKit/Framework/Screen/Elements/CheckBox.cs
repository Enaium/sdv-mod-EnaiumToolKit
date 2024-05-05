using EnaiumToolKit.Framework.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class CheckBox : BaseButton
{
    public bool Current;
    public Action<bool>? OnCurrentChanged = null;

    public CheckBox(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        b.DrawStringVCenter(Title!, x, y, Height);
        b.DrawCheckboxTexture(new Vector2(x + Width - 36, y + Height / 2f - 36 / 2f), Current);
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        Current = !Current;
        OnCurrentChanged?.Invoke(Current);
        base.MouseLeftClicked(x, y);
    }
}