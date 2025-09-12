// ConfigManager.cs
// Handles loading and storing configuration for Heel-Kawn Multiplayer Mod.

using System;
using System.IO;
using System.Collections.Generic;

namespace HeelKawnPlugin
{
    public static class ConfigManager
    {
        public static string TwitchUsername { get; private set; } = "";
        public static string TwitchOAuth { get; private set; } = "";
        public static string TwitchChannel { get; private set; } = "";

        private static string configFile = "HeelKawnConfig.ini";
        private static Dictionary<string, string> config = new Dictionary<string, string>();

        public static void LoadConfig()
        {
            if (!File.Exists(configFile))
            {
                Logger.Warn($"Config file {configFile} not found. Creating a new one with placeholders.");
                CreateDefaultConfig();
                return;
            }

            foreach (var line in File.ReadAllLines(configFile))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#"))
                    continue;
                var parts = trimmed.Split('=', 2);
                if (parts.Length == 2)
                {
                    config[parts[0].Trim()] = parts[1].Trim();
                }
            }

            config.TryGetValue("TwitchUsername", out var user);
            config.TryGetValue("TwitchOAuth", out var oauth);
            config.TryGetValue("TwitchChannel", out var channel);

            TwitchUsername = user ?? "";
            TwitchOAuth = oauth ?? "";
            TwitchChannel = channel ?? "";

            Logger.Info($"Loaded config: TwitchUser={TwitchUsername}, Channel={TwitchChannel}");
        }

        private static void CreateDefaultConfig()
        {
            var lines = new[]
            {
                "# Heel-Kawn Multiplayer Mod Config",
                "TwitchUsername=YOUR_TWITCH_USERNAME",
                "TwitchOAuth=oauth:YOUR_TOKEN_HERE",
                "TwitchChannel=YOUR_CHANNEL"
            };
            File.WriteAllLines(configFile, lines);
            Logger.Warn("Default config created. Please fill in your Twitch credentials.");
        }
    }
}
