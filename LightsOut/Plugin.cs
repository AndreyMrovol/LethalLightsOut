using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LightsOut
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static ManualLogSource logger;
        private readonly Harmony harmony = new("LightsOut");

        internal static bool isGIPresent = false;

        private void Awake()
        {
            logger = Logger;

            harmony.PatchAll();

            if (
                BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(
                    "ShaosilGaming.GeneralImprovements"
                )
            )
            {
                isGIPresent = true;
            }

            // Plugin startup logic
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
