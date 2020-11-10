using System;
using System.Collections.Generic;
using System.Linq;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements
{
    public class ModeButton : Element
    {
        private List<string> modes;
        private string _current;

        public ModeButton(string title, string description, List<string> modes, String current) : base(title,
            description)
        {
            this.modes = modes;
            this._current = current;
        }

        public override void Render(SpriteBatch b, int x, int y)
        {
            Hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);

            Render2DUtils.drawRect(b, x, y, Width, Height, Hovered ? Color.Wheat : Color.White);
            FontUtils.DrawHvCentered(b, $"{Title}:({getCurrentIndex() + 1}/{modes.Count}){modes[getCurrentIndex()]}",
                x + Width / 2,
                y + Height / 2);
        }

        public override void MouseLeftClicked(int x, int y)
        {
            try
            {
                _current = modes[getCurrentIndex() + 1];
            }
            catch (Exception e)
            {
                _current = modes.First();
            }

            base.MouseLeftClicked(x, y);
        }

        public override void MouseRightClicked(int x, int y)
        {
            try
            {
                _current = modes[getCurrentIndex() - 1];
            }
            catch (Exception e)
            {
                _current = modes.Last();
            }

            base.MouseRightClicked(x, y);
        }

        public String getCurrent()
        {
            return _current;
        }

        public int getCurrentIndex()
        {
            var index = 0;
            foreach (var variable in modes)
            {
                if (variable.Equals(_current))
                {
                    return index;
                }

                index++;
            }

            return index;
        }
    }
}