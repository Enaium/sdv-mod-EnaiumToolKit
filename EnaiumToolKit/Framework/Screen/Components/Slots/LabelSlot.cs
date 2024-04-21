using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

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
        Hovered = Render2DUtils.IsHovered(Game1.getMouseX(), Game1.getMouseY(), x, y, Width, Height);
        FontUtils.DrawHvCentered(b, Title, x, y, Width, Height);
    }
}