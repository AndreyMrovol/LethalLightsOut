using HarmonyLib;
using UnityEngine;

namespace LightsOut.Patches
{
  [HarmonyPatch(typeof(StartOfRound))]
  public static class SetShipReadyToLandPatch
  {
    [HarmonyPatch(nameof(StartOfRound.SetShipReadyToLand))]
    [HarmonyPostfix]
    public static void TurnOffLights()
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
