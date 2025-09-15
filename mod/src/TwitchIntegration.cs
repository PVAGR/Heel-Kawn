// TwitchIntegration.cs
// Handles Twitch bot integration logic for Heel-Kawn WorldBox Multiplayer Mod

using System;
using System.Threading.Tasks;

namespace HeelKawnMod
{
	public class TwitchIntegration
	{
		public event Action<string, string> OnChatCommand;
		private TwitchBot bot;

		public void Connect(string channel, string username, string oauthToken)
		{
			bot = new TwitchBot(channel, username, oauthToken);
			bot.OnChatCommand += (user, message) => OnChatCommand?.Invoke(user, message);
			bot.Connect();
			Console.WriteLine($"[TwitchIntegration] Connected to Twitch chat for channel #{channel} as {username}.");
		}

		public void Disconnect()
		{
			bot?.Disconnect();
		}
	}
}
