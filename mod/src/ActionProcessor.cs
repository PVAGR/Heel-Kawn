// ActionProcessor.cs
// Processes queued actions for all players in Heel-Kawn Multiplayer Mod.

using System.Collections.Generic;

namespace HeelKawnPlugin
{
    public static class ActionProcessor
    {
        // Called from mod main loop/tick
        public static void ProcessAll()
        {
            foreach (var username in PlayerManager.AllUsernames())
            {
                var player = PlayerManager.GetOrNull(username);
                if (player == null)
                    continue;

                ProcessPlayerActions(player);
            }
        }

        private static void ProcessPlayerActions(PlayerData player)
        {
            if (player.ActionQueue.Count == 0)
                return;

            // Process one action per tick for simplicity
            var action = player.ActionQueue[0];
            player.ActionQueue.RemoveAt(0);

            switch (action.Type)
            {
                case PlayerActionType.Move:
                    WorldBoxAPIHelper.MoveVillager(player, action.Arg);
                    break;
                case PlayerActionType.Pray:
                    WorldBoxAPIHelper.Pray(player);
                    break;
                case PlayerActionType.Farm:
                    WorldBoxAPIHelper.Farm(player);
                    break;
                default:
                    Logger.Warn($"Unknown action type: {action.Type} for {player.Username}");
                    break;
            }
        }
    }
}
