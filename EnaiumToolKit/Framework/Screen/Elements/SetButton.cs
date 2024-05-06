using EnaiumToolKit.Framework.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace EnaiumToolKit.Framework.Screen.Elements;

public class SetButton : Element
{
    
    private bool _hovered;
    
    public SetButton(string? title, string? description) : base(title, description)
    {
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        var textureX = x + Width - 84;
        var textureY = y + Height / 2 - 44 / 2;
        _hovered = new Rectangle(textureX, textureY, 84, 44).Contains(Game1.getMouseX(), Game1.getMouseY());
        b.DrawStringVCenter(Title!, x, y, Height);
        b.DrawSetTexture(textureX, textureY);
        base.Render(b, x, y);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        if (_hovered)
        {
            Game1.playSound("drumkit6");
            base.MouseLeftClicked(x, y);
        }
    }
}