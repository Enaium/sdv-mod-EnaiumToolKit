using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Screen.Elements
{
    public abstract class Element
    {
        public bool hovered;
        public bool visibled;
        public bool enabled;
        public int width = 800;
        public int height = 75;
        public String title;
        public String description;
        
        public Action onLeftClicked = () => { };
        public Action onLeftReleased = () => { };
        public Action onRightClicked = () => { };

        public Element(String title, String description)
        {
            this.title = title;
            this.description = description;
            hovered = false;
            visibled = true;
            enabled = true;
        }

        public abstract void render(SpriteBatch b, int x, int y);

        public virtual void mouseLeftClicked(int x, int y)
        {
            onLeftClicked.Invoke();
        }

        public virtual void mouseLeftReleased(int x, int y)
        {
            onLeftReleased.Invoke();
        }

        public virtual void mouseRightClicked(int x, int y)
        {
            onRightClicked.Invoke();
        }
    }
}