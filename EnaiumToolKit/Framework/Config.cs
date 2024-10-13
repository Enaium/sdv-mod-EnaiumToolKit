using StardewModdingAPI;
using StardewModdingAPI.Utilities;

namespace EnaiumToolKit.Framework;

public class Config
{
    public KeybindList OpenScreen { get; set; } = new(SButton.RightControl);
}