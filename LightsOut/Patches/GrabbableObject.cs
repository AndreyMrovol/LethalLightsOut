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

        [HarmonyPatch("DiscardItemOnClient")]
        [HarmonyPostfix]
        public static void DiscardItemOnClient(GrabbableObject __instance)
        {
            Plugin.logger.LogDebug($"DiscardItemOnClient {__instance.itemProperties.itemName}");

            if (__instance.isInShipRoom)
            {
                LightSourceToggle.Disable(__instance);
            }
        }

        [HarmonyPatch("GrabClientRpc")]
        [HarmonyPostfix]
        public static void GrabClientRpc(GrabbableObject __instance)
        {
            Plugin.logger.LogDebug($"GrabClientRpc {__instance.itemProperties.itemName}");

            LightSourceToggle.Enable(__instance);
        }

        [HarmonyPatch("GrabItemOnClient")]
        public static void GrabItemOnClient(GrabbableObject __instance)
        {
            Plugin.logger.LogDebug($"GrabItemOnClient {__instance.itemProperties.itemName}");

            LightSourceToggle.Enable(__instance);
        }
    }
}
