using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LightsOut
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency(
        "ShaosilGaming.GeneralImprovements",
        BepInDependency.DependencyFlags.SoftDependency
    )]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource logger;
        private readonly Harmony harmony = new(MyPluginInfo.PLUGIN_NAME);
        internal static Logger debugLogger = new(MyPluginInfo.PLUGIN_NAME);

        private void Awake()
        {
            logger = Logger;

            harmony.PatchAll();

            ConfigManager.Init(Config);

            // Plugin startup logic
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
