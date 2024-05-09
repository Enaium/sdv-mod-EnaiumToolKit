﻿using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Screen.Components;
using EnaiumToolKit.Framework.Screen.Elements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.BellsAndWhistles;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen;

public class ScreenGui : GuiScreen
{
    private readonly List<Element> _elements = new();
    private List<Element> _searchElements = new();
    private int _index;
    private int _maxElement;
    private TextField? _searchTextField;
    private ScrollBar? _scrollBar;
    private ArrowButton? _up;
    private ArrowButton? _down;
    private ArrowButton? _back;

    private string? Title { get; }

    protected override void Init()
    {
        _maxElement = (int)(Game1.uiViewport.Height / 1.5) / (Element.DefaultHeight + 3);
        width = 800;
        height = _maxElement * (Element.DefaultHeight + 3);
        var centeringOnScreen = Utility.getTopLeftPositionForCenteringOnScreen(width, height);
        xPositionOnScreen = (int)centeringOnScreen.X;
        yPositionOnScreen = (int)centeringOnScreen.Y;
        _searchTextField = new TextField(null, GetTranslation("screenGui.component.textField.search"),
            xPositionOnScreen - 15,
            yPositionOnScreen - 100, width + 30, 70);
        _up = new ArrowButton(xPositionOnScreen + width + ArrowButton.Width, yPositionOnScreen)
        {
            Description = GetTranslation("screenGui.component.arrowButton.flipUp"),
            Direction = ArrowButton.DirectionType.Up,
            OnLeftClicked = () =>
            {
                if (_index >= _maxElement)
                {
                    _index -= _maxElement;
                }
                else
                {
                    _index = 0;
                }
            }
        };
        _down = new ArrowButton(xPositionOnScreen + width + ArrowButton.Width,
            yPositionOnScreen + height - ArrowButton.Height)
        {
            Description = GetTranslation("screenGui.component.arrowButton.flipDown"),
            Direction = ArrowButton.DirectionType.Down,
            OnLeftClicked = () =>
            {
                if (_index + (_searchElements.Count >= _maxElement ? _maxElement : _searchElements.Count) <
                    _searchElements.Count)
                {
                    if (_index + _maxElement <= _searchElements.Count - _maxElement)
                    {
                        _index += _maxElement;
                    }
                    else
                    {
                        _index += _searchElements.Count - _index - _maxElement;
                    }
                }
            }
        };
        _scrollBar = new ScrollBar(_up.X, _up.Y + ArrowButton.Height,
            ArrowButton.Width, yPositionOnScreen + height - _up.Y - ArrowButton.Height * 2);

        _back = new ArrowButton(xPositionOnScreen - ArrowButton.Width * 2, yPositionOnScreen)
        {
            Description = GetTranslation("screenGui.component.arrowButton.backScreen"),
            Direction = ArrowButton.DirectionType.Left,
            OnLeftClicked = () =>
            {
                if (PreviousMenu != null)
                {
                    Game1.activeClickableMenu = PreviousMenu;
                }
            }
        };


        AddComponentRange(_up, _down, _searchTextField, _scrollBar, _back);

        if (Game1.activeClickableMenu is not TitleMenu)
        {
            AddComponent(new CloseButton(xPositionOnScreen + width + ArrowButton.Width, _searchTextField.Y)
            {
                Description = GetTranslation("screenGui.component.closeButton.closeScreen"),
                OnLeftClicked = () => { Game1.activeClickableMenu = null; }
            });
        }

        base.Init();
    }

    protected ScreenGui()
    {
    }

    protected ScreenGui(string title)
    {
        Title = title;
    }


    private string GetTranslation(string key)
    {
        return ModEntry.GetInstance().Helper.Translation.Get(key);
    }

    public override void update(GameTime time)
    {
        if (IsActive() && Game1.input.GetMouseState().XButton1 == ButtonState.Pressed &&
            Game1.oldMouseState.XButton1 == ButtonState.Released)
        {
            _back?.OnLeftClicked?.Invoke();
        }

        base.update(time);
    }

