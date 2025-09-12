// Logger.cs
// Simple logger for Heel-Kawn Multiplayer Mod. Logs to BepInEx console (or System.Console for stub/testing).

using System;

namespace HeelKawnPlugin
{
    public static class Logger
    {
        // Toggle debug output
        public static bool DebugEnabled = true;

        public static void Info(string message)
        {
            if (DebugEnabled)
                Console.WriteLine($"[HeelKawn][INFO] {message}");
        }

        public static void Warn(string message)
        {
            if (DebugEnabled)
                Console.WriteLine($"[HeelKawn][WARN] {message}");
        }

        public static void Error(string message)
        {
            if (DebugEnabled)
                Console.WriteLine($"[HeelKawn][ERROR] {message}");
        }
    }
}
