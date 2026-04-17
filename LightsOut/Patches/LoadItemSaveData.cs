using HarmonyLib;
using UnityEngine;

namespace LightsOut.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    public static class LoadItemPatch
    {
        [HarmonyPatch(nameof(StartOfRound.LoadShipGrabbableItems))]
        [HarmonyPostfix]
        public static void ServerTurnOffLights(StartOfRound __instance)
        {
            GameObject ship = GameObject.Find("/Environment/HangarShip");
            var ItemsOnShip = ship.GetComponentsInChildren<GrabbableObject>();
            foreach (var item in ItemsOnShip)
            {
                LightSourceToggle.Disable(item, true);
            }
        }

        [HarmonyPatch(nameof(StartOfRound.SyncShipUnlockablesClientRpc))]
        [HarmonyPostfix]
        public static void ClientTurnOffLights(StartOfRound __instance)
        {
            GameObject ship = GameObject.Find("/Environment/HangarShip");
            var ItemsOnShip = ship.GetComponentsInChildren<GrabbableObject>();
            foreach (var item in ItemsOnShip)
            {
                LightSourceToggle.Disable(item, true);
            }
        }
    }
}
