using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace LightsOut
{
    public static class LightSourceToggle
    {
        public static void Disable(GrabbableObject item, bool stopAudio = false)
        {
            if (ShouldReturn(item))
                return;

            Plugin.logger.LogDebug($"Disabling light of {item.itemProperties.itemName}");

            item.GetComponentsInChildren<Light>().ToList().Do(l => l.enabled = false);
            // item.GetComponentsInChildren<ParticleSystem>()
            //     .ToList()
            //     .Do(p =>
            //     {
            //         p.Clear();
            //         p.Stop();
            //     });

            if ("LungProp" == item.__getTypeName() && stopAudio)
            {
                Plugin.logger.LogDebug("Disabling sound of LungProp");

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

            Plugin.logger.LogDebug($"Enabling light of {item.itemProperties.itemName}");

            item.GetComponentInChildren<Light>().enabled = true;

            if (item.__getTypeName() == "ToggleableFancyLamp")
            {
                GeneralImprovementsPatch.EnableGILamp(item);
            }
        }

        private static bool ShouldReturn(GrabbableObject item)
        {
            // Plugin.logger.LogDebug($"{item.__getTypeName()}");

            if (!item.isInShipRoom)
            {
                Plugin.logger.LogDebug($"{item.__getTypeName()} is not in ship room");
                return true;
            }

            if (item.GetComponentInChildren<Light>() == null)
            {
                Plugin.logger.LogDebug($"{item.__getTypeName()} has no light");
                return true;
            }

            if (
                item.__getTypeName() != "PhysicsProp"
                && item.__getTypeName() != "LungProp"
                && item.__getTypeName() != "ToggleableFancyLamp"
            // && item.__getTypeName() != "lighterStuff"
            )
            {
                Plugin.logger.LogDebug($"{item.__getTypeName()} is not a predefined type");
                return true;
            }

            return false;
        }
    }
}
