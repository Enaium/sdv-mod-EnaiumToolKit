using EnaiumToolKit.Framework.Extensions;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace EnaiumToolKit.Framework.Screen.Components.Slots;

public class LabelSlot : Slot<LabelSlot>.Entry
{
    private string Title;

    public LabelSlot(string title)
    {
        Title = title;
    }

    public override void Render(SpriteBatch b, int x, int y)
    {
        Hovered = new Rectangle(x, y, Width, Height).Contains(Game1.getMouseX(), Game1.getMouseY());
        b.DrawStringCenter(Title, x, y, Width, Height);
    }
}