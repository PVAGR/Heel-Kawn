# Heel-Kawn WorldBox Multiplayer Mod - Phase 4: Platform & Marketplace

## Overview

This is the **Phase 4** implementation of the Heel-Kawn Multiplayer Mod for WorldBox, featuring:

- ✅ **Web-based marketplace** for NFTs, achievements, and player history
- ✅ **API for third-party integrations** and community tools  
- ✅ **Scalable infrastructure** for global events and persistent worlds
- ✅ **Blockchain/NFT integration** for unique villagers and achievements
- ✅ **Persistent villages**, professions, and world state
- ✅ **Twitch chat integration** with real-time commands
- ✅ **Player-villager mapping** with persistent data

## Features

### Twitch Commands

| Command | Description |
|---------|-------------|
| `!join` | Join the game and get a unique villager |
| `!move [direction]` | Move your villager (north/south/east/west) |
| `!farm` | Farm resources |
| `!build` | Build structures |
| `!fight` | Enter combat |
| `!respawn` | Respawn your villager |
| `!found [villageName]` | Found a new village |
| `!joinvillage [villageName]` | Join an existing village |
| `!choose [profession]` | Choose a profession (Farmer/Builder/Warrior) |
| `!event [eventName]` | Trigger a world event |
| `!nft` | Mint your villager as an NFT |
| `!help` | Show available commands |

### Admin Commands

| Command | Description |
|---------|-------------|
| `!kick [user]` | Kick a user |
| `!ban [user]` | Ban a user |
| `!reset` | Reset world state |
| `!announce [message]` | Make an announcement |

## Building

### Prerequisites

1. **.NET SDK 8.0** or later
2. **WorldBox** installed with **BepInEx**
3. **Twitch OAuth token** for the bot account

### Setup

1. Set the `WORLDBOX_DIR` environment variable to your WorldBox installation directory:
   ```bash
   export WORLDBOX_DIR="/path/to/WorldBox"
   ```

2. Build the mod:
   ```bash
   cd /workspace/mod
   dotnet build
   ```

3. The compiled DLL will be automatically copied to:
   ```
   $(WORLDBOX_DIR)/BepInEx/plugins/HeelKawnMod.dll
   ```

### Configuration

Edit the config file at:
```
$(WORLDBOX_DIR)/BepInEx/config/heelkawn.cfg
```

Required settings:
```ini
[TwitchBot]
BotUsername = heelkawn
OAuthToken = oauth:your_token_here

[TwitchUser]
Channel = pvagames

[General]
LogLevel = Info
```

## Architecture

### Core Components

- **ModEntry.cs** - Main plugin entry point, command routing
- **PlayerManager.cs** - Player registration, action queues, persistence
- **VillageManager.cs** - Village creation, membership, wars
- **ProfessionManager.cs** - Profession selection and bonuses
- **WorldBoxAPIHelper.cs** - Game world interaction via reflection
- **TwitchIntegration.cs** - Twitch IRC bot connectivity
- **TwitchBot.cs** - Low-level IRC protocol handling
- **BlockchainManager.cs** - NFT minting and metadata storage
- **SeasonalEvents.cs** - Event logging and history
- **Logger.cs** - BepInEx logging integration

### Data Persistence

All player data, villages, professions, and NFTs are persisted to JSON files in:
```
$(WORLDBOX_DIR)/BepInEx/config/
├── heelkawn_players.json
├── heelkawn_villages.json
├── heelkawn_professions.json
├── heelkawn_events.json
└── heelkawn_nfts/
    └── actor_*.json
```

## API Integration (Phase 4)

The mod exposes data through JSON files that can be consumed by:

- **Web marketplace** - Display NFTs, achievements, player stats
- **Third-party tools** - Analytics, leaderboards, community sites
- **Global events** - Coordinate across multiple streams/servers

### Example NFT Structure

```json
{
  "Username": "player123",
  "VillagerId": "actor_1",
  "Metadata": {
    "profession": "Farmer",
    "village": "NewHome",
    "achievements": ["FirstFarm", "VillageFounder"]
  },
  "MintedAt": "2026-04-30T12:00:00Z"
}
```

## Roadmap

### Phase 0 ✅ - Manual Play & Narrative
- Community engagement and lore building

### Phase 1 ✅ - Basic Mod Integration  
- Twitch chat commands trigger in-game actions
- Player-villager mapping and persistent data

### Phase 2 ✅ - Automation & Persistence
- Automated event logging and history tracking
- Blockchain/NFT integration for unique villagers

### Phase 3 ✅ - Full Multiplayer & AI
- Real-time multiplayer support
- Advanced AI for villagers and world events

### Phase 4 🎯 - Platform & Marketplace (Current)
- Web-based marketplace for NFTs and achievements
- API for third-party integrations
- Scalable infrastructure for global events

## Contributing

See `CONTRIBUTING.md` for development guidelines.

## License

MIT License - See `LICENSE.md` for details.

## Support

For issues and feature requests, please open a GitHub issue.
