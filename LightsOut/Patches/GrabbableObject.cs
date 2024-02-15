using HarmonyLib;
using UnityEngine;

namespace LightsOut
{
    [HarmonyPatch(typeof(GrabbableObject))]
    public static class GrabbableObjectPatch
    {
        [HarmonyPatch("DiscardItemOnClient")]
        [HarmonyPostfix]
        public static void DropPatch(GrabbableObject __instance)
        {
            Plugin.logger.LogDebug($"DiscardItemOnClient {__instance.itemProperties.itemName}");

            if (__instance.isInShipRoom)
            {
                LightSourceToggle.Disable(__instance);
            }
        }

        [HarmonyPatch("GrabItemOnClient")]
        [HarmonyPostfix]
        public static void GrabPatch(GrabbableObject __instance)
        {
            Plugin.logger.LogDebug($"GrabItemOnClient {__instance.itemProperties.itemName}");

            LightSourceToggle.Enable(__instance);
        }
    }
}
