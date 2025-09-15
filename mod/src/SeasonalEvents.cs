// SeasonalEvents.cs
// Handles chat-triggered world events for Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace HeelKawnMod
{
    public class SeasonalEvents
    {
        private readonly List<string> eventHistory = new();
        private readonly string savePath = Path.Combine(BepInEx.Paths.ConfigPath, "heelkawn_events.json");

        public SeasonalEvents()
        {
            LoadEvents();
        }

        public string TriggerEvent(string eventName, string triggeredBy)
        {
            var log = $"Event '{eventName}' triggered by {triggeredBy} at {DateTime.Now}.";
            eventHistory.Add(log);
            SaveEvents();
            Console.WriteLine($"[SeasonalEvents] {log}");
            return log;
        }

        public IEnumerable<string> GetEventHistory()
        {
            return eventHistory;
        }

        private void SaveEvents()
        {
            File.WriteAllText(savePath, JsonSerializer.Serialize(eventHistory));
        }

        private void LoadEvents()
        {
            if (File.Exists(savePath))
            {
                var json = File.ReadAllText(savePath);
                var loaded = JsonSerializer.Deserialize<List<string>>(json);
                if (loaded != null)
                    eventHistory.AddRange(loaded);
            }
        }
    }
}
