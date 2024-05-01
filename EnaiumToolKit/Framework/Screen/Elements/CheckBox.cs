using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class CheckBox : BaseButton
{
    public bool Value;
    public Action<bool>? OnValueChanged = null;

    public CheckBox(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        FontUtils.DrawVCentered(b, Title, x, y, Height);
        Utility.drawWithShadow(b, Game1.mouseCursors, new Vector2(x + Width - 36, y + Height / 2f - 36 / 2f), new Rectangle(Value ? 236 : 227, 425, 9, 9),
            Color.White, 0.0f, Vector2.Zero, 4f, false, 0.15f);
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        if (Hovered)
        {
            Value = !Value;
            OnValueChanged?.Invoke(Value);
        }

        base.MouseLeftClicked(x, y);
    }
}