// Logger.cs
// Simple logger for Heel-Kawn Multiplayer Mod. Logs to BepInEx console (or System.Console for stub/testing).

using System;
using BepInEx.Logging;

namespace HeelKawnMod
{
    public static class Logger
    {
        private static ManualLogSource _logSource;

        public static void Initialize(ManualLogSource logSource)
        {
            _logSource = logSource;
        }

        public static void Info(string message)
        {
            _logSource?.LogInfo(message);
        }

        public static void Warn(string message)
        {
            _logSource?.LogWarning(message);
        }

        public static void Error(string message)
        {
            _logSource?.LogError(message);
        }

        public static void Debug(string message)
        {
            _logSource?.LogDebug(message);
        }
    }
}
