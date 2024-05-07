using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Screen.Components;
using EnaiumToolKit.Framework.Screen.Elements;
using EnaiumToolKit.Framework.Utils;
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
    private ArrowButton? _back;

    private string? Title { get; }

    protected override void Init()
    {
        _index = 0;
        _maxElement = (int)(Game1.uiViewport.Height / 1.5) / (Element.DefaultHeight + 3);
        width = 800;
        height = _maxElement * (Element.DefaultHeight + 3);
        var centeringOnScreen = Utility.getTopLeftPositionForCenteringOnScreen(width, height);
        xPositionOnScreen = (int)centeringOnScreen.X;
        yPositionOnScreen = (int)centeringOnScreen.Y;
        _searchTextField = new TextField(null, GetTranslation("screenGui.component.textField.search"),
            xPositionOnScreen - 15,
            yPositionOnScreen - 100, width + 30, 70);
        var up = new ArrowButton(xPositionOnScreen + width + ArrowButton.Width, yPositionOnScreen)
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
        var down = new ArrowButton(xPositionOnScreen + width + ArrowButton.Width,
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
        _scrollBar = new ScrollBar(up.X, up.Y + ArrowButton.Height,
            ArrowButton.Width, yPositionOnScreen + height - up.Y - ArrowButton.Height * 2);

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


        AddComponentRange(up, down, _searchTextField, _scrollBar, _back);

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
        if (IsActive() && Game1.input.GetMouseState().XButton1 == ButtonState.Pressed && Game1.oldMouseState.XButton1 == ButtonState.Released)
        {
            _back?.OnLeftClicked?.Invoke();
        }
        base.update(time);
    }

    public override void draw(SpriteBatch b)
    {
        b.DrawWindowTexture(xPositionOnScreen - 15, yPositionOnScreen - 15, width + 30, height + 25);
        var y = yPositionOnScreen;
        _searchElements = new List<Element>();
        _searchElements.AddRange(GetSearchElements());

        if (_index >= _searchElements.Count)
        {
            _index = 0;
        }

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


        var i = 0;
        foreach (var element in GetElements())
        {
            if (element.Visibled)
            {
                element.Render(b, xPositionOnScreen, y + i * (Element.DefaultHeight + 3));
            }
            i++;
        }

        if (Title != null)
        {
            SpriteText.drawStringWithScrollCenteredAt(b, Title, Game1.uiViewport.Width / 2,
                Game1.uiViewport.Height - 100, Title);
        }

        base.draw(b);

        foreach (var element in GetElements())
        {
            if (element is { Hovered: true, Description: not null } && !element.Description.Equals(""))
            {
                var descriptionWidth = b.GetStringWidth(element.Description) + 50;
                var descriptionHeight = b.GetStringHeight(element.Description) + 50;

                var mouseX = Game1.getMouseX() + 40;
                var mouseY = Game1.getMouseY() + 40;
                b.DrawWindowTexture(mouseX, mouseY, descriptionWidth, descriptionHeight);
                b.DrawStringCenter(element.Description, mouseX, mouseY, descriptionWidth,
                    descriptionHeight);
            }
        }

        drawMouse(b);
    }

    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {
        foreach (var variable in GetElements().Where(variable =>
                     variable is { Visibled: true, Enabled: true, Hovered: true }))
        {
            variable.MouseLeftClicked(x, y);
        }

        base.receiveLeftClick(x, y, playSound);
    }

    public override void releaseLeftClick(int x, int y)
    {
        foreach (var variable in GetElements().Where(variable =>
                     variable is { Visibled: true, Enabled: true, Hovered: true }))
        {
            variable.MouseLeftReleased(x, y);
        }

        base.releaseLeftClick(x, y);
    }

    public override void receiveRightClick(int x, int y, bool playSound = true)
    {
        foreach (var variable in GetElements().Where(variable =>
                     variable is { Visibled: true, Enabled: true, Hovered: true }))
        {
            variable.MouseRightClicked(x, y);
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

        base.receiveScrollWheelAction(direction);
    }

    private IEnumerable<Element> GetElements()
    {
        var elements = new List<Element>();
        for (int i = _index, j = 0;
             j < (_searchElements.Count >= _maxElement ? _maxElement : _searchElements.Count);
             i++, j++)
        {
            elements.Add(_searchElements[i]);
        }

        return elements;
    }

    private IEnumerable<Element> GetSearchElements()
    {
        IEnumerable<Element> elements = _elements;
        if (_searchTextField != null && !_searchTextField.Text.Equals(""))
        {
            elements = elements.Where(element =>
                element.Title?.Contains(_searchTextField.Text, StringComparison.InvariantCultureIgnoreCase) == true
                || element.Description?.Contains(_searchTextField.Text, StringComparison.InvariantCultureIgnoreCase) ==
                true
            );
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