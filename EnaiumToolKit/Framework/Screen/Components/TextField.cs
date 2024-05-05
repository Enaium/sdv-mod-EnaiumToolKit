using EnaiumToolKit.Framework.Extensions;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Components;

public class TextField : Component
{
    private TextBox _textBox;

    public string Text
    {
        get => _textBox.Text;
        set => _textBox.Text = value;
    }

    public TextField(string? title, string description, int x, int y, int width, int height) : base(title,
        description, x, y, width, height)
    {
        _textBox = new TextBox(Game1.content.Load<Texture2D>("LooseSprites\\textBox"), null, Game1.dialogueFont,
            Game1.textColor)
        {
            X = x, Y = y, Width = width, Height = 0
        };
    }

    public override void Render(SpriteBatch b)
    {
        Hovered = Bounds.Contains(Game1.getMouseX(), Game1.getMouseY());

        b.DrawWindowTexture(X, Y, Width, Height);

        _textBox.Draw(b);
    }

    public override void MouseLeftClicked(int x, int y)
    {
        _textBox.Selected = true;
        base.MouseLeftClicked(x, y);
    }

    public override void LostFocus()
    {
        _textBox.Selected = false;
        base.LostFocus();
    }
}