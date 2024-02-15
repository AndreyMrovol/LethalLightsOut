using UnityEngine;

namespace LightsOut
{
    public static class LightSourceToggle
    {
        public static void Disable(GrabbableObject item)
        {
            if (ShouldReturn(item))
                return;

            Plugin.logger.LogDebug($"Disabling light of {item.itemProperties.itemName}");

            item.GetComponentInChildren<Light>().enabled = false;

            if (typeof(LungProp) == item.itemProperties.GetType())
            {
                AudioSource thisAudio = item.gameObject.GetComponent<AudioSource>();
                thisAudio.Stop();
            }
        }

        public static void Enable(GrabbableObject item)
        {
            if (ShouldReturn(item))
                return;

            Plugin.logger.LogDebug($"Enabling light of {item.itemProperties.itemName}");

            item.GetComponentInChildren<Light>().enabled = true;
        }

        private static bool ShouldReturn(GrabbableObject item)
        {
            Plugin.logger.LogDebug($"{item.__getTypeName()}");

            if (item.GetComponentInChildren<Light>() == null)
            {
                Plugin.logger.LogDebug("No light found");
                return true;
            }

            if (item.__getTypeName() != "PhysicsProp" && item.__getTypeName() != "LungProp")
            {
                Plugin.logger.LogDebug("Not a PhysicsProp");
                return true;
            }

            return false;
        }
    }
}
