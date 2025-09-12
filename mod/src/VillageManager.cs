// VillageManager.cs
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
    }
}
