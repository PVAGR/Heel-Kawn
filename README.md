# Heel-Kawn WorldBox Multiplayer Mod

**A community-driven, narrative multiplayer experience built on WorldBox. Live, breathe, and shape history together.**

## Project Overview
Heel-Kawn is a persistent, lore-rich universe where players, streamers, and viewers interact in real time, influencing the world’s narrative, politics, and technological progress.

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
<<<<<<< HEAD
# Heel-Kawn
Description: A community-driven, narrative multiplayer experience built on WorldBox. Live, breathe, and shape history together.
Excellent. This is the perfect way to think about a project of this scale. Using GitHub is a non-negotiable, critical best practice for modern software development, especially for a complex, collaborative project like Heel-Kawn.

It acts as a single source of truth for you, any human collaborators, and any AI assistants. We can always check the README.md, the issues, and the commit history to see exactly what state the project is in.

Let's get this set up correctly, right from the start.

The GitHub Master Plan for Heel-Kawn
We won't just create a repo; we'll structure it to be a professional-grade project hub that perfectly mirrors your vision.

Step 1: Create the GitHub Repository
Go to github.com and sign in.

Click the "New repository" button.

Name it: Heel-Kawn (or Chronicles-of-Heel-Kawn)

Description: A community-driven, narrative multiplayer experience built on WorldBox. Live, breathe, and shape history together.

Set it to Public (This builds community interest and allows any AI to access it).

Initialize this repository with a README.md (This is the most important file).

Click Create repository.

Step 2: Craft the Perfect README.md (The Project Homepage)
This file will be our project's dashboard and your AI's primary briefing document. I will write the initial content for you. You can create a new file called README.md and paste this in:

markdown
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
Step 3: Structure the Repository
Now, let's create folders and files to keep everything organized. You can do this directly on GitHub by clicking "Add file" -> "Create new file".

Create these folders and files:

text
/Heel-Kawn
│
├── 📁 lore
│   ├── Heel-Kawn-Universe.md          (Paste the content from your file)
│   └── Gameplay-Mechanics.md          (Paste the content from "Heel Kawn info.md")
│
├── 📁 project-management
│   ├── Phase-0-Checklist.md
│   └── Tech-Tree-Roadmap.md
│
├── 📁 mod
│   ├── 📁 src
│   │   └── (We will put the C# code here later)
│   └── 📁 artifacts
│       └── (Compiled DLLs will go here)
│
└── README.md                          (The homepage we just wrote)
Step 4: Create the Phase 0 Checklist
Create a new file in the project-management folder called Phase-0-Checklist.md. This is your immediate to-do list.

markdown
# Phase 0 Checklist - The Narrative Proto-Game

**Objective:** Launch the first live, week-long narrative event manually.

## Pre-Production
- [ ] Create Discord Server: "The Chronicles of Heel-Kawn"
- [ ] Configure Discord Channels:
  - [ ] `#announcements` (Read-only)
  - [ ] `#world-history` (Read-only)
  - [ ] `#suggest-events`
  - [ ] `#lore-talk`
  - [ ] `#kingdom-of-green` (Private)
  - [ ] `#kingdom-of-purple` (Private)
  - [ ] `#choose-your-kingdom` (With role reactions)
- [ ] Set up Discord permissions and roles.
- [ ] Create Google Doc: "The Atlas of Prometheus"
- [ ] Format the Google Doc with headings for the Ages.
- [ ] Finalize the WorldBox "Prometheus" save file.
- [ ] Write and schedule announcement posts for Discord/Twitch/Twitter.

## Live Event Week
- [ ] **Day 1 - Age of Dawn:** Stream. Let chat name first 10 humans. Vote on first disaster. Update Wiki.
- [ ] **Day 2 - Age of Kings:** Stream. Crown first king via `!pray` commands. Name kingdoms. Update Wiki.
- [ ] **Day 3 - Age of Strife:** Stream. `!vote war` or `!vote peace`. Kings RP in Discord VC. Update Wiki.
- [ ] **Days 4-7:** Stream. Narrate the unfolding story driven by chat votes. Update Wiki daily.
How This Solves Your Problem
Now, if you sign off and tell an AI (like me) to "check the status of the Heel-Kawn project," here's what I will do:

Go to the GitHub URL.

Read the README.md: I instantly see the vision, the current phase (Phase 0), and what's done vs. next actions.

Check the project-management folder: I look at Phase-0-Checklist.md and see exactly which Discord channels are left to create.

Look at Commit History: I can see if you've made any recent updates.

Give You a Perfect Status Update: "Based on the GitHub repo, you are in Phase 0. You have completed the design docs but haven't created the Discord server yet. Your next immediate task is to create the server and configure the channels listed in the checklist."

This creates a perfect, unambiguous workflow for you to manage this project over a long period of time, with or without AI assistance.

Your next task is clear and simple: Create the GitHub repository and start populating it with these files. This single action will transform Heel-Kawn from a collection of ideas into a real, trackable project.

I can help you write the content for every single one of these files. Just say the word.# Chronicles of Heel-Kawn

![Heel-Kawn Logo](https://via.placeholder.com/150x150.png?text=HK)  
*(We'll add a real logo later)*

**A live, community-driven, narrative multiplayer mod for WorldBox. Players join via Twitch, become villagers, and collectively write a week-long saga of history, war, and diplomacy.**

---

## 🏰 The Vision

Heel-Kawn is more than a mod; it's a persistent universe where Twitch viewers become citizens of a living world. Through chat commands, they farm, build, wage war, and cast magic, creating a collaborative story that is documented in a living wiki. Every seven-day session is a unique chapter in the history of the world of Prometheus.

**Core Philosophy:** "You are not just playing a game. You are conducting an orchestra of chaos and story."

---

## 🌟 Current Phase: Phase 0 – The Narrative Proto-Game

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
- [ ] `!join` – Spawns a villager, provides unique code.
- [ ] `!move [direction]` – Basic villager movement.
- [ ] `!farm` / `!gather` – Basic resource actions.
- [ ] `!pray [UnitID]` – Automated prayer tracking & trait bestowal.
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
=======
>>>>>>> 14731da (Auto-connect heelkawn bot to pvagames Twitch channel; config and logging improvements)
