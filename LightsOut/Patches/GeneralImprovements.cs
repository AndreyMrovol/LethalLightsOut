using GeneralImprovements.Items;

namespace LightsOut.Patches
{
  class GeneralImprovementsPatch
  {
    public static void DisableGILamp(GrabbableObject lamp)
    {
      try
      {
        ToggleableFancyLamp fancyLamp = (ToggleableFancyLamp)lamp;

        fancyLamp.ItemActivate(false, false);
        fancyLamp.isBeingUsed = false;
      }
      catch
      {
        Plugin.debugLogger.LogWarning("Failed to disable GI lamp");
      }
    }

    public static void EnableGILamp(GrabbableObject lamp)
    {
      try
      {
        ToggleableFancyLamp fancyLamp = (ToggleableFancyLamp)lamp;

        fancyLamp.ItemActivate(true, false);
        fancyLamp.isBeingUsed = true;
      }
      catch
      {
        Plugin.debugLogger.LogWarning("Failed to enable GI lamp");
      }
    }
  }
}
