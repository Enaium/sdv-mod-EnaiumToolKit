using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.BellsAndWhistles;

namespace EnaiumToolKit.Utils
{
    public class FontUtils
    {
        public static void draw(SpriteBatch b, String text, int x, int y)
        {
            Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
                new Vector2(x, y), Game1.textColor, 1f,
                -1f,
                -1, -1, 0.0f);
        }

        public static void drawHCentered(SpriteBatch b, String text, int x, int y)
        {
            Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
                new Vector2(x - SpriteText.getWidthOfString(text) / 2, y), Game1.textColor, 1f,
                -1f,
                -1, -1, 0.0f);
        }

        public static void drawVCentered(SpriteBatch b, String text, int x, int y)
        {
            Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
                new Vector2(x, y - SpriteText.getHeightOfString(text) / 2), Game1.textColor, 1f,
                -1f,
                -1, -1, 0.0f);
        }
        
        public static void drawHVCentered(SpriteBatch b, String text, int x, int y)
        {
            Utility.drawTextWithShadow(b, text, Game1.dialogueFont,
                new Vector2(x - SpriteText.getWidthOfString(text) / 2, y - SpriteText.getHeightOfString(text) / 2), Game1.textColor, 1f,
                -1f,
                -1, -1, 0.0f);
        }
        
        
        public static int getWidth(string text)
        {
            return SpriteText.getWidthOfString(text);
        }
        
        public static int getHeight(string text)
        {
            return SpriteText.getHeightOfString(text);
        }
    }
}