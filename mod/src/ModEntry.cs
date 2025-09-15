// ModEntry.cs
// Main entry point for Heel-Kawn WorldBox Multiplayer Mod

using BepInEx;
using System;

namespace HeelKawnMod
{
    [BepInPlugin("heelkawn.mod", "Heel-Kawn Multiplayer Mod", "0.2.0")]
    public class ModEntry : BaseUnityPlugin
    {
        private TwitchIntegration twitchIntegration;
        private PlayerManager playerManager;
        private VillageManager villageManager;
        private ProfessionManager professionManager;
        private VotingManager votingManager;
        private SeasonalEvents seasonalEvents;

        private ConfigEntry<string> channelConfig;
        private ConfigEntry<string> botUsernameConfig;
        private ConfigEntry<string> oauthTokenConfig;
        private ConfigEntry<string> logLevelConfig;

        private void Awake()
        {
            Logger.LogInfo("Heel-Kawn Multiplayer Mod loaded.");
            playerManager = new PlayerManager();
            villageManager = new VillageManager();
            professionManager = new ProfessionManager();
            votingManager = new VotingManager();
            seasonalEvents = new SeasonalEvents();
            twitchIntegration = new TwitchIntegration();

            // Use heelkawn bot credentials, but control pvagames channel
            var botUsername = Config.TryGetEntry("TwitchBot", "BotUsername")?.Value ?? "heelkawn";
            var oauthToken = Config.TryGetEntry("TwitchBot", "OAuthToken")?.Value ?? "";
            var channel = Config.TryGetEntry("TwitchUser", "Channel")?.Value ?? "pvagames";
            logLevelConfig = Config.Bind("General", "LogLevel", "Info", "Log verbosity: Trace, Debug, Info, Warn, Error, Fatal");

            SetLogLevel(logLevelConfig.Value);

            Config.SettingChanged += (sender, args) =>
            {
                Logger.LogInfo($"Config changed: {args.ChangedSetting.Definition}" );
                if (args.ChangedSetting.Definition.Key == "LogLevel")
                    SetLogLevel(logLevelConfig.Value);
                if (args.ChangedSetting.Definition.Section == "TwitchBot" || args.ChangedSetting.Definition.Section == "TwitchUser")
                {
                    Logger.LogInfo("Reloading Twitch connection with new config...");
                    try
                    {
                        twitchIntegration.Disconnect();
                        var newBotUsername = Config.TryGetEntry("TwitchBot", "BotUsername")?.Value ?? "heelkawn";
                        var newOauthToken = Config.TryGetEntry("TwitchBot", "OAuthToken")?.Value ?? "";
                        var newChannel = Config.TryGetEntry("TwitchUser", "Channel")?.Value ?? "pvagames";
                        twitchIntegration.Connect(newChannel, newBotUsername, newOauthToken);
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError($"Error reconnecting Twitch: {ex.Message}");
                    }
                }
            };

            try
            {
                twitchIntegration.OnChatCommand += HandleChatCommand;
                twitchIntegration.Connect(channel, botUsername, oauthToken);
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error connecting to Twitch: {ex.Message}");
            }
        }

        private void SetLogLevel(string level)
        {
            // BepInEx Logger is Info by default; advanced log routing would require custom logger
            Logger.LogInfo($"Log level set to: {level}");
        }

        private HashSet<string> bannedUsers = new HashSet<string>();
        private void HandleChatCommand(string username, string message)
        {
            var parts = message.Trim().Split(' ', 2);
            var cmd = parts[0].ToLower();
            var arg = parts.Length > 1 ? parts[1] : "";
            // Admin/moderator commands (simple example: only allow from 'admin' user)
            if (username == "admin")
            {
                switch (cmd)
                {
                    case "!kick":
                        Logger.LogInfo($"[Admin] Kicked user: {arg}");
                        // Implement kick logic (e.g., remove from player list)
                        break;
                    case "!ban":
                        bannedUsers.Add(arg);
                        Logger.LogInfo($"[Admin] Banned user: {arg}");
                        break;
                    case "!reset":
                        Logger.LogInfo("[Admin] Resetting world state...");
                        // Implement reset logic (clear state, reload, etc.)
                        break;
                    case "!announce":
                        Logger.LogInfo($"[Admin Announcement]: {arg}");
                        break;
                }
            }
            if (bannedUsers.Contains(username))
            {
                Logger.LogInfo($"[Twitch] Ignoring command from banned user: {username}");
                return;
            }
            switch (cmd)
            {
                case "!join":
                    var code = playerManager.RegisterPlayer(username);
                    Logger.LogInfo($"[Twitch] {username} joined. Code: {code}");
                    break;
                case "!move":
                    playerManager.QueueAction(username, "move", arg.Split(' '));
                    Logger.LogInfo($"[Twitch] {username} moves {arg}");
                    playerManager.ProcessActions();
                    break;
                case "!farm":
                    playerManager.QueueAction(username, "farm", Array.Empty<string>());
                    Logger.LogInfo($"[Twitch] {username} farms");
                    playerManager.ProcessActions();
                    break;
                case "!build":
                    playerManager.QueueAction(username, "build", Array.Empty<string>());
                    Logger.LogInfo($"[Twitch] {username} builds");
                    playerManager.ProcessActions();
                    break;
                case "!fight":
                    playerManager.QueueAction(username, "fight", Array.Empty<string>());
                    Logger.LogInfo($"[Twitch] {username} fights");
                    playerManager.ProcessActions();
                    break;
                case "!respawn":
                    playerManager.QueueAction(username, "respawn", Array.Empty<string>());
                    Logger.LogInfo($"[Twitch] {username} respawns");
                    playerManager.ProcessActions();
                    break;
                case "!found":
                    var foundMsg = villageManager.FoundVillage(username, arg);
                    Logger.LogInfo($"[Twitch] {foundMsg}");
                    break;
                case "!joinvillage":
                    var joinMsg = villageManager.JoinVillage(username, arg);
                    Logger.LogInfo($"[Twitch] {joinMsg}");
                    break;
                case "!choose":
                    var profMsg = professionManager.ChooseProfession(username, arg);
                    Logger.LogInfo($"[Twitch] {profMsg}");
                    break;
                case "!event":
                    var eventMsg = seasonalEvents.TriggerEvent(arg, username);
                    Logger.LogInfo($"[Twitch] {eventMsg}");
                    break;
                // Add more commands as needed
            }
        }
    }
}
