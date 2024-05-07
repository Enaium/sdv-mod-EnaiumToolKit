using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Screen.Components;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen;

public class GuiScreen : IClickableMenu
{
    private readonly List<Component> _components = new();
    protected IClickableMenu? PreviousMenu;

    protected GuiScreen()
    {
        _components.Clear();
        Initialization();
        ModEntry.GetInstance().Helper.Events.Display.WindowResized += (_, _) => { Initialization(); };
    }

    private void Initialization()
    {
        _components.Clear();
        Init();
    }

    protected virtual void Init()
    {
    }

    public override void draw(SpriteBatch b)
    {
        foreach (var component in _components.Where(component => component.Visibled))
        {
            component.Render(b);
        }

        foreach (var component in _components.Where(component => component.Visibled))
        {
            if (component is { Hovered: true, Description: not null } && !component.Description.Equals(""))
            {
                var descriptionWidth = b.GetStringWidth(component.Description) + 50;
                var descriptionHeight = b.GetStringHeight(component.Description) + 50;

                var mouseX = Game1.getMouseX() + 40;
                var mouseY = Game1.getMouseY() + 40;
                b.DrawWindowTexture(mouseX, mouseY, descriptionWidth, descriptionHeight);
                b.DrawStringCenter(component.Description, mouseX, mouseY, descriptionWidth, descriptionHeight);
            }
        }

        const string text = "EnaiumToolKit By Enaium";
        b.DrawString(text, 0, Game1.viewport.Height - b.GetStringHeight(text));

        drawMouse(b);
        base.draw(b);
    }

    public override void receiveLeftClick(int x, int y, bool playSound = true)
    {
        foreach (var component in _components.Where(component =>
                     component is { Visibled: true, Enabled: true }))
        {
            if (component is { Hovered: true })
            {
                component.MouseLeftClicked(x, y);
            }
            else
            {
                component.LostFocus();
            }
        }

        base.receiveLeftClick(x, y, playSound);
    }

    public override void releaseLeftClick(int x, int y)
    {
        foreach (var component in _components.Where(component =>
                     component is { Visibled: true, Enabled: true, Hovered: true }))
        {
            component.MouseLeftReleased(x, y);
        }

        base.releaseLeftClick(x, y);
    }

    public override void receiveRightClick(int x, int y, bool playSound = true)
    {
        foreach (var component in _components.Where(component =>
                     component is { Visibled: true, Enabled: true, Hovered: true }))
        {
            component.MouseRightClicked(x, y);
        }

        base.receiveRightClick(x, y, playSound);
    }

    public override void receiveScrollWheelAction(int direction)
    {
        foreach (var component in _components.Where(component =>
                     component is { Visibled: true, Enabled: true, Hovered: true }))
        {
            component.MouseScrollWheelAction(direction);
        }

        base.receiveScrollWheelAction(direction);
    }
    
    public override void receiveKeyPress(Keys key)
    {
        if (Game1.options.menuButton[0].key == key)
        {
            return;
        }

        base.receiveKeyPress(key);
    }

    protected void AddComponent(Component component)
    {
        _components.Add(component);
    }

    protected void AddComponentRange(params Component[] component)
    {
        _components.AddRange(component);
    }

    protected void RemoveComponent(Component component)
    {
        _components.Remove(component);
    }

    protected void RemoveComponentRange(params Component[] component)
    {
        foreach (var variable in component)
        {
            _components.Remove(variable);
        }
    }

    protected void OpenScreenGui(IClickableMenu clickableMenu)
    {
        if (Game1.activeClickableMenu is TitleMenu)
        {
            TitleMenu.subMenu = clickableMenu;
        }
        else
        {
            if (clickableMenu is GuiScreen guiScreen)
            {
                guiScreen.PreviousMenu = this;
            }

            Game1.activeClickableMenu = clickableMenu;
        }
    }
}