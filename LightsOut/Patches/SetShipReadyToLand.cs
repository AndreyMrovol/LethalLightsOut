using HarmonyLib;
using UnityEngine;

namespace LightsOut
{
    [HarmonyPatch(typeof(StartOfRound))]
    public static class SetShipReadyToLandPatch
    {
        [HarmonyPatch("SetShipReadyToLand")]
        [HarmonyPostfix]
        public static void TurnOffLights(StartOfRound __instance)
        {
            GameObject ship = GameObject.Find("/Environment/HangarShip");
            var ItemsOnShip = ship.GetComponentsInChildren<GrabbableObject>();
            foreach (var item in ItemsOnShip)
            {
                if (
                    item.itemProperties.itemName == "Fancy lamp"
                    || item.itemProperties.itemName == "Apparatus"
                )
                {
                    item.GetComponentInChildren<Light>().enabled = false;
                }
            }
        }
    }
}
