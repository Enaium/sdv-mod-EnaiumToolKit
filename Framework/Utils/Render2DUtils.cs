using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Utils
{
    public class Render2DUtils
    {
        public static bool isHovered(int mouseX, int mouseY, int x, int y, int width, int height)
        {
            return mouseX >= x && mouseX - width <= x && mouseY >= y && mouseY - height <= y;
        }

        public static void drawRect(SpriteBatch b, int x, int y, int widht, int height, Color color)
        {
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), x, y,
                widht, height, color, 4f, false);
        }
    }
}