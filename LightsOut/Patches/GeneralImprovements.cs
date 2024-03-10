using GeneralImprovements.Items;

namespace LightsOut
{
    class GeneralImprovementsPatch
    {
        public static void DisableGILamp(GrabbableObject lamp)
        {
            try
            {
                ToggleableFancyLamp fancyLamp = (ToggleableFancyLamp)lamp;

                fancyLamp.ItemActivate(false, false);
            }
            catch
            {
                Plugin.logger.LogWarning("Failed to disable GI lamp");
            }
        }
    }
}
