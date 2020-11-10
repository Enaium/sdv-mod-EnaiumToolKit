using EnaiumToolKit.Gui;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace EnaiumToolKit
{
    public class ModEntry : Mod
    {
        private static ModEntry instance;

        public ModEntry()
        {
            instance = this;
        }

        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += onButtonPress;
        }

        private void onButtonPress(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button == SButton.O)
            {
                Game1.activeClickableMenu = new TestScreen();
            }
        }

        public static ModEntry getInstance()
        {
            return instance;
        }
    }
}