using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Components;

public class BaseButton : Component
{
    protected BaseButton(string? title, string? description, int x, int y, int width, int height) : base(title, description,
        x, y, width, height)
    {
    }

    public override void Render(SpriteBatch b)
    {
        Hovered = Render2DUtils.IsHovered(Game1.getMouseX(), Game1.getMouseY(), X, Y, Width, Height);
        if (Hovered)
        {
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(375, 357, 3, 3), X, Y, Width, Height,
                Color.Red, 4f, false);
        }
    } 

    public override void MouseLeftClicked(int x, int y)
    {
        
        Game1.playSound("drumkit6");
        base.MouseLeftClicked(x, y);
    }
}