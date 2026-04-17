using BepInEx.Configuration;
using MrovLib;

namespace LightsOut;

internal class ConfigManager
{
    internal static ConfigEntry<LoggingType> Debug { get; private set; }

    public static ConfigManager Instance { get; private set; }
    public static ConfigFile configFile;

    private ConfigManager(ConfigFile config)
    {
        configFile = config;
        Debug = configFile.Bind(
            "General",
            "Logging levels",
            LoggingType.Basic,
            "Enable debug logging"
        );
    }

    internal static void Init(ConfigFile config)
    {
        Instance = new ConfigManager(config);
    }
}
