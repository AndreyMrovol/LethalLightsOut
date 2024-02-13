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
                if (
                    __instance.itemProperties.itemName == "Fancy lamp"
                    || __instance.itemProperties.itemName == "Apparatus"
                )
                {
                    Plugin.logger.LogInfo("Disabling light");
                    __instance.GetComponentInChildren<Light>().enabled = false;
                    // __instance.EnableItemMeshes(false);

                    if (typeof(LungProp) == __instance.itemProperties.GetType())
                    {
                        Plugin.logger.LogInfo("LungProp");
                        AudioSource thisAudio = __instance.gameObject.GetComponent<AudioSource>();
                        thisAudio.Stop();
                    }
                }
            }
        }

        [HarmonyPatch("GrabItemOnClient")]
        [HarmonyPostfix]
        public static void GrabPatch(GrabbableObject __instance)
        {
            Plugin.logger.LogDebug($"GrabItemOnClient {__instance.itemProperties.itemName}");

            if (
                __instance.itemProperties.itemName == "Fancy lamp"
                || __instance.itemProperties.itemName == "Apparatus"
            )
            {
                Plugin.logger.LogInfo("Enabling light");
                __instance.GetComponentInChildren<Light>().enabled = true;

                if (typeof(LungProp) == __instance.itemProperties.GetType())
                {
                    Plugin.logger.LogInfo("LungProp");
                }
                // __instance.EnableItemMeshes(false);
            }
        }
    }
}
