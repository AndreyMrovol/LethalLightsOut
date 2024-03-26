using HarmonyLib;
using UnityEngine;

namespace LightsOut
{
    [HarmonyPatch(typeof(GrabbableObject))]
    public static class GrabbableObjectPatch
    {
        [HarmonyPatch("DiscardItemClientRpc")]
        [HarmonyPostfix]
        public static void DiscardItemClientRpc(GrabbableObject __instance)
        {
            Plugin.logger.LogDebug($"DiscardItemClientRpc {__instance.itemProperties.itemName}");

            if (__instance.isInShipRoom)
            {
                LightSourceToggle.Disable(__instance, true);
            }
        }

        [HarmonyPatch("GrabClientRpc")]
        [HarmonyPostfix]
        public static void GrabClientRpc(GrabbableObject __instance)
        {
            Plugin.logger.LogDebug($"GrabClientRpc {__instance.itemProperties.itemName}");

            LightSourceToggle.Enable(__instance);
        }
    }
}
