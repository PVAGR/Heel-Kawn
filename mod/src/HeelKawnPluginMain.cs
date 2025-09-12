// HeelKawnPluginMain.cs
// Main entry point for Heel-Kawn Multiplayer Mod.

using System;

namespace HeelKawnPlugin
{
    public class HeelKawnPluginMain
    {
        private static TwitchBotStub twitchBot;

        public static void Main(string[] args)
        {
            Logger.Info("Heel-Kawn Multiplayer Mod starting up...");

            // Load config
            ConfigManager.LoadConfig();

            // Initialize Twitch bot (stub/sim)
            twitchBot = new TwitchBotStub(ConfigManager.TwitchChannel);
            twitchBot.OnCommandReceived += CommandProcessor.HandleCommand;

            // Start simulated Twitch input loop (for Tech Level I)
            Logger.Info("Starting simulated Twitch bot input loop...");
            twitchBot.StartInputLoop();
        }

        // In a real mod, this would be called from a game loop (e.g., OnTick, Update, etc.)
        public static void Tick()
        {
            ActionProcessor.ProcessAll();
        }
    }
}
