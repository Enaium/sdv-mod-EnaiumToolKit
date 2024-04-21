using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class Button : Element
{
    public Button(string title, string description) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = Render2DUtils.IsHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);
        Render2DUtils.DrawButton(b, x, y, Width, Height, Color.Wheat);
        if (Hovered)
        {
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(375, 357, 3, 3), x, y, Width, Height,
                Color.Black, 4f, false);
        }

        FontUtils.DrawHvCentered(b, Title, x, y, Width, Height);
    }
}