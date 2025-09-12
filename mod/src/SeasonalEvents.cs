// SeasonalEvents.cs
// Handles chat-triggered world events for Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.Collections.Generic;

namespace HeelKawnMod
{
    public class SeasonalEvents
    {
        private readonly List<string> eventHistory = new();

        public string TriggerEvent(string eventName, string triggeredBy)
        {
            // TODO: Implement actual event logic
            var log = $"Event '{eventName}' triggered by {triggeredBy} at {DateTime.Now}.";
            eventHistory.Add(log);
            Console.WriteLine($"[SeasonalEvents] {log}");
            return log;
        }

        public IEnumerable<string> GetEventHistory()
        {
            return eventHistory;
        }
    }
}
