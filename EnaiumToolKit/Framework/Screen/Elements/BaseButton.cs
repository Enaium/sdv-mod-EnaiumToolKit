using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class BaseButton : Element
{
    protected BaseButton(string title, string? description = null) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = Render2DUtils.IsHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);
        if (Hovered)
        {
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(375, 357, 3, 3), x, y, Width, Height,
                Color.Red, 4f, false);
        }
    }

    public override void MouseLeftClicked(int x, int y)
    {
        Game1.playSound("drumkit6");
        base.MouseLeftClicked(x, y);
    }
}