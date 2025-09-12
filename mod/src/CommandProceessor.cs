// CommandProcessor.cs
// Handles Twitch chat commands and queues corresponding player actions.
// We need this file to translate incoming chat commands into in-game actions for each player.

using System;

namespace HeelKawnPlugin
{
    public static class CommandProcessor
    {
        // Handles a chat command from a Twitch user.
        public static void HandleCommand(string username, string commandText)
        {
            var player = PlayerManager.EnsurePlayer(username);

            // Simple command parsing (expand as needed)
            string[] parts = commandText.Trim().Split(' ');
            string cmd = parts[0].ToLower();
            string arg = parts.Length > 1 ? parts[1] : null;

            PlayerAction action = null;

            switch (cmd)
            {
                case "!move":
                    action = new PlayerAction { Type = PlayerActionType.Move, Arg = arg };
                    break;
                case "!pray":
                    action = new PlayerAction { Type = PlayerActionType.Pray };
                    break;
                case "!farm":
                    action = new PlayerAction { Type = PlayerActionType.Farm };
                    break;
                default:
                    Logger.Info($"Unknown command from {username}: {commandText}");
                    return;
            }

            PlayerManager.QueueAction(player, action);
            Logger.Info($"{username} queued {cmd} action.");
        }
    }
}
