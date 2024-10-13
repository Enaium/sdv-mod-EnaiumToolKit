using EnaiumToolKit.Framework.Screen;
using StardewModdingAPI;
using StardewValley.Menus;

namespace EnaiumToolKit.Framework.Patches;

public class TitleMenuPatches
{
    private static IMonitor Monitor;

    internal static void Initialize(IMonitor monitor)
    {
        Monitor = monitor;
    }

    internal static void SetSubMenu()
    {
        if (TitleMenu.subMenu is GuiScreen screen)
        {
            screen.Initializer();
        }
    }
}