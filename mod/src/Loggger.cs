// Logger.cs
// Simple logger utility for consistent debugging and information output.
// This file is essential for monitoring mod behavior and debugging.

using System;

namespace HeelKawnPlugin
{
    public static class Logger
    {
        public static void Info(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:HH:mm:ss} {message}");
        }

        public static void Warn(string message)
        {
            Console.WriteLine($"[WARN] {DateTime.Now:HH:mm:ss} {message}");
        }

        public static void Error(string message)
        {
            Console.WriteLine($"[ERROR] {DateTime.Now:HH:mm:ss} {message}");
        }
    }
}
