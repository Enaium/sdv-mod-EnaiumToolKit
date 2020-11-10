using System.Collections.Generic;
using EnaiumToolKit.Screen;
using EnaiumToolKit.Screen.Elements;
using StardewModdingAPI;

namespace EnaiumToolKit.Gui
{
    public class TestScreen : ScreenGui
    {
        public TestScreen()
        {
            addElement(new Button("Button", "It is Button")
            {
                onLeftClicked = () => { ModEntry.getInstance().Monitor.Log("Clicked", LogLevel.Debug); }
            });

            ToggleButton toggleButton = new ToggleButton("ToggleButton", "It is Toggle");
            toggleButton.onLeftClicked = () =>
            {
                ModEntry.getInstance().Monitor.Log(toggleButton.getToggled() + "", LogLevel.Debug);
            };
            addElement(toggleButton);
            ModeButton modeButton = new ModeButton("ModeButton", "Left key plus right key minus",
                new List<string> {"Mode1", "Mode2", "Mode3", "Mode4"}, "Mode1");
            modeButton.onLeftClicked = () =>
            {
                ModEntry.getInstance().Monitor.Log(modeButton.getCurrent(), LogLevel.Debug);
            };
            addElement(modeButton);
            addElementRange(new Label("Label1", "It is Label1"), new Label("Label2", "It is Label2"),
                new Label("Label3", "It is Label3"), new Label("Label4", "It is Label4"));
            addElement(new ValueButton("ValueButton", "It is ValueButton", 1, 1, 10));
        }
    }
}