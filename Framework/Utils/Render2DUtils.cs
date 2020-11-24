using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Utils
{
    public class Render2DUtils
    {
        public static bool IsHovered(int mouseX, int mouseY, int x, int y, int width, int height)
        {
            return mouseX >= x && mouseX - width <= x && mouseY >= y && mouseY - height <= y;
        }

        public static void DrawButton(SpriteBatch b, int x, int y, int width, int height, Color color)
        {
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), x, y,
                width, height, color, 4f, false);
        }
        
        public static void DrawBound(SpriteBatch b, int x, int y, int width, int height, Color color)
        {
            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(384, 373, 18, 18), x, y,
                width, height, color, 4f);
        }
    }
}