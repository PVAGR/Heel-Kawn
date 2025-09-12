// PlayerManager.cs
// Handles player registration, lookup, and action queues for Heel-Kawn Multiplayer Mod.

using System.Collections.Generic;

namespace HeelKawnPlugin
{
    public class PlayerData
    {
        public string Username;
        public string Village;
        public string Kingdom;
        public List<PlayerAction> ActionQueue = new List<PlayerAction>();
        public WBVector2 Position = new WBVector2(0, 0); // Placeholder struct for position
    }

    public static class PlayerManager
    {
        private static Dictionary<string, PlayerData> players = new Dictionary<string, PlayerData>();

        public static PlayerData EnsurePlayer(string username)
        {
            if (!players.TryGetValue(username, out var player))
            {
                player = new PlayerData { Username = username };
                players[username] = player;
            }
            return player;
        }

        public static PlayerData GetOrNull(string username)
        {
            players.TryGetValue(username, out var player);
            return player;
        }

        public static void QueueAction(PlayerData player, PlayerAction action)
        {
            player.ActionQueue.Add(action);
        }

        // For test/dev: clear all registered players
        public static void ClearAll()
        {
            players.Clear();
        }

        // (Optional) Get all player usernames
        public static IEnumerable<string> AllUsernames()
        {
            return players.Keys;
        }
    }

    // Placeholder position struct for compatibility with WorldBox
    public struct WBVector2
    {
        public float x;
        public float y;
        public WBVector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"({x},{y})";
        }
    }
}
