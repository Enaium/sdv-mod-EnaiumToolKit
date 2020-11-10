using System.Collections.Generic;
using EnaiumToolKit.Screen.Elements;
using EnaiumToolKit.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Screen
{
    public class ScreenGui : IClickableMenu
    {
        private List<Element> elements;
        private int index;
        private int maxElement;

        public ScreenGui()
        {
            elements = new List<Element>();
            index = 0;
            maxElement = 7;
            width = 832;
            height = 576;
            Vector2 centeringOnScreen = Utility.getTopLeftPositionForCenteringOnScreen(width, height);
            xPositionOnScreen = (int) centeringOnScreen.X;
            yPositionOnScreen = (int) centeringOnScreen.Y + 32;
        }
        public override void draw(SpriteBatch b)
        {
            drawTextureBox(b, Game1.mouseCursors, new Rectangle(384, 373, 18, 18), xPositionOnScreen, yPositionOnScreen,
                width, height, Color.White, 4f);
            int y = yPositionOnScreen + 20;

            for (int i = index, j = 0; j < (elements.Count >= maxElement ? maxElement : elements.Count); i++, j++)
            {
                var VARIABLE = elements[i];
                
                if (VARIABLE.visibled && VARIABLE.enabled)
                {
                    VARIABLE.render(b, xPositionOnScreen + 15, y + j * 78);
                    if (VARIABLE.hovered)
                    {

                        int descriptionWidth = FontUtils.getWidth(VARIABLE.description) + 50;
                        int descriptionHeight = FontUtils.getHeight(VARIABLE.description) + 50;

                        drawTextureBox(b, Game1.mouseCursors, new Rectangle(384, 396, 15, 15), 0, 0, descriptionWidth, descriptionHeight, Color.Wheat, 4f, false);
                        FontUtils.drawHVCentered(b, VARIABLE.description, descriptionWidth / 2, descriptionHeight / 2);
                    }
                }
            }
            drawMouse(b);
            base.draw(b);
        }

        public override void receiveLeftClick(int x, int y, bool playSound)
        {
            foreach (var VARIABLE in elements)
            {
                if (VARIABLE.visibled && VARIABLE.enabled && VARIABLE.hovered)
                {
                    VARIABLE.mouseLeftClicked(x, y);
                    Game1.playSound("drumkit6");
                }
            }

            base.receiveLeftClick(x, y, playSound);
        }

        public override void releaseLeftClick(int x, int y)
        {
            foreach (var VARIABLE in elements)
            {
                if (VARIABLE.visibled && VARIABLE.enabled && VARIABLE.hovered)
                {
                    VARIABLE.mouseLeftReleased(x, y);
                }
            }

            base.releaseLeftClick(x, y);
        }

        public override void receiveRightClick(int x, int y, bool playSound)
        {
            foreach (var VARIABLE in elements)
            {
                if (VARIABLE.visibled && VARIABLE.enabled && VARIABLE.hovered)
                {
                    VARIABLE.mouseRightClicked(x, y);
                }
            }

            base.receiveRightClick(x, y);
        }

        public override void receiveScrollWheelAction(int direction)
        {
            if (direction > 0 && index > 0)
            {
                index--;
            }
            else if (direction < 0 && index + (elements.Count >= maxElement ? maxElement : elements.Count) < elements.Count)
            {
                index++;
            }
            base.receiveScrollWheelAction(direction);
        }

        public void addElement(Element element)
        {
            elements.Add(element);
        }

        public void addElementRange(params Element[] element)
        {
            elements.AddRange(element);
        }
    }
}