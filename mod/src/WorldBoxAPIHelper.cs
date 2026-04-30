// WorldBoxAPIHelper.cs
// Provides helper methods for interacting with WorldBox via reflection.
// Spawns actors, moves them, and sets names for integration with Heel-Kawn mod.

using System;
using System.Collections.Generic;

namespace HeelKawnMod
{
    public static class WorldBoxAPIHelper
    {
        // Simulated in-memory actor registry for demo purposes
        private static Dictionary<string, Actor> actors = new();
        private static int nextId = 1;

        public static string SpawnActor(string username, string name)
        {
            var id = $"actor_{nextId++}";
            actors[id] = new Actor { Id = id, Name = name, Owner = username, X = 0, Y = 0 };
            Console.WriteLine($"[WorldBoxAPIHelper] Spawned actor '{name}' for {username} (ID: {id})");
            return id;
        }

        public static void MoveActor(string actorId, string direction)
        {
            if (!actors.ContainsKey(actorId)) return;
            var actor = actors[actorId];
            switch (direction.ToLower())
            {
                case "north": actor.Y += 1; break;
                case "south": actor.Y -= 1; break;
                case "east": actor.X += 1; break;
                case "west": actor.X -= 1; break;
            }
            Console.WriteLine($"[WorldBoxAPIHelper] Moved actor {actorId} to ({actor.X},{actor.Y})");
        }

        public static void SetActorName(string actorId, string name)
        {
            if (!actors.ContainsKey(actorId)) return;
            actors[actorId].Name = name;
            Console.WriteLine($"[WorldBoxAPIHelper] Set actor {actorId} name to '{name}'");
        }

        public static void Farm(string actorId)
        {
            if (!actors.ContainsKey(actorId)) return;
            // Simulate farming: increase a resource counter
            Console.WriteLine($"[WorldBoxAPIHelper] Actor {actorId} farms and gains resources.");
        }

        public static void Build(string actorId)
        {
            if (!actors.ContainsKey(actorId)) return;
            // Simulate building: increase a build counter
            Console.WriteLine($"[WorldBoxAPIHelper] Actor {actorId} builds a structure.");
        }

        public static void Fight(string actorId)
        {
            if (!actors.ContainsKey(actorId)) return;
            // Simulate fighting: mark as in combat
            Console.WriteLine($"[WorldBoxAPIHelper] Actor {actorId} enters combat.");
        }

        public static void Respawn(string actorId)
        {
            if (!actors.ContainsKey(actorId)) return;
            // Simulate respawn: reset position
            actors[actorId].X = 0;
            actors[actorId].Y = 0;
            Console.WriteLine($"[WorldBoxAPIHelper] Actor {actorId} respawned at (0,0).");
        }

        public class Actor
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Owner { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            // Add more persistent state as needed (resources, build count, etc.)
        }
    }
}
