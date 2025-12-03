using AmongUsUnknownImpostors.Patches;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;

namespace AmongUsUnknownImpostors
{
    [BepInPlugin(Id, "Among Us Unknown Impostors", PluginVersion)]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("com.herysia.LobbyOptionsAPI")]
    public class UnknownImpostorsPlugin : BasePlugin
    {
        // Plugin ID constant
        public const string Id = "com.herysia.amongusunkimpostor";

        // Version du plugin (sync avec ton .csproj)
        public const string PluginVersion = "1.3.0";

        // RPC Settings ID (changé pour éviter les conflits)
        public static byte RpcSettingsId = 200;

        // Harmony instance for patching methods
        public static Harmony Harmony = new Harmony(Id);

        public override void Load()
        {
            // Initialize custom game options
            CustomGameOptionsData.customGameOptions = new CustomGameOptionsData();

            // Apply patches
            Harmony.PatchAll();

            Logger.LogInfo($"Plugin {Id} v{PluginVersion} loaded successfully.");
        }
    }
}
