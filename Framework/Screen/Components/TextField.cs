using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Screen.Components
{
    public class TextField : Component
    {
        private TextBox _textBox;
        public string Text => _textBox.Text;

        public TextField(string description, int x, int y, int width, int height) : base("", description, x, y, width,
            height)
        {
            _textBox = new TextBox(Game1.content.Load<Texture2D>("LooseSprites\\textBox"), null, Game1.dialogueFont,
                Game1.textColor)
            {
                Selected = true, X = x, Y = y, Width = width, Height = 0
            };
        }

        public override void Render(SpriteBatch b)
        {
            Hovered = Render2DUtils.isHovered(Game1.getMouseX(), Game1.getMouseY(), X, Y, Width, Height);

            IClickableMenu.drawTextureBox(b, Game1.mouseCursors, new Rectangle(384, 373, 18, 18), X - 5, Y - 5,
                Width + 20, Height + 25, Color.White, 4f);

            if (!Hovered)
            {
                _textBox.Selected = false;
            }

            _textBox.Draw(b);
        }

        public override void MouseLeftClicked(int x, int y)
        {
            _textBox.Selected = !_textBox.Selected;
            base.MouseLeftClicked(x, y);
        }
    }
}