﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.BellsAndWhistles;

namespace EnaiumToolKit.Framework.Utils;

[Obsolete]
public class FontUtils
{
    public static void Draw(SpriteBatch b, string text, int x, int y)
    {
        Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
            new Vector2(x, y), Game1.textColor, 1f,
            0.98f,
            -1, -1, 0.0f);
    }

    [Obsolete]
    public static void DrawHCentered(SpriteBatch b, string text, int x, int y)
    {
        var v = Game1.dialogueFont.MeasureString(text);
        Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
            new Vector2(x - GetWidth(text) / 2f, y) + v, Game1.textColor, 1f,
            0.98f,
            -1, -1, 0.0f);
    }

    public static void DrawHCentered(SpriteBatch b, string text, int x, int y, int width)
    {
        var v = Game1.dialogueFont.MeasureString(text);
        Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
            new Vector2(x + width / 2f - v.X / 2f, y), Game1.textColor, 1f,
            0.98f,
            -1, -1, 0.0f);
    }

    [Obsolete]
    public static void DrawVCentered(SpriteBatch b, string text, int x, int y)
    {
        Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
            new Vector2(x, y - GetHeight(text) / 2f), Game1.textColor, 1f,
            0.98f,
            -1, -1, 0.0f);
    }

    public static void DrawVCentered(SpriteBatch b, string? text, int x, int y, int height)
    {
        var v = Game1.dialogueFont.MeasureString(text);
        Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
            new Vector2(x, y + height / 2f - v.Y / 2f), Game1.textColor, 1f,
            0.98f,
            -1, -1, 0.0f);
    }

    [Obsolete]
    public static void DrawHvCentered(SpriteBatch b, string text, int x, int y)
    {
        Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
            new Vector2(x - GetWidth(text) / 2f, y - GetHeight(text) / 2f),
            Game1.textColor, 1f,
            0.98f,
            -1, -1, 0.0f);
    }

    public static void DrawHvCentered(SpriteBatch b, string text, int x, int y, int width, int height)
    {
        var v = Game1.dialogueFont.MeasureString(text);
        Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
            new Vector2(x + width / 2f, y + height / 2f) - v / 2f,
            Game1.textColor, 1f,
            0.98f,
            -1, -1, 0.0f);
    }


    public static int GetWidth(string text)
    {
        return SpriteText.getWidthOfString(text);
    }

    public static int GetHeight(string text)
    {
        return SpriteText.getHeightOfString(text);
    }
}