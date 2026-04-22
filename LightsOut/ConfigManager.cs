using BepInEx.Configuration;

namespace LightsOut;

internal class ConfigManager
{
  public static ConfigManager Instance { get; private set; }
  public static ConfigFile configFile;

  private ConfigManager(ConfigFile config)
  {
    configFile = config;
  }

  internal static void Init(ConfigFile config)
  {
    Instance = new ConfigManager(config);
  }
}
