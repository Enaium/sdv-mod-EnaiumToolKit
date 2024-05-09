using Microsoft.Xna.Framework;

namespace EnaiumToolKit.Framework.Extensions;

public static class RectangleExtension
{
    public static bool IsHover(this Rectangle rectangle, int mouseX, int mouseY)
    {
        return mouseX >= rectangle.X && mouseX - rectangle.Width <= rectangle.X && mouseY >= rectangle.Y &&
               mouseY - rectangle.Height <= rectangle.Y;
    }

    public static Vector2 Position(this Rectangle rectangle)
    {
        return new Vector2(rectangle.X, rectangle.Y);
    }
}