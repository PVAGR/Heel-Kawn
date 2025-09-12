// TwitchBotStub.cs
// Minimal stub for Twitch bot connection and chat command handling for Heel-Kawn Multiplayer Mod.
// In Tech Level I, this is a simulation (no real Twitch connection).

using System;
using System.Collections.Generic;

namespace HeelKawnPlugin
{
    public class TwitchBotStub
    {
        private readonly string channel;

        public delegate void ChatCommandHandler(string user, string command, string arg);
        public event ChatCommandHandler OnCommandReceived;

        public TwitchBotStub(string channelName)
        {
            channel = channelName;
        }

        // Simulate a chat message from a user
        public void SimulateChat(string user, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;

            var msg = message.Trim();
            if (!msg.StartsWith("!"))
                return;

            var parts = msg.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);
            var cmd = parts[0].Substring(1).ToLowerInvariant();
            var arg = parts.Length > 1 ? parts[1] : "";

            Logger.Info($"[TwitchBotStub] <{user}>: !{cmd} {arg}");

            OnCommandReceived?.Invoke(user, cmd, arg);
        }

        // For test/dev: simulate chat input loop
        public void StartInputLoop()
        {
            Logger.Info("TwitchBotStub input loop started. Type messages in the format 'username: !command [arg]'");
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                    continue;
                var idx = input.IndexOf(':');
                if (idx <= 0)
                    continue;
                var user = input.Substring(0, idx).Trim();
                var msg = input.Substring(idx + 1).Trim();
                SimulateChat(user, msg);
            }
        }
    }
}
