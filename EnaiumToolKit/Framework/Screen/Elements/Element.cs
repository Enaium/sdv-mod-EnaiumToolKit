using Microsoft.Xna.Framework.Graphics;

namespace EnaiumToolKit.Framework.Screen.Elements;

public abstract class Element
{
    public bool Hovered;
    public bool Visibled;
    public bool Enabled;
    public int Width;
    public int Height;
    public string Title;
    public string Description;
        
    public Action OnLeftClicked = () => { };
    public Action OnLeftReleased = () => { };
    public Action OnRightClicked = () => { };

    public Element(string title, string description)
    {
        Title = title;
        Description = description;
        Width = 800;
        Height = 75;
        Hovered = false;
        Visibled = true;
        Enabled = true;
    }
        
    public abstract void Render(SpriteBatch b, int x, int y);
        
    public virtual void MouseLeftClicked(int x, int y)
    {
        OnLeftClicked.Invoke();
    }

    public virtual void MouseLeftReleased(int x, int y)
    {
        OnLeftReleased.Invoke();
    }

    public virtual void MouseRightClicked(int x, int y)
    {
        OnRightClicked.Invoke();
    }
}