using EnaiumToolKit.Framework;
using EnaiumToolKit.Framework.Gui;
using EnaiumToolKit.Framework.Patches;
using HarmonyLib;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace EnaiumToolKit;

public class ModEntry : Mod
{
    private static ModEntry _instance;

    public ModEntry()
    {
        _instance = this;
    }

    public override void Entry(IModHelper helper)
    {
        Game1Patches.Initialize(Monitor);
        Game1Patches.Initialize(Monitor);
        var harmony = new Harmony(ModManifest.UniqueID);
        harmony.Patch(
            original: AccessTools.Method(typeof(Game1),
                typeof(Game1).GetProperty(nameof(Game1.activeClickableMenu))!.GetSetMethod()!.Name),
            postfix: new HarmonyMethod(typeof(Game1Patches), nameof(Game1Patches.SetActiveClickableMenu))
        );
        harmony.Patch(
            original: AccessTools.Method(typeof(TitleMenu),
                typeof(TitleMenu).GetProperty(nameof(TitleMenu.subMenu))!.GetSetMethod()!.Name),
            postfix: new HarmonyMethod(typeof(TitleMenuPatches), nameof(TitleMenuPatches.SetSubMenu))
        );
    }

    public static ModEntry GetInstance()
    {
        return _instance;
    }
}