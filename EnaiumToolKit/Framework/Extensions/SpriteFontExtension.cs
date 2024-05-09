using Microsoft.Xna.Framework.Graphics;

namespace EnaiumToolKit.Framework.Extensions;

public static class SpriteFontExtension
{
    public static string GetEllipsisString(this SpriteFont spriteFont, string text, float width)
    {
        var charWidth = spriteFont.MeasureString($"{text[0]}").X;
        return text.Length * charWidth > width ? $"{text[..(int)(width / charWidth)]}..." : text;
    }
}