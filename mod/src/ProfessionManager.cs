// ProfessionManager.cs
// Manages profession selection, requirements, and bonuses for Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.Collections.Generic;

namespace HeelKawnMod
{
    public class ProfessionManager
    {
        private readonly Dictionary<string, Profession> professions = new();
        private readonly Dictionary<string, string> playerProfessions = new();

        public ProfessionManager()
        {
            // Example professions
            professions["Farmer"] = new Profession { Name = "Farmer", Requirement = "None", Bonus = "+10% crop yield" };
            professions["Builder"] = new Profession { Name = "Builder", Requirement = "None", Bonus = "+10% build speed" };
            professions["Warrior"] = new Profession { Name = "Warrior", Requirement = "None", Bonus = "+10% combat effectiveness" };
            // Add more as needed
        }

        public string ChooseProfession(string player, string professionName)
        {
            if (!professions.ContainsKey(professionName))
                return $"Profession '{professionName}' does not exist.";
            if (playerProfessions.ContainsKey(player))
                return $"{player} already has a profession: {playerProfessions[player]}.";
            // TODO: Enforce requirements
            playerProfessions[player] = professionName;
            return $"{player} is now a {professionName}! Bonus: {professions[professionName].Bonus}";
        }

        public string GetProfession(string player)
        {
            return playerProfessions.TryGetValue(player, out var prof) ? prof : "None";
        }

        public Profession GetProfessionInfo(string professionName)
        {
            professions.TryGetValue(professionName, out var prof);
            return prof;
        }
    }

    public class Profession
    {
        public string Name { get; set; }
        public string Requirement { get; set; }
        public string Bonus { get; set; }
        // Add more fields as needed (e.g., unlocks, abilities)
    }
}
