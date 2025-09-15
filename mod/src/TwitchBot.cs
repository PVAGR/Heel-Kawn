// TwitchBot.cs
// Minimal Twitch IRC bot for real-time chat command processing in Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace HeelKawnMod
{
    public class TwitchBot
    {
        private readonly string server = "irc.chat.twitch.tv";
        private readonly int port = 6667;
        private readonly string channel;
        private readonly string username;
        private readonly string oauthToken;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        public event Action<string, string> OnChatCommand;
        private CancellationTokenSource cts;

        public TwitchBot(string channel, string username, string oauthToken)
        {
            this.channel = channel;
            this.username = username;
            this.oauthToken = oauthToken;
        }

        public void Connect()
        {
            cts = new CancellationTokenSource();
            Task.Run(() => Run(cts.Token));
        }

        public void Disconnect()
        {
            cts?.Cancel();
            client?.Close();
        }

        private async Task Run(CancellationToken token)
        {
            try
            {
                client = new TcpClient();
                await client.ConnectAsync(server, port);
                var stream = client.GetStream();
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { NewLine = "\r\n", AutoFlush = true };

                await writer.WriteLineAsync($"PASS {oauthToken}");
                await writer.WriteLineAsync($"NICK {username}");
                await writer.WriteLineAsync($"JOIN #{channel}");

                Console.WriteLine($"[TwitchBot] Connected to #{channel} as {username}");

                while (!token.IsCancellationRequested)
                {
                    var line = await reader.ReadLineAsync();
                    if (line == null) break;
                    // Respond to PING
                    if (line.StartsWith("PING"))
                    {
                        await writer.WriteLineAsync("PONG :tmi.twitch.tv");
                        continue;
                    }
                    // Parse chat messages
                    var msg = ParseChatMessage(line);
                    if (msg != null && msg.Item2.StartsWith("!"))
                        OnChatCommand?.Invoke(msg.Item1, msg.Item2);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[TwitchBot] Error: {ex.Message}");
            }
        }

        private (string, string) ParseChatMessage(string line)
        {
            // Format: ":username!username@username.tmi.twitch.tv PRIVMSG #channel :message"
            if (line.Contains("PRIVMSG"))
            {
                var split = line.Split('!');
                if (split.Length < 2) return null;
                var username = split[0].TrimStart(':');
                var msgIdx = line.IndexOf(" :");
                if (msgIdx == -1) return null;
                var message = line.Substring(msgIdx + 2);
                return (username, message);
            }
            return null;
        }
    }
}
