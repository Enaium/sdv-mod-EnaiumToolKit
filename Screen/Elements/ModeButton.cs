using System;
using System.Collections.Generic;
using System.Linq;
using EnaiumToolKit.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Screen.Elements
{
    public class ModeButton : Element
    {
        private List<String> modes;
        private String current;

        public ModeButton(string title, string description, List<string> modes, String current) : base(title,
            description)
        {
            this.modes = modes;
            this.current = current;
        }

        public override void render(SpriteBatch b, int x, int y)
        {
            hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, width, height);

            Render2DUtils.drawRect(b, x, y, width, height, hovered ? Color.Wheat : Color.White);
            FontUtils.drawHVCentered(b, $"{title}:({getCurrentIndex() + 1}/{modes.Count}){modes[getCurrentIndex()]}", x + width / 2,
                y + height / 2);
        }
        
        public override void mouseLeftClicked(int x, int y)
        {
            try
            {
                current = modes[getCurrentIndex() + 1];
            }
            catch (Exception e)
            {
                current = modes.First();
            }
            
            base.mouseLeftClicked(x, y);
        }
        
        public override void mouseRightClicked(int x, int y)
        {
            try
            {
                current = modes[getCurrentIndex() - 1];
            }
            catch (Exception e)
            {
                current = modes.Last();
            }

            base.mouseRightClicked(x, y);
        }

        public String getCurrent()
        {
            return current;
        }

        public int getCurrentIndex()
        {
            int index = 0;
            foreach (var VARIABLE in modes)
            {
                if (VARIABLE.Equals(current))
                {
                    return index;
                }

                index++;
            }
            return index;
        }
    }
}