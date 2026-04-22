using HarmonyLib;
using UnityEngine;

namespace LightsOut.Patches
{
  [HarmonyPatch(typeof(GrabbableObject))]
  public static class GrabbableObjectPatch
  {
    [HarmonyPatch(nameof(GrabbableObject.DiscardItem))]
    [HarmonyPostfix]
    public static void DiscardItemClientRpc(GrabbableObject __instance)
    {
      Plugin.Logger.LogDebug($"DiscardItem {__instance.itemProperties.itemName}");

      if (__instance.isInShipRoom)
      {
        LightSourceToggle.Disable(__instance, true);
      }
    }

    [HarmonyPatch(nameof(GrabbableObject.GrabItem))]
    [HarmonyPostfix]
    public static void GrabClientRpc(GrabbableObject __instance)
    {
      Plugin.Logger.LogDebug($"GrabItem {__instance.itemProperties.itemName}");

      LightSourceToggle.Enable(__instance);
    }
  }
}
