// PlayerManager.cs
// Manages player-villager mapping and player actions in Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HeelKawnMod
{
    public class PlayerManager
    {
        private readonly Dictionary<string, PlayerData> players = new();
        private readonly Queue<PlayerAction> actionQueue = new();
        private readonly string savePath = Path.Combine(BepInEx.Paths.ConfigPath, "heelkawn_players.json");
        private readonly ManualLogSource logger;

        public PlayerManager()
        {
            logger = Logger.CreateLogSource("PlayerManager");
            LoadPlayers();
        }

        public string RegisterPlayer(string username)
        {
            if (!players.ContainsKey(username))
            {
                var code = GenerateUniqueCode();
                var villagerId = AssignVillager(username);
                players[username] = new PlayerData { Username = username, UniqueCode = code, VillagerId = villagerId };
                SavePlayers();
            }
            return players[username].UniqueCode;
        }

        public void QueueAction(string username, string action, string[] args)
        {
            actionQueue.Enqueue(new PlayerAction { Username = username, Action = action, Args = args });
        }

        public void ProcessActions()
        {
            while (actionQueue.Count > 0)
            {
                var act = actionQueue.Dequeue();
                switch (act.Action.ToLower())
                {
                    case "move":
                        HandleMove(act.Username, act.Args);
                        break;
                    case "farm":
                        HandleFarm(act.Username);
                        break;
                    case "build":
                        HandleBuild(act.Username);
                        break;
                    case "fight":
                        HandleFight(act.Username);
                        break;
                    case "respawn":
                        HandleRespawn(act.Username);
                        break;
                }
            }
        }

        private void HandleMove(string username, string[] args)
        {
            if (!players.ContainsKey(username)) return;
            var villagerId = players[username].VillagerId;
            if (args.Length > 0)
            {
                WorldBoxAPIHelper.MoveActor(villagerId, args[0]);
                logger.LogInfo($"{username} moves {args[0]} (VillagerId: {villagerId})");
            }
        }

        private void HandleFarm(string username)
        {
            if (!players.ContainsKey(username)) return;
            var villagerId = players[username].VillagerId;
            WorldBoxAPIHelper.Farm(villagerId);
            logger.LogInfo($"{username} farms (VillagerId: {villagerId})");
        }

        private void HandleBuild(string username)
        {
            if (!players.ContainsKey(username)) return;
            var villagerId = players[username].VillagerId;
            WorldBoxAPIHelper.Build(villagerId);
            logger.LogInfo($"{username} builds (VillagerId: {villagerId})");
        }

        private void HandleFight(string username)
        {
            if (!players.ContainsKey(username)) return;
            var villagerId = players[username].VillagerId;
            WorldBoxAPIHelper.Fight(villagerId);
            logger.LogInfo($"{username} fights (VillagerId: {villagerId})");
        }

        private void HandleRespawn(string username)
        {
            if (!players.ContainsKey(username)) return;
            var villagerId = players[username].VillagerId;
            WorldBoxAPIHelper.Respawn(villagerId);
            logger.LogInfo($"{username} respawns (VillagerId: {villagerId})");
        }

        private string GenerateUniqueCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }

        private string AssignVillager(string username)
        {
            // Integrate with WorldBoxAPIHelper to spawn a villager and return its ID
            var villagerId = WorldBoxAPIHelper.SpawnActor(username, username + "'s Villager");
            return villagerId;
        }

        public string GetVillagerId(string username)
        {
            if (players.TryGetValue(username, out var player))
                return player.VillagerId;
            return null;
        }

        private void SavePlayers()
        {
            File.WriteAllText(savePath, JsonSerializer.Serialize(players));
        }

        private void LoadPlayers()
        {
            if (File.Exists(savePath))
            {
                var json = File.ReadAllText(savePath);
                var loaded = JsonSerializer.Deserialize<Dictionary<string, PlayerData>>(json);
                if (loaded != null)
                    foreach (var kv in loaded)
                        players[kv.Key] = kv.Value;
            }
        }
    }

    public class PlayerData
    {
        public string Username { get; set; }
        public string UniqueCode { get; set; }
        public string VillagerId { get; set; }
        // Add more metadata as needed (traits, stats, etc.)
    }

    public class PlayerAction
    {
        public string Username { get; set; }
        public string Action { get; set; }
        public string[] Args { get; set; }
    }
}
