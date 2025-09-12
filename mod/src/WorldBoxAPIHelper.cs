// WorldBoxAPIHelper.cs
// Stub for interacting with the WorldBox game world for player actions.
// This file is necessary as a bridge between multiplayer player actions and affecting the actual game world.

using System;

namespace HeelKawnPlugin
{
    public static class WorldBoxAPIHelper
    {
        public static void MovePlayer(PlayerData player, string direction)
        {
            // Placeholder logic for moving in 2D
            WBVector2 delta = direction?.ToLower() switch
            {
                "north" => new WBVector2(0, 1),
                "south" => new WBVector2(0, -1),
                "east"  => new WBVector2(1, 0),
                "west"  => new WBVector2(-1, 0),
                _       => new WBVector2(0, 0)
            };
            player.Position = new WBVector2(player.Position.x + delta.x, player.Position.y + delta.y);
            Logger.Info($"[WorldBoxAPIHelper] {player.Username} moved {direction} to {player.Position}");
        }

        public static void Pray(PlayerData player)
        {
            Logger.Info($"[WorldBoxAPIHelper] {player.Username} prayed.");
            // No-op for now
        }

        public static void Farm(PlayerData player)
        {
            Logger.Info($"[WorldBoxAPIHelper] {player.Username} farmed.");
            // No-op for now
        }
    }
}
