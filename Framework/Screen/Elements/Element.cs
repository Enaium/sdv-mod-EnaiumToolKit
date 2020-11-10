using System;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements
{
    public abstract class Element
    {
        public bool Hovered;
        public bool Visibled;
        public bool Enabled;
        public const int Width = 800;
        public const int Height = 75;
        public string Title;
        public string Description;

        public Action OnLeftClicked = () => { };
        public Action OnLeftReleased = () => { };
        public Action OnRightClicked = () => { };

        public Element(string title, string description)
        {
            this.Title = title;
            this.Description = description;
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
}