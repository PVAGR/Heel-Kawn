using BepInEx;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HeelKawnMod
{
    [BepInPlugin("heelkawn.minimal", "Heel-Kawn Minimal Plugin", "0.1.0")]

    public class HeelKawnMinimal : BaseUnityPlugin
    {
        private TwitchBotStub twitchBot;
        private PlayerManager playerManager;
        private VillageManager villageManager;
        private ProfessionManager professionManager;
        private VotingManager votingManager;
        private SeasonalEvents seasonalEvents;

        // Config fields
        private BepInEx.Configuration.ConfigEntry<string> twitchChannel;
        private BepInEx.Configuration.ConfigEntry<string> botUsername;
        private BepInEx.Configuration.ConfigEntry<string> oauthToken;

        private void Awake()
        {
            Logger.LogInfo("Heel-Kawn Minimal Plugin loaded.");
            // Config setup
            twitchChannel = Config.Bind("Twitch", "Channel", "heelkawn", "Twitch channel to connect to.");
            botUsername = Config.Bind("Twitch", "BotUsername", "heelkawn_bot", "Twitch bot username.");
            oauthToken = Config.Bind("Twitch", "OAuthToken", "oauth:yourtokenhere", "Twitch OAuth token.");

            Config.SettingChanged += (sender, args) =>
            {
                Logger.LogInfo($"Config changed: {args.ChangedSetting.Definition}" );
                // Optionally reload bot connection/settings here
            };

            playerManager = new PlayerManager();
            villageManager = new VillageManager();
            professionManager = new ProfessionManager();
            votingManager = new VotingManager();
            seasonalEvents = new SeasonalEvents();
            twitchBot = new TwitchBotStub(Logger, playerManager, villageManager, professionManager, votingManager, seasonalEvents);
            try
            {
                twitchBot.Connect();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Failed to connect TwitchBot: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }

    public class TwitchBotStub
    {
        private readonly BepInEx.Logging.ManualLogSource logger;
        private readonly PlayerManager playerManager;
        private readonly VillageManager villageManager;
        private readonly ProfessionManager professionManager;
        private readonly VotingManager votingManager;
        private readonly SeasonalEvents seasonalEvents;
        private bool connected = false;
        public TwitchBotStub(
            BepInEx.Logging.ManualLogSource logger,
            PlayerManager playerManager,
            VillageManager villageManager,
            ProfessionManager professionManager,
            VotingManager votingManager,
            SeasonalEvents seasonalEvents)
        {
            this.logger = logger;
            this.playerManager = playerManager;
            this.villageManager = villageManager;
            this.professionManager = professionManager;
            this.votingManager = votingManager;
            this.seasonalEvents = seasonalEvents;
        }
        public void Connect()
        {
            // Simulate connecting to Twitch
            Task.Run(() =>
            {
                try
                {
                    Thread.Sleep(1000);
                    connected = true;
                    logger.LogInfo("[TwitchBot] Connected to Twitch chat (stub).");
                    ListenForCommands();
                }
                catch (Exception ex)
                {
                    logger.LogError($"[TwitchBot] Connection error: {ex.Message}\n{ex.StackTrace}");
                }
            });
        }
        private void ListenForCommands()
        {
            // Simulate receiving various chat commands
            Task.Run(() =>
            {
                Thread.Sleep(2000);
                OnMessageReceived("user123", "!join");
                Thread.Sleep(500);
                OnMessageReceived("user123", "!move north");
                Thread.Sleep(500);
                OnMessageReceived("user123", "!found VillageOne");
                Thread.Sleep(500);
                OnMessageReceived("user123", "!choose Farmer");
                Thread.Sleep(500);
                OnMessageReceived("user123", "!event Rainstorm");
                Thread.Sleep(500);
                OnMessageReceived("user123", "!vote start war peace");
                Thread.Sleep(500);
                OnMessageReceived("user123", "!vote cast war");
                Thread.Sleep(500);
                OnMessageReceived("user123", "!vote end");
            });
        }
        private void OnMessageReceived(string username, string message)
        {
            try
            {
                var parts = message.Trim().Split(' ', 2);
                var cmd = parts[0].ToLower();
                var arg = parts.Length > 1 ? parts[1] : "";
                switch (cmd)
                {
                    case "!join":
                        var code = playerManager.RegisterPlayer(username);
                        logger.LogInfo($"[TwitchBot] {username} joined. Code: {code}");
                        break;
                    case "!move":
                        playerManager.QueueAction(username, "move", arg.Split(' '));
                        logger.LogInfo($"[TwitchBot] {username} moves {arg}");
                        break;
                    case "!found":
                        var foundMsg = villageManager.FoundVillage(username, arg);
                        logger.LogInfo($"[TwitchBot] {foundMsg}");
                        break;
                    case "!joinvillage":
                        var joinMsg = villageManager.JoinVillage(username, arg);
                        logger.LogInfo($"[TwitchBot] {joinMsg}");
                        break;
                    case "!choose":
                        var profMsg = professionManager.ChooseProfession(username, arg);
                        logger.LogInfo($"[TwitchBot] {profMsg}");
                        break;
                    case "!event":
                        var eventMsg = seasonalEvents.TriggerEvent(arg, username);
                        logger.LogInfo($"[TwitchBot] {eventMsg}");
                        break;
                    case "!vote":
                        var voteArgs = arg.Split(' ');
                        if (voteArgs.Length > 0)
                        {
                            if (voteArgs[0] == "start" && voteArgs.Length > 2)
                            {
                                var topic = voteArgs[1];
                                var options = new System.Collections.Generic.List<string>(voteArgs[2..]);
                                var startMsg = votingManager.StartVote("main", topic, options);
                                logger.LogInfo($"[TwitchBot] {startMsg}");
                            }
                            else if (voteArgs[0] == "cast" && voteArgs.Length > 1)
                            {
                                var castMsg = votingManager.CastVote("main", username, voteArgs[1]);
                                logger.LogInfo($"[TwitchBot] {castMsg}");
                            }
                            else if (voteArgs[0] == "end")
                            {
                                var endMsg = votingManager.EndVote("main");
                                logger.LogInfo($"[TwitchBot] {endMsg}");
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"[TwitchBot] Command error: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
