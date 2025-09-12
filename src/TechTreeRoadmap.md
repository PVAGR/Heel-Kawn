# Heel-Kawn Multiplayer Mod – Tech Tree Roadmap

A staged plan for feature development. Each "Tech Level" can be considered a playable milestone.

---

## Tech Level I: Foundations
- [x] BepInEx plugin loads
- [x] Logging to BepInEx console
- [x] TwitchBot stub (simulate chat, no real IRC)
- [x] PlayerManager: player registry, action queue
- [x] VillageManager: basic village/kingdom tracking
- [x] WorldBoxAPIHelper: stubs for spawn/move/logging
- [x] ConfigManager loads Twitch credentials
- [x] Basic docs, roadmap, and contribution guide

---

## Tech Level II: Real Multiplayer & Actions
- [ ] TwitchBot connects to real Twitch IRC (TwitchLib or raw TCP)
- [ ] Parse chat in real time
- [ ] Join/move/pray/queue actions live from chat
- [ ] ActionQueueProcessor: process queued actions (move, farm, pray)
- [ ] WorldBoxAPIHelper: move villagers in-game via reflection
- [ ] Player persistence (save/load, reconnect)
- [ ] Basic cooldowns, anti-spam

---

## Tech Level III: Villager Life
- [ ] Spawn villagers as real WorldBox units
- [ ] Respawn on death, assign traits
- [ ] Inventory system stub (food, items)
- [ ] Player stats: health, hunger, happiness
- [ ] Village/kingdom assignment affects gameplay
- [ ] Prayers/gods system: limited influence per player

---

## Tech Level IV: Diplomacy, Economy, & Lore
- [ ] Villages: farming, buildings, upgrades
- [ ] Kingdoms: diplomacy, wars, alliances
- [ ] Shared events, lore log, Twitch highlights
- [ ] Voting/events driven by chat
- [ ] Living wiki integration

---

## Tech Level V: Specialization & God Powers
- [ ] Villager roles: farmer, builder, warrior, priest
- [ ] God powers: smite, bless, miracles (via chat, cooldown-limited)
- [ ] Rare events, legendary heroes
- [ ] Custom mod UI (in-game overlays)

---

## Stretch Goals
- [ ] Discord integration
- [ ] Web dashboard for stats/logs
- [ ] Achievements, unlockables
- [ ] Cross-mod compatibility

---

**See you at the next Tech Level!**
