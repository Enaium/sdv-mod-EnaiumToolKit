using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;
using EnaiumToolKit.Framework.Utils;
using Microsoft.Xna.Framework;
using StardewModdingAPI;

namespace EnaiumToolKit.Framework.Gui;

internal class ElementScreen : ScreenGui
{
    public ElementScreen() : base("Element")
    {
        AddElement(new Button("Button", "It is Button")
        {
            OnLeftClicked = () => { ModEntry.GetInstance().Monitor.Log("Clicked", LogLevel.Debug); }
        });

        var toggleButton = new ToggleButton("ToggleButton", "It is Toggle")
        {
            OnCurrentChanged = value => { ModEntry.GetInstance().Monitor.Log(value.ToString(), LogLevel.Debug); }
        };
        AddElement(toggleButton);
        AddElement(new ModeButton("ModeButton", "Left key plus right key minus")
        {
            Modes = new List<string> { "Mode1", "Mode2", "Mode3", "Mode4" }, Current = "Mode1",
            OnCurrentChanged = (current) => { ModEntry.GetInstance().Monitor.Log(current, LogLevel.Debug); }
        });
        AddElementRange(new Label("Label1", "It is Label1"), new Label("Label2", "It is Label2"),
            new Label("Label3", "It is Label3"), new Label("Label4", "It is Label4"));
        AddElement(new ValueButton("ValueButton", "It is ValueButton")
        {
            Current = 1, Min = 1, Max = 10,
            OnCurrentChanged = value => { ModEntry.GetInstance().Monitor.Log(value.ToString(), LogLevel.Debug); }
        });
        AddElement(new SliderBar("Slider", "Slider", 0, 100));
        AddElement(new ColorPicker("Color Picker", "Color Picker", Color.White)
        {
            OnCurrentChanged = value => { ModEntry.GetInstance().Monitor.Log(value.ToString(), LogLevel.Debug); }
        });
        AddElement(new ComboBox<string>("ComboBox", "ComboBox")
        {
            Items = new List<string?> { "Item1", "Item2", "Item3", "Item4" },
            Current = "Item1",
            OnCurrentChanged = value => { ModEntry.GetInstance().Monitor.Log($"{value}", LogLevel.Debug); }
        });
    }
}