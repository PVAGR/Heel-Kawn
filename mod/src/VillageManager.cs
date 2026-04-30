// VillageManager.cs
// Manages founding, joining, and managing villages, mayor voting, and war declarations for Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HeelKawnMod
{
    public class VillageManager
    {
        private readonly Dictionary<string, Village> villages = new();
        private readonly string savePath = Path.Combine(BepInEx.Paths.ConfigPath, "heelkawn_villages.json");

        public VillageManager()
        {
            LoadVillages();
        }

        public string FoundVillage(string founder, string villageName)
        {
            if (villages.ContainsKey(villageName))
                return $"Village '{villageName}' already exists.";
            villages[villageName] = new Village { Name = villageName, Mayor = founder, Members = new List<string> { founder }, Resources = 0 };
            SaveVillages();
            return $"Village '{villageName}' founded by {founder}.";
        }

        public string JoinVillage(string player, string villageName)
        {
            if (!villages.ContainsKey(villageName))
                return $"Village '{villageName}' does not exist.";
            if (villages[villageName].Members.Contains(player))
                return $"{player} is already a member of '{villageName}'.";
            villages[villageName].Members.Add(player);
            SaveVillages();
            return $"{player} joined village '{villageName}'.";
        }

        public string StartMayorVote(string villageName, List<string> candidates)
        {
            // TODO: Implement mayor voting logic
            return $"Mayor vote started in '{villageName}' for: {string.Join(", ", candidates)}.";
        }

        public string DeclareWar(string fromVillage, string toVillage)
        {
            // TODO: Implement war declaration logic
            return $"{fromVillage} has declared war on {toVillage}!";
        }

        public Village GetVillage(string villageName)
        {
            villages.TryGetValue(villageName, out var village);
            return village;
        }

        private void SaveVillages()
        {
            File.WriteAllText(savePath, JsonSerializer.Serialize(villages));
        }

        private void LoadVillages()
        {
            if (File.Exists(savePath))
            {
                var json = File.ReadAllText(savePath);
                var loaded = JsonSerializer.Deserialize<Dictionary<string, Village>>(json);
                if (loaded != null)
                    foreach (var kv in loaded)
                        villages[kv.Key] = kv.Value;
            }
        }
    }

    public class Village
    {
        public string Name { get; set; }
        public string Mayor { get; set; }
        public List<string> Members { get; set; }
        public int Resources { get; set; }
        // Add more fields as needed (e.g., alliances, war status, etc.)
    }
}
