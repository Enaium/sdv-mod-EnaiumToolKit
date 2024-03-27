using EnaiumToolKit.Framework.Screen;
using EnaiumToolKit.Framework.Screen.Elements;

namespace EnaiumToolKit.Framework.Gui;

internal class EnaiumToolKitScreen : ScreenGui
{
    public EnaiumToolKitScreen() : base("Enaium toolKit")
    {
        AddElement(new Button("ElementScreen", "Element test")
        {
            OnLeftClicked = () => { OpenScreenGui(new ElementScreen()); }
        });

        AddElement(new Button("ComponentScreen", "Component test")
        {
            OnLeftClicked = () => { OpenScreenGui(new ComponentScreen()); }
        });
    }

    private string GetTranslation(string key)
    {
        return ModEntry.GetInstance().Helper.Translation.Get(key);
    }
}