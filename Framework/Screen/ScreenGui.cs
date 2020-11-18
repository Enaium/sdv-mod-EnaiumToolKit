﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using EnaiumToolKit.Framework.Screen.Elements;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen
{
    public class ScreenGui : IClickableMenu
    {
        private List<Element> _elements;
        private int _index;
        private int _maxElement;
        private B _up;
        private B _down;
        private B _close;

        public ScreenGui()
        {
            _elements = new List<Element>();
            _index = 0;
            _maxElement = 7;
            width = 832;
            height = 576;
            var centeringOnScreen = Utility.getTopLeftPositionForCenteringOnScreen(width, height);
            xPositionOnScreen = (int) centeringOnScreen.X;
            yPositionOnScreen = (int) centeringOnScreen.Y + 32;
            const int buttonSize = 60;
            _up = new B("U", xPositionOnScreen + width + buttonSize, yPositionOnScreen, buttonSize, () =>
            {
                if (_index >= _maxElement)
                {
                    _index -= _maxElement;
                }
                else
                {
                    _index = 0;
                }
            });
            _down = new B("D", xPositionOnScreen + width + buttonSize, yPositionOnScreen + height - buttonSize,
                buttonSize,
                () =>
                {
                    if (_index + (_elements.Count >= _maxElement ? _maxElement : _elements.Count) <
                        _elements.Count)
                    {
                        if (_index + _maxElement <= _elements.Count - _maxElement)
                        {
                            _index += _maxElement;
                        }
                        else
                        {
                            _index += _elements.Count - _index - _maxElement;
                        }
                    }
                });
            _close = new B("C", Game1.viewport.Width - buttonSize, 0, buttonSize,
                () => { Game1.activeClickableMenu = null; });
        }

        public override void draw(SpriteBatch b)
        {
            _up.Render(b);
            _down.Render(b);
            _close.Render(b);
            drawTextureBox(b, Game1.mouseCursors, new Rectangle(384, 373, 18, 18), xPositionOnScreen, yPositionOnScreen,
                width, height, Color.White, 4f);
            var y = yPositionOnScreen + 20;

            for (int i = _index, j = 0; j < (_elements.Count >= _maxElement ? _maxElement : _elements.Count); i++, j++)
            {
                var variable = _elements[i];

                if (variable.Visibled && variable.Enabled)
                {
                    variable.Render(b, xPositionOnScreen + 15, y + j * 78);
                    if (variable.Hovered)
                    {
                        var descriptionWidth = FontUtils.GetWidth(variable.Description) + 50;
                        var descriptionHeight = FontUtils.GetHeight(variable.Description) + 50;

                        drawTextureBox(b, Game1.mouseCursors, new Rectangle(384, 396, 15, 15), 0, 0, descriptionWidth,
                            descriptionHeight, Color.Wheat, 4f, false);
                        FontUtils.DrawHvCentered(b, variable.Description, descriptionWidth / 2, descriptionHeight / 2);
                    }
                }
            }

            const string text = "EnaiumToolKit By Enaium";
            FontUtils.Draw(b, text, 0, Game1.viewport.Height - FontUtils.GetHeight(text));

            drawMouse(b);
            base.draw(b);
        }

        public override void receiveLeftClick(int x, int y, bool playSound)
        {
            _up.MouseLeftClicked();
            _down.MouseLeftClicked();
            _close.MouseLeftClicked();
            foreach (var variable in _elements)
            {
                if (variable.Visibled && variable.Enabled && variable.Hovered)
                {
                    variable.MouseLeftClicked(x, y);
                    Game1.playSound("drumkit6");
                }
            }

            base.receiveLeftClick(x, y, playSound);
        }

        public override void releaseLeftClick(int x, int y)
        {
            foreach (var variable in _elements)
            {
                if (variable.Visibled && variable.Enabled && variable.Hovered)
                {
                    variable.MouseLeftReleased(x, y);
                }
            }

            base.releaseLeftClick(x, y);
        }

        public override void receiveRightClick(int x, int y, bool playSound)
        {
            foreach (var variable in _elements)
            {
                if (variable.Visibled && variable.Enabled && variable.Hovered)
                {
                    variable.MouseRightClicked(x, y);
                }
            }

            base.receiveRightClick(x, y);
        }

        public override void receiveScrollWheelAction(int direction)
        {
            if (direction > 0 && _index > 0)
            {
                _index--;
            }
            else if (direction < 0 && _index + (_elements.Count >= _maxElement ? _maxElement : _elements.Count) <
                _elements.Count)
            {
                _index++;
            }

            base.receiveScrollWheelAction(direction);
        }

        public void AddElement(Element element)
        {
            _elements.Add(element);
        }

        public void AddElementRange(params Element[] element)
        {
            _elements.AddRange(element);
        }
    }

    public class B
    {
        private string _title;
        private int _x;
        private int _y;
        private int _buttonSize;
        private Action _onLeftClicked;
        private bool _hovered;

        public B(string title, int x, int y, int buttonSize, Action onLeftClicked)
        {
            _title = title;
            _x = x;
            _y = y;
            _buttonSize = buttonSize;
            _onLeftClicked = onLeftClicked;
        }

        public void Render(SpriteBatch b)
        {
            _hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), _x, _y, _buttonSize, _buttonSize);
            Render2DUtils.drawRect(b, _x, _y, 60, 60, _hovered ? Color.Wheat : Color.White);
            FontUtils.DrawHvCentered(b, _title, _x + _buttonSize / 2, _y + _buttonSize / 2);
        }

        public void MouseLeftClicked()
        {
            if (_hovered)
            {
                Game1.playSound("drumkit6");
                _onLeftClicked.Invoke();
            }
        }
    }
}