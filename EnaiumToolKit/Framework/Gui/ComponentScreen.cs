using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Components;
using EnaiumToolKit.Framework.Screen.Components.Slots;

namespace EnaiumToolKit.Framework.Gui;

internal class ComponentScreen : GuiScreen
{
    protected override void Init()
    {
        AddComponent(new Button("Button", "Button", 20, 20, 150, 50));
        var slot = new Slot<LabelSlot>("Slot", "", 10, 60, 200, 560, 80);
        for (int i = 0; i < 10; i++)
        {
            slot.AddEntry(new LabelSlot(i + ""));
        }

        AddComponent(slot);
        base.Init();
    }
}