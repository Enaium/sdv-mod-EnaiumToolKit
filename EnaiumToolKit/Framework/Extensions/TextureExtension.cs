using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Extensions;

public static class TextureExtension
{
    public static void DrawButtonTexture(this SpriteBatch b, int x, int y, int width, int height, Color? color = null)
    {
        IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(432, 439, 9, 9), x, y,
            width, height, color ?? Color.White, 4f, false);
    }

    public static void DrawButtonTexture(this SpriteBatch b, Rectangle bounds, Color? color = null)
    {
        DrawButtonTexture(b, bounds.X, bounds.Y, bounds.Width, bounds.Height, color);
    }

    public static void DrawWindowTexture(this SpriteBatch b, int x, int y, int width, int height, Color? color = null)
    {
        IClickableMenu.drawTextureBox(b, Game1.menuTexture, new Rectangle(0, 256, 60, 60), x, y,
            width, height, color ?? Color.White);
    }

    public static void DrawWindowTexture(this SpriteBatch b, Rectangle bounds, Color? color = null)
    {
        IClickableMenu.drawTextureBox(b, Game1.menuTexture, new Rectangle(0, 256, 60, 60), bounds.X, bounds.Y,
            bounds.Width, bounds.Height, color ?? Color.White);
    }

    public static void DrawBoundsTexture(this SpriteBatch b, int x, int y, int width, int height, Color? color = null)
    {
        IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(379, 357, 3, 3), x, y,
            width, height, color ?? Color.White, 4f, false);
    }

    public static void DrawBoundsTexture(this SpriteBatch b, Rectangle bounds, Color? color = null)
    {
        IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(379, 357, 3, 3), bounds.X, bounds.Y,
            bounds.Width, bounds.Height, color ?? Color.White, 4f, false);
    }

    public static void DrawCloseTexture(this SpriteBatch b, int x, int y)
    {
        Utility.drawWithShadow(b, Game1.mouseCursors, new Vector2(x, y), new Rectangle(337, 494, 12, 12),
            Color.White, 0.0f, Vector2.Zero, 4f, false, 0.15f);
    }

    public static void DrawCloseTexture(this SpriteBatch b, Vector2 position)
    {
        Utility.drawWithShadow(b, Game1.mouseCursors, position, new Rectangle(337, 494, 12, 12),
            Color.White, 0.0f, Vector2.Zero, 4f, false, 0.15f);
    }

    public static void DrawCheckboxTexture(this SpriteBatch b, int x, int y, bool current)
    {
        IClickableMenu.drawTextureBox(b, Game1.mouseCursors,
            current ? OptionsCheckbox.sourceRectChecked : OptionsCheckbox.sourceRectUnchecked, x, y, 36, 36,
            Color.White, 4f, false);
    }

    public static void DrawCheckboxTexture(this SpriteBatch b, Vector2 position, bool current)
    {
        IClickableMenu.drawTextureBox(b, Game1.mouseCursors,
            current ? OptionsCheckbox.sourceRectChecked : OptionsCheckbox.sourceRectUnchecked, (int)position.X,
            (int)position.Y, 36, 36,
            Color.White, 4f, false);
    }
}