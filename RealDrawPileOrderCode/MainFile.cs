using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;

namespace RealDrawPileOrder.RealDrawPileOrderCode;

//You're recommended but not required to keep all your code in this package and all your assets in the RealDrawPileOrder folder.
[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node {
    public const string ModId = "RealDrawPileOrder"; //At the moment, this is used only for the Logger and harmony names.

    public static MegaCrit.Sts2.Core.Logging.Logger Logger { get; } = new(ModId, LogType.Generic);

    public static void Initialize() {
        Logger.Info(ModId + " is initializing!");
        Harmony harmony = new(ModId);

        harmony.PatchAll();
    }
}
