using EnaiumToolKit.Framework.Screen;
using StardewModdingAPI;
using StardewValley;

namespace EnaiumToolKit.Framework.Patches;

public class Game1Patches
{
    private static IMonitor Monitor;

    internal static void Initialize(IMonitor monitor)
    {
        Monitor = monitor;
    }

    internal static void SetActiveClickableMenu()
    {
        if (Game1.activeClickableMenu is GuiScreen screen)
        {
            screen.Initializer();
        }
    }
}