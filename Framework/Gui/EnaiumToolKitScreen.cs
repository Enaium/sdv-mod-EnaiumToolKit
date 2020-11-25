using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using StardewValley;

namespace EnaiumToolKit.Framework.Gui
{
    public class EnaiumToolKitScreen : ScreenGui
    {
        public EnaiumToolKitScreen()
        {
            AddElement(new Button(GetTranslation("enaiumToolKitScreen.element.button.testScreen"),
                GetTranslation("enaiumToolKitScreen.element.button.testScreen"))
            {
                OnLeftClicked = () => { Game1.activeClickableMenu = new TestScreen(); }
            });

            AddElement(new Button(GetTranslation("enaiumToolKitScreen.element.button.allScreenGui"),
                GetTranslation("enaiumToolKitScreen.element.button.allScreenGui"))
            {
                OnLeftClicked = () => { Game1.activeClickableMenu = new AllScreenGui(); }
            });
        }

        private string GetTranslation(string key)
        {
            return ModEntry.GetInstance().Helper.Translation.Get(key);
        }
    }
}