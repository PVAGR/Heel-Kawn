# Heel-Kawn WorldBox Multiplayer Mod

## Overview
This is the source code for the Heel-Kawn multiplayer mod for WorldBox. The mod enables Twitch chat integration, allowing viewers to become villagers, join villages, choose professions, and participate in a shared narrative experience.

## Requirements
- **WorldBox** (PC version) installed
- **.NET SDK 6.0+** or **.NET Framework 4.7.2+**
- **BepInEx 5.x** installed for WorldBox
- **Visual Studio**, **VS Code**, or **JetBrains Rider** (recommended)

## Project Structure
```
mod/
├── src/                    # C# source files
│   ├── ModEntry.cs         # Main BepInEx plugin entry point
│   ├── TwitchBot.cs        # Twitch IRC client
│   ├── TwitchIntegration.cs# Twitch event handling
│   ├── PlayerManager.cs    # Player registration & actions
│   ├── VillageManager.cs   # Village founding & management
│   ├── ProfessionManager.cs# Profession selection system
│   ├── SeasonalEvents.cs   # Event logging system
│   ├── BlockchainManager.cs# NFT/villager metadata (optional)
│   ├── WorldBoxAPIHelper.cs# WorldBox interaction helpers
│   └── ConfigManager.cs    # Configuration loading
├── config/
│   └── heelkawn.cfg        # Mod configuration template
└── HeelKawnMod.csproj      # .NET project file
```

## Building the Mod

### Option 1: Using .NET CLI
1. Install [.NET SDK](https://dotnet.microsoft.com/download)
2. Set the `WORLDBOX_DIR` environment variable to your WorldBox installation path:
   - **Windows:** `setx WORLDBOX_DIR "C:\Program Files (x86)\Steam\steamapps\common\WorldBox"`
   - **Linux:** `export WORLDBOX_DIR="$HOME/.steam/steam/steamapps/common/WorldBox"`
   - **macOS:** `export WORLDBOX_DIR="$HOME/Library/Application Support/Steam/steamapps/common/WorldBox"`
3. Build the project:
   ```bash
   cd mod
   dotnet build
   ```
4. The compiled DLL will be in `bin/Debug/netstandard2.1/HeelKawnMod.dll`
5. Copy the DLL to your BepInEx plugins folder:
   ```bash
   cp bin/Debug/netstandard2.1/HeelKawnMod.dll "$WORLDBOX_DIR/BepInEx/plugins/"
   ```

### Option 2: Using Visual Studio / Rider
1. Open `HeelKawnMod.csproj` in your IDE
2. Set the `WORLDBOX_DIR` environment variable as above
3. Build the solution (Ctrl+Shift+B or Cmd+Shift+B)
4. The DLL will be automatically copied to your BepInEx plugins folder (if post-build event is configured)

## Configuration
Edit `config/heelkawn.cfg` with your Twitch credentials:

```ini
[TwitchBot]
Channel = your_bot_username
BotUsername = your_bot_username
OAuthToken = oauth:your_oauth_token

[TwitchUser]
Channel = your_stream_channel

[General]
LogLevel = Info
```

**Important:** Never commit real OAuth tokens to version control!

## Getting a Twitch OAuth Token
1. Go to [twitchapps.com/tmi](https://twitchapps.com/tmi/)
2. Connect with your bot account
3. Copy the OAuth token (includes `oauth:` prefix)

## Available Commands (Tech Level I)
| Command | Description |
|---------|-------------|
| `!join` | Register as a player and spawn a villager |
| `!move [direction]` | Move your villager (north/south/east/west) |
| `!farm` | Gather resources from farming |
| `!build` | Construct a building |
| `!fight` | Engage in combat |
| `!respawn` | Respawn your villager after death |
| `!found [villageName]` | Found a new village |
| `!joinvillage [villageName]` | Join an existing village |
| `!choose [profession]` | Select a profession (Farmer, Builder, Warrior) |
| `!event [eventName]` | Trigger a world event |

## Development Workflow
1. Make changes to source files in `src/`
2. Rebuild the project
3. Restart WorldBox (or use BepInEx reload if available)
4. Test commands via Twitch chat or simulate input

## Troubleshooting
- **Mod not loading:** Check BepInEx logs at `BepInEx/LogOutput.log`
- **Twitch connection fails:** Verify OAuth token and bot username
- **Commands not working:** Ensure bot is connected to the correct channel

## Contributing
See the main project README for contribution guidelines.

## License
See the root LICENSE.md file.
