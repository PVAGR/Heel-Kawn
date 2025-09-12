// PlayerManager.cs
// Manages player-villager mapping and player actions in Heel-Kawn WorldBox Multiplayer Mod
//
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

		public PlayerManager()
		{
			LoadPlayers();
		}

		public string RegisterPlayer(string username)
		{
			if (!players.ContainsKey(username))
			{
				var code = GenerateUniqueCode();
				players[username] = new PlayerData { Username = username, UniqueCode = code };
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
			// TODO: Implement movement logic
			Console.WriteLine($"[PlayerManager] {username} moves {string.Join(",", args)}");
		}
		private void HandleFarm(string username)
		{
			// TODO: Implement farming logic
			Console.WriteLine($"[PlayerManager] {username} farms");
		}
		private void HandleBuild(string username)
		{
			// TODO: Implement building logic
			Console.WriteLine($"[PlayerManager] {username} builds");
		}
		private void HandleFight(string username)
		{
			// TODO: Implement fighting logic
			Console.WriteLine($"[PlayerManager] {username} fights");
		}
		private void HandleRespawn(string username)
		{
			// TODO: Implement respawn logic
			Console.WriteLine($"[PlayerManager] {username} respawns");
		}

		private string GenerateUniqueCode()
		{
			return Guid.NewGuid().ToString("N").Substring(0, 8);
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
		// Add more metadata as needed (traits, stats, etc.)
	}

	public class PlayerAction
	{
		public string Username { get; set; }
		public string Action { get; set; }
		public string[] Args { get; set; }
	}
}
