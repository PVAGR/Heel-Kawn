// VillageManager.cs
<<<<<<< HEAD
// Handles villages and kingdoms for Heel-Kawn Multiplayer Mod.

using System.Collections.Generic;

namespace HeelKawnPlugin
{
    public class VillageData
    {
        public string Name;
        public List<string> Members = new List<string>();
        public string Kingdom;
    }

    public class KingdomData
    {
        public string Name;
        public List<string> Villages = new List<string>();
    }

    public static class VillageManager
    {
        private static Dictionary<string, VillageData> villages = new Dictionary<string, VillageData>();
        private static Dictionary<string, KingdomData> kingdoms = new Dictionary<string, KingdomData>();

        public static VillageData EnsureVillage(string name)
        {
            if (!villages.TryGetValue(name, out var v))
            {
                v = new VillageData { Name = name };
                villages[name] = v;
            }
            return v;
        }

        public static KingdomData EnsureKingdom(string name)
        {
            if (!kingdoms.TryGetValue(name, out var k))
            {
                k = new KingdomData { Name = name };
                kingdoms[name] = k;
            }
            return k;
        }

        public static void AddVillagerToVillage(string username, string villageName)
        {
            var village = EnsureVillage(villageName);
            if (!village.Members.Contains(username))
                village.Members.Add(username);

            // Optionally, assign to player data as well
            var player = PlayerManager.GetOrNull(username);
            if (player != null)
                player.Village = villageName;
        }

        public static void AssignVillageToKingdom(string villageName, string kingdomName)
        {
            var village = EnsureVillage(villageName);
            village.Kingdom = kingdomName;

            var kingdom = EnsureKingdom(kingdomName);
            if (!kingdom.Villages.Contains(villageName))
                kingdom.Villages.Add(villageName);
        }

        // (Optional) Get all villages/kingdoms
        public static IEnumerable<string> AllVillages() => villages.Keys;
        public static IEnumerable<string> AllKingdoms() => kingdoms.Keys;

        // For test/dev: clear all
        public static void ClearAll()
        {
            villages.Clear();
            kingdoms.Clear();
        }
=======
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
>>>>>>> 14731da (Auto-connect heelkawn bot to pvagames Twitch channel; config and logging improvements)
    }
}
