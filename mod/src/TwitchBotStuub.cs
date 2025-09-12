// TwitchBotStub.cs
// Simulates a Twitch bot for local testing by reading commands from the console.
// We need this so that multiplayer logic can be tested without connecting to real Twitch chat.

using System;
using System.Threading;

namespace HeelKawnPlugin
{
    public class TwitchBotStub
    {
        public delegate void CommandReceivedHandler(string username, string commandText);
        public event CommandReceivedHandler OnCommandReceived;

        private readonly string _channel;
        private bool _running = true;

        public TwitchBotStub(string channel)
        {
            _channel = channel;
        }

        public void StartInputLoop()
        {
            Logger.Info($"[TwitchBotStub] Enter commands as '<username> <command>' (e.g., alice !move north)...");
            while (_running)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    continue;
                if (input.ToLower() == "exit")
                {
                    _running = false;
                    break;
                }
                int split = input.IndexOf(' ');
                if (split <= 0) continue;
                string username = input.Substring(0, split);
                string command = input.Substring(split + 1);
                OnCommandReceived?.Invoke(username, command);
            }
        }
    }
}
