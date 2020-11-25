using System;
using System.Linq;
using System.Threading;
using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using StardewModdingAPI;
using StardewValley;

namespace EnaiumToolKit.Framework.Gui
{
    public class AllScreenGui : ScreenGui
    {
        public AllScreenGui()
        {
            var type = typeof(ScreenGui);
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));
            foreach (var variable in types)
            {
                AddElement(new Button(
                    $"{ModEntry.GetInstance().Helper.Translation.Get("allScreenGuiScreen.element.button.open")} {variable.Name}",
                    $"{ModEntry.GetInstance().Helper.Translation.Get("allScreenGuiScreen.element.button.open")} {variable.Name}")
                {
                    OnLeftClicked = () =>
                    {
                        Game1.activeClickableMenu = (ScreenGui) Activator.CreateInstance(variable);
                    }
                });
            }
        }
    }
}