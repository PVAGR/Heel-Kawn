// WorldBoxAPIHelper.cs
// Provides helper methods for interacting with WorldBox via reflection.
// Spawns actors, moves them, and sets names for integration with Heel-Kawn mod.

using System;
using System.Reflection;

namespace HeelKawnMod
{
    public static class WorldBoxAPIHelper
    {
        private static Assembly worldBoxAssembly;
        private static Type actorType;
        private static Type worldType;
        private static object worldInstance;

        static WorldBoxAPIHelper()
        {
            // Attempt to load WorldBox types via reflection
            worldBoxAssembly = AppDomain.CurrentDomain.GetAssemblies()[0]; // TODO: Find correct assembly
            actorType = worldBoxAssembly.GetType("Actor");
            worldType = worldBoxAssembly.GetType("World");
            worldInstance = null;
        }

        public static object SpawnActor(float x, float y, string name)
        {
            // TODO: Use reflection to spawn an actor at (x, y) and set its name
            if (actorType == null || worldType == null)
                throw new Exception("WorldBox types not found. Reflection failed.");
            // Example stub logic:
            // var actor = Activator.CreateInstance(actorType);
            // Set position and name via reflection
            // ...
            Console.WriteLine($"[WorldBoxAPIHelper] Spawning actor '{name}' at ({x},{y})");
            return null;
        }

        public static void MoveActor(object actor, float x, float y)
        {
            // TODO: Use reflection to move the actor to (x, y)
            Console.WriteLine($"[WorldBoxAPIHelper] Moving actor to ({x},{y})");
        }

        public static void SetActorName(object actor, string name)
        {
            // TODO: Use reflection to set the actor's name
            Console.WriteLine($"[WorldBoxAPIHelper] Setting actor name to '{name}'");
        }
    }
}
