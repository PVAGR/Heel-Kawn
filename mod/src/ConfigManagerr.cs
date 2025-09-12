// ConfigManager.cs
// Loads configuration for the mod, such as Twitch channel and settings.
// This file is required for flexible configuration without recompiling the mod.

using System;
using System.IO;

namespace HeelKawnPlugin
{
    public static class ConfigManager
    {
        public static string TwitchChannel { get; private set; } = "default_channel";

        public static void LoadConfig()
        {
            string configPath = "heelkawn_config.txt";
            if (!File.Exists(configPath))
            {
                Logger.Warn("Config file not found, using default settings.");
                TwitchChannel = "default_channel";
                return;
            }

            foreach (var line in File.ReadAllLines(configPath))
            {
                if (line.StartsWith("TwitchChannel=", StringComparison.OrdinalIgnoreCase))
                    TwitchChannel = line.Substring("TwitchChannel=".Length).Trim();
            }
            Logger.Info($"[ConfigManager] Loaded TwitchChannel: {TwitchChannel}");
        }
    }
}
