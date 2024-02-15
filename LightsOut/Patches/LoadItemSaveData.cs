using HarmonyLib;
using UnityEngine;

namespace LightsOut
{
    [HarmonyPatch(typeof(StartOfRound))]
    public static class LoadItemPatch
    {
        [HarmonyPatch("LoadShipGrabbableItems")]
        [HarmonyPostfix]
        public static void TurnOffLights(StartOfRound __instance)
        {
            GameObject ship = GameObject.Find("/Environment/HangarShip");
            var ItemsOnShip = ship.GetComponentsInChildren<GrabbableObject>();
            foreach (var item in ItemsOnShip)
            {
                LightSourceToggle.Disable(item);
            }
        }
    }
}
