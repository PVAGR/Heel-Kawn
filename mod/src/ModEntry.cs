// ModEntry.cs
// Main entry point for Heel-Kawn WorldBox Multiplayer Mod - Phase 4 Platform & Marketplace

using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections.Generic;

namespace HeelKawnMod
{
    [BepInPlugin("heelkawn.mod", "Heel-Kawn Multiplayer Mod", "4.0.0")]
    public class ModEntry : BaseUnityPlugin
    {
        private TwitchIntegration twitchIntegration;
        private PlayerManager playerManager;
        private VillageManager villageManager;
        private ProfessionManager professionManager;
        private SeasonalEvents seasonalEvents;
        private BlockchainManager blockchainManager;
        
        private ManualLogSource modLogger;

        private ConfigEntry<string> channelConfig;
        private ConfigEntry<string> botUsernameConfig;
        private ConfigEntry<string> oauthTokenConfig;
        private ConfigEntry<string> logLevelConfig;

        private void Awake()
        {
            // Initialize logger
            modLogger = Logger;
            HeelKawnMod.Logger.Initialize(modLogger);

            modLogger.LogInfo("Heel-Kawn Multiplayer Mod v4.0.0 (Phase 4: Platform & Marketplace) loaded.");
            
            // Initialize managers
            playerManager = new PlayerManager();
            villageManager = new VillageManager();
            professionManager = new ProfessionManager();
            seasonalEvents = new SeasonalEvents();
            blockchainManager = new BlockchainManager();
            twitchIntegration = new TwitchIntegration();

            // Load configuration
            var botUsername = Config.TryGetEntry("TwitchBot", "BotUsername")?.Value ?? "heelkawn";
            var oauthToken = Config.TryGetEntry("TwitchBot", "OAuthToken")?.Value ?? "";
            var channel = Config.TryGetEntry("TwitchUser", "Channel")?.Value ?? "pvagames";
            logLevelConfig = Config.Bind("General", "LogLevel", "Info", "Log verbosity: Trace, Debug, Info, Warn, Error, Fatal");

            SetLogLevel(logLevelConfig.Value);

            // Handle config changes
            Config.SettingChanged += (sender, args) =>
            {
                modLogger.LogInfo($"Config changed: {args.ChangedSetting.Definition}");
                if (args.ChangedSetting.Definition.Key == "LogLevel")
                    SetLogLevel(logLevelConfig.Value);
                if (args.ChangedSetting.Definition.Section == "TwitchBot" || args.ChangedSetting.Definition.Section == "TwitchUser")
                {
                    modLogger.LogInfo("Reloading Twitch connection with new config...");
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
                        modLogger.LogError($"Error reconnecting Twitch: {ex.Message}");
                    }
                }
            };

            // Connect to Twitch
            try
            {
                twitchIntegration.OnChatCommand += HandleChatCommand;
                twitchIntegration.Connect(channel, botUsername, oauthToken);
            }
            catch (Exception ex)
            {
                modLogger.LogError($"Error connecting to Twitch: {ex.Message}");
            }
        }

        private void SetLogLevel(string level)
        {
            modLogger.LogInfo($"Log level set to: {level}");
        }

        private HashSet<string> bannedUsers = new HashSet<string>();

        private void HandleChatCommand(string username, string message)
        {
            var parts = message.Trim().Split(' ', 2);
            var cmd = parts[0].ToLower();
            var arg = parts.Length > 1 ? parts[1] : "";

            // Admin/moderator commands
            if (username == "admin" || username == Config.TryGetEntry("TwitchUser", "Channel")?.Value)
            {
                switch (cmd)
                {
                    case "!kick":
                        modLogger.LogInfo($"[Admin] Kicked user: {arg}");
                        break;
                    case "!ban":
                        bannedUsers.Add(arg);
                        modLogger.LogInfo($"[Admin] Banned user: {arg}");
                        break;
                    case "!reset":
                        modLogger.LogInfo("[Admin] Resetting world state...");
                        break;
                    case "!announce":
                        modLogger.LogInfo($"[Admin Announcement]: {arg}");
                        break;
                }
            }

            // Ignore banned users
            if (bannedUsers.Contains(username))
            {
                modLogger.LogInfo($"[Twitch] Ignoring command from banned user: {username}");
                return;
            }

            // Process player commands
            switch (cmd)
            {
                case "!join":
                    var code = playerManager.RegisterPlayer(username);
                    modLogger.LogInfo($"[Twitch] {username} joined. Code: {code}");
                    break;
                case "!move":
                    playerManager.QueueAction(username, "move", arg.Split(' '));
                    modLogger.LogInfo($"[Twitch] {username} moves {arg}");
                    playerManager.ProcessActions();
                    break;
                case "!farm":
                    playerManager.QueueAction(username, "farm", Array.Empty<string>());
                    modLogger.LogInfo($"[Twitch] {username} farms");
                    playerManager.ProcessActions();
                    break;
                case "!build":
                    playerManager.QueueAction(username, "build", Array.Empty<string>());
                    modLogger.LogInfo($"[Twitch] {username} builds");
                    playerManager.ProcessActions();
                    break;
                case "!fight":
                    playerManager.QueueAction(username, "fight", Array.Empty<string>());
                    modLogger.LogInfo($"[Twitch] {username} fights");
                    playerManager.ProcessActions();
                    break;
                case "!respawn":
                    playerManager.QueueAction(username, "respawn", Array.Empty<string>());
                    modLogger.LogInfo($"[Twitch] {username} respawns");
                    playerManager.ProcessActions();
                    break;
                case "!found":
                    var foundMsg = villageManager.FoundVillage(username, arg);
                    modLogger.LogInfo($"[Twitch] {foundMsg}");
                    break;
                case "!joinvillage":
                    var joinMsg = villageManager.JoinVillage(username, arg);
                    modLogger.LogInfo($"[Twitch] {joinMsg}");
                    break;
                case "!choose":
                    var profMsg = professionManager.ChooseProfession(username, arg);
                    modLogger.LogInfo($"[Twitch] {profMsg}");
                    break;
                case "!event":
                    var eventMsg = seasonalEvents.TriggerEvent(arg, username);
                    modLogger.LogInfo($"[Twitch] {eventMsg}");
                    break;
                case "!nft":
                    var nftFile = blockchainManager.MintVillagerNFT(username, playerManager.GetVillagerId(username), new { });
                    modLogger.LogInfo($"[Twitch] {username} minted NFT: {nftFile}");
                    break;
                case "!help":
                    modLogger.LogInfo($"[Twitch] {username} requested help. Available: !join, !move, !farm, !build, !fight, !respawn, !found, !joinvillage, !choose, !event, !nft");
                    break;
            }
        }

        private void Update()
        {
            // Process queued actions each frame
            playerManager?.ProcessActions();
        }
    }
}