    public override void draw(SpriteBatch b)
    {
        b.DrawWindowTexture(xPositionOnScreen - 15, yPositionOnScreen - 15, width + 30, height + 25);
        var y = yPositionOnScreen;
        _searchElements = GetSearchElements();

        if (_scrollBar != null)
        {
            _scrollBar.Max = _searchElements.Count - _maxElement;
            _scrollBar.Current = _index;
            _scrollBar.OnCurrentChanged = current => { _index = current; };
        }

        if (_back != null)
        {
            _back.Visibled = PreviousMenu != null;
        }

        if (Title != null)
        {
            SpriteText.drawStringWithScrollCenteredAt(b, Title, Game1.graphics.GraphicsDevice.Viewport.Width / 2,
                Game1.graphics.GraphicsDevice.Viewport.Height - 100, Title);
        }

        GetElements().Select((item, index) =>
        {
            var elementX = xPositionOnScreen;
            var elementY = y + index * (Element.DefaultHeight + 3);
            return new { position = new { x = elementX, y = elementY }, element = item };
        }).OrderBy(it => it.element.Focused).ToList().ForEach(ordered =>
        {
            ordered.element.Render(b, ordered.position.x, ordered.position.y);
            if (ordered.element.Hovered)
            {
                GetElements().Where(it => it != ordered.element).ToList().ForEach(it => it.Hovered = false);
            }
        });


        base.draw(b);

        foreach (var element in GetElements())
        {
            if (element is { Hovered: true, Description: not null } && !element.Description.Equals(""))
            {
                DrawTooltip(b, element.Description);
            }
        }

        drawMouse(b);
    }

    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {
        foreach (var variable in GetElements().Where(variable =>
                     variable is { Visibled: true, Enabled: true }))
        {
            if (variable is { Hovered: true })
            {
                variable.Focused = true;
                variable.MouseLeftClicked(x, y);
            }
            else if (variable.Focused)
            {
                variable.LostFocus(x, y);
                variable.Focused = false;
            }
        }

        base.receiveLeftClick(x, y, playSound);
    }

    public override void releaseLeftClick(int x, int y)
    {
        foreach (var variable in GetElements().Where(variable =>
                     variable is { Visibled: true, Enabled: true }))
        {
            if (variable is { Hovered: true })
            {
                variable.Focused = true;
                variable.MouseLeftReleased(x, y);
            }
            else if (variable.Focused)
            {
                variable.LostFocus(x, y);
                variable.Focused = false;
            }
        }

        base.releaseLeftClick(x, y);
    }

    public override void receiveRightClick(int x, int y, bool playSound = true)
    {
        foreach (var variable in GetElements().Where(variable =>
                     variable is { Visibled: true, Enabled: true }))
        {
            if (variable is { Hovered: true })
            {
                variable.Focused = true;
                variable.MouseRightClicked(x, y);
            }
            else if (variable.Focused)
            {
                variable.LostFocus(x, y);
                variable.Focused = false;
            }
        }

        base.receiveRightClick(x, y, false);
    }

    public override void receiveScrollWheelAction(int direction)
    {
        if (direction > 0 && _index > 0)
        {
            _index--;
        }
        else if (direction < 0 &&
                 _index + (_searchElements.Count >= _maxElement ? _maxElement : _searchElements.Count) <
                 _searchElements.Count)
        {
            _index++;
        }

        foreach (var element in GetElements())
        {
            if (element.Focused)
            {
                element.LostFocus(Game1.getMouseX(), Game1.getMouseY());
                element.Focused = false;
            }
        }

        base.receiveScrollWheelAction(direction);
    }

    public override void receiveKeyPress(Keys key)
    {
        if (key == Keys.PageUp)
        {
            _up?.OnLeftClicked?.Invoke();
        }
        else if (key == Keys.PageDown)
        {
            _down?.OnLeftClicked?.Invoke();
        }

        base.receiveKeyPress(key);
    }

    private List<Element> GetElements()
    {
        var elements = new List<Element>();
        for (int i = _index, j = 0;
             j < (_searchElements.Count >= _maxElement ? _maxElement : _searchElements.Count);
             i++, j++)
        {
            try
            {
                elements.Add(_searchElements[i]);
            }
            catch (Exception e)
            {
                _index = 0;
            }
        }

        return elements;
    }

    private List<Element> GetSearchElements()
    {
        var elements = _elements;
        if (_searchTextField != null && !_searchTextField.Text.Equals(""))
        {
            elements = elements.Where(element =>
                element.Title?.Contains(_searchTextField.Text, StringComparison.InvariantCultureIgnoreCase) == true
                || element.Description?.Contains(_searchTextField.Text, StringComparison.InvariantCultureIgnoreCase) ==
                true
            ).ToList();
        }

        return elements;
    }

    protected void AddElement(Element element)
    {
        _elements.Add(element);
    }

    protected void AddElementRange(params Element[] element)
    {
        _elements.AddRange(element);
    }

    protected void RemoveElement(Element element)
    {
        _elements.Remove(element);
    }

    protected void RemoveElementRange(params Element[] element)
    {
        foreach (var variable in element)
        {
            _elements.Remove(variable);
        }
    }
}