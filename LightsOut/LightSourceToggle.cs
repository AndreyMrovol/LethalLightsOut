using System.Linq;
using HarmonyLib;
using LightsOut.Patches;
using UnityEngine;

namespace LightsOut
{
  public static class LightSourceToggle
  {
    public static void Disable(GrabbableObject item, bool stopAudio = false)
    {
      if (ShouldReturn(item))
        return;

      Plugin.debugLogger.LogDebug($"Disabling light of {item.itemProperties.itemName}");

      item.GetComponentsInChildren<Light>().Do(l => l.enabled = false);

      if ("LungProp" == item.__getTypeName() && stopAudio)
      {
        Plugin.debugLogger.LogDebug("Disabling sound of LungProp");

        LungProp itemLung = (LungProp)item;
        itemLung.isLungDocked = false;
        itemLung.isLungDockedInElevator = false;
        itemLung.isLungPowered = false;
        itemLung.GetComponent<AudioSource>().Stop();
      }

      if (item.__getTypeName() == "ToggleableFancyLamp")
      {
        GeneralImprovementsPatch.DisableGILamp(item);
      }
    }

    public static void Enable(GrabbableObject item)
    {
      if (ShouldReturn(item))
        return;

      Plugin.debugLogger.LogDebug($"Enabling light of {item.itemProperties.itemName}");

      item.GetComponentsInChildren<Light>().Do(l => l.enabled = true);

      if (item.__getTypeName() == "ToggleableFancyLamp")
      {
        GeneralImprovementsPatch.EnableGILamp(item);
      }
    }

    private static bool ShouldReturn(GrabbableObject item)
    {
      if (!item.isInShipRoom)
      {
        Plugin.debugLogger.LogDebug($"{item.__getTypeName()} is not in ship room");
        return true;
      }

      if (item.__getTypeName() != "PhysicsProp" && item.__getTypeName() != "LungProp" && item.__getTypeName() != "ToggleableFancyLamp")
      {
        Plugin.debugLogger.LogDebug($"{item.__getTypeName()} is not a predefined type");
        return true;
      }

      if (item.GetComponentInChildren<Light>() == null)
      {
        Plugin.debugLogger.LogDebug($"{item.__getTypeName()} has no light");
        return true;
      }

      return false;
    }
  }
}
