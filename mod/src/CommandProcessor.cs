// CommandProcessor.cs
// Handles parsing and execution of commands from Twitch chat for Heel-Kawn Multiplayer Mod.

using System;

namespace HeelKawnPlugin
{
    public static class CommandProcessor
    {
        public static void HandleCommand(string username, string cmd, string arg)
        {
            // Ensure player exists
            var player = PlayerManager.EnsurePlayer(username);

            switch (cmd)
            {
                case "join":
                    HandleJoin(player);
                    break;
                case "move":
                    HandleMove(player, arg);
                    break;
                case "pray":
                    HandlePray(player);
                    break;
                case "farm":
                    HandleFarm(player);
                    break;
                case "help":
                    HandleHelp(player);
                    break;
                default:
                    Logger.Warn($"Unknown command: !{cmd} from {username}");
                    break;
            }
        }

        private static void HandleJoin(PlayerData player)
        {
            if (player.Position.x == 0 && player.Position.y == 0)
            {
                // Spawn at default position
                var spawnPos = new WBVector2(10, 10); // Arbitrary default
                WorldBoxAPIHelper.SpawnVillager(player, spawnPos);
                Logger.Info($"{player.Username} has joined the world at {spawnPos}");
            }
            else
            {
                Logger.Info($"{player.Username} is already in the world at {player.Position}");
            }
        }

        private static void HandleMove(PlayerData player, string arg)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                Logger.Warn($"No direction given for !move by {player.Username}");
                return;
            }
            var moveAction = new PlayerAction { Type = PlayerActionType.Move, Arg = arg };
            PlayerManager.QueueAction(player, moveAction);
            Logger.Info($"{player.Username} queued move: {arg}");
        }

        private static void HandlePray(PlayerData player)
        {
            var prayAction = new PlayerAction { Type = PlayerActionType.Pray };
            PlayerManager.QueueAction(player, prayAction);
            Logger.Info($"{player.Username} queued pray action.");
        }

        private static void HandleFarm(PlayerData player)
        {
            var farmAction = new PlayerAction { Type = PlayerActionType.Farm };
            PlayerManager.QueueAction(player, farmAction);
            Logger.Info($"{player.Username} queued farm action.");
        }

        private static void HandleHelp(PlayerData player)
        {
            // Just log help info for now
            Logger.Info("Available commands: !join, !move [direction], !pray, !farm, !help");
        }

        // Advanced commands (e.g., build, village, kingdom) can be added here later.
    }
}
