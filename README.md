# Heel-Kawn WorldBox Multiplayer Mod
## Project Overview
Heel-Kawn is a community-driven multiplayer mod for WorldBox, designed to create a living, evolving world shaped by player actions, streaming events, and collaborative storytelling. 

### Vision
To build a persistent, lore-rich universe where players, streamers, and viewers interact in real time, influencing the world’s narrative, politics, and technological progress.

### Current Phase: Phase 0 – Narrative Proto-Game
We are in the pre-production phase, focusing on worldbuilding, community setup, and prototyping core mechanics.

## Core Gameplay & Community
- **Player-driven world:** Villagers, professions, and factions shaped by real people.
- **Streaming integration:** Twitch chat and Discord events drive in-game actions.
- **Persistent lore:** Every event, war, and discovery is recorded in the Heel-Kawn universe.

## Project Structure
- [`/lore`](./lore): World lore, history, and gameplay mechanics
- [`/mod`](./mod): Mod source code and build artifacts
- [`/project-management`](./project-management): Roadmaps, checklists, and planning docs

## How to Contribute
1. Join the Discord and introduce yourself.
2. Read the lore and mechanics docs in `/lore`.
3. Check `/project-management/Phase-0-Checklist.md` for open tasks.
4. Submit ideas, code, or art via pull requests or Discord.

---
*Let’s build the Heel-Kawn world together!*
# Heel-Kawn
Description: A community-driven, narrative multiplayer experience built on WorldBox. Live, breathe, and shape history together.
# Chronicles of Heel-Kawn

![Heel-Kawn Logo](https://via.placeholder.com/150x150.png?text=HK) *(We'll add a real logo later)*

**A live, community-driven, narrative multiplayer mod for WorldBox. Players join via Twitch, become villagers, and collectively write a week-long saga of history, war, and diplomacy.**

---

## 🏰 The Vision

Heel-Kawn is more than a mod; it's a persistent universe where Twitch viewers become citizens of a living world. Through chat commands, they farm, build, wage war, and cast magic, creating a collaborative story that is documented in a living wiki. Every seven-day session is a unique chapter in the history of the world of Prometheus.

**Core Philosophy:** "You are not just playing a game. You are conducting an orchestra of chaos and story."

---

## 🌟 Current Phase: Phase 0 - The Narrative Proto-Game

**Objective:** To validate the core premise with minimal technology. Will people become invested in a shared, fictional history they help create?
**Status:** **IN PROGRESS** ✅

### ✅ Completed Tasks (Phase 0)
- [x] Core concept documentation finalized.
- [x] Discord server structure designed.
- [x] WorldBox map "Prometheus" created with two continents.
- [x] Google Doc "Atlas of Prometheus" wiki structure defined.

### 🚀 Immediate Next Actions (Phase 0)
- [ ] Create the Discord server and configure channels.
- [ ] Officially announce the start date for the first 7-day saga.
- [ ] Schedule daily Twitch streams.
- [ ] Conduct the first live stream (Day 1: Age of Dawn).

---

## 🗺️ Project Roadmap (Tech Tree)

### Tech Level 0 (Current)
- **Status:** Manual
- **Tools:** Twitch Polls, Nightbot, Google Sheets, Google Docs.
- **Goal:** Prove narrative engagement.

### Tech Level I (Next)
- **Goal:** Basic Automation
- **Features:** Custom Twitch/Discord bot for `!join`, `!pray`, `!vote`. Auto-role assignment.

### Tech Level II
- **Goal:** Enhanced Stream Experience
- **Features:** Live stream overlay showing kings, prayer counts, and event history.

### Tech Level III (Final Vision)
- **Goal:** Full WorldBox Integration
- **Features:** Custom mod allowing channel points to spawn units, grant traits, and trigger events directly.

---

## 🛠️ Mod Development (`/mod` directory)

This directory contains the source code for the Heel-Kawn multiplayer mod.
**Status:** **PLANNING** ⏳

### Features (Planned for Tech Level I Mod)
- [ ] `!join` - Spawns a villager, provides unique code.
- [ ] `!move [direction]` - Basic villager movement.
- [ ] `!farm` / `!gather` - Basic resource actions.
- [ ] `!pray [UnitID]` - Automated prayer tracking & trait bestowal.
- [ ] Twitch IRC integration.

### Getting Started (For Developers)
1.  Ensure WorldBox is installed.
2.  Install [BepInEx 5.x](https://github.com/BepInEx/BepInEx/releases) for Unity.
3.  Clone this repo.
4.  Open `Heel-Kawn/mod/` in your IDE (Visual Studio, Rider).
5.  Build the project and place the DLL in your `BepInEx/plugins` folder.

---

## 📚 Lore & Documentation (`/lore` directory)

- `Heel-Kawn-Universe.md`: The core lore bible. (COMPLETED ✅)
- `Gameplay-Mechanics.md`: Detailed breakdown of Krond, Traits, Magic, and War systems. (COMPLETED ✅)
- `Prometheus-Map-Notes.md`: Geography and history of the first world.

---

## 🤝 How to Contribute

We are building this in the open! Contributions are welcome.
1.  Fork this repository.
2.  Create a feature branch (`git checkout -b feature/AmazingFeature`).
3.  Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4.  Push to the branch (`git push origin feature/AmazingFeature`).
5.  Open a Pull Request.

---

## 📫 Connect

- **Discord:** *(Link to be added after server creation)*
- **Twitch:** *(Your Twitch channel link)*
- **Project Lead:** [Your Name/GitHub Username]

---

*"The Age of Dawn awaits."*