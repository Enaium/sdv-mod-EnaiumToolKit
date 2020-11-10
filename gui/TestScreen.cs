using EnaiumToolKit.Screen;
using EnaiumToolKit.Screen.Elements;
using StardewModdingAPI;

namespace EnaiumToolKit.Gui
{
    public class TestScreen : ScreenGui
    {
        public TestScreen()
        {
            addElement(new Button("Button", "Click it")
            {
                onLeftClicked = () => { ModEntry.getInstance().Monitor.Log("Clicked", LogLevel.Debug); }
            });

            Toggle toggle = new Toggle("Toggle", "This is Toggle", false);
            toggle.onLeftClicked = () =>
            {
                ModEntry.getInstance().Monitor.Log(toggle.getToggled() + "", LogLevel.Debug);
            };
            addElement(toggle);
        }
    }
}