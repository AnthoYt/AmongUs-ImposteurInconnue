using AmongUsUnknownImpostors.Patches;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;

namespace AmongUsUnknownImpostors
{
    [BepInPlugin(Id, "Among Us Unknown Impostors", "1.0.0")]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInDependency("com.herysia.LobbyOptionsAPI")]
    public class UnknownImpostorsPlugin : BasePlugin
    {
        // Plugin ID constant
        public const string Id = "com.herysia.amongusunkimpostor";

        // RPC Settings ID constant
        public static byte RpcSettingsId = 70;

        // Harmony instance for patching methods
        public Harmony Harmony { get; } = new Harmony(Id);

        // Load method called when the plugin is loaded
        public override void Load()
        {
            // Initialize custom game options
            CustomGameOptionsData.customGameOptions = new CustomGameOptionsData();

            // Apply patches using Harmony
            Harmony.PatchAll();

            // Optionally, you can add more log outputs or initialization processes
            Logger.LogInfo($"Plugin {Id} loaded successfully.");
        }
    }
}
