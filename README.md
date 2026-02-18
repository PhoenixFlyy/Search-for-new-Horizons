# 🚀 Search for Horizon

A solo passion project by a Games Engineering graduate — 
an optimistic, wonder-driven aerospace adventure game about following a disappeared mentor across the Solar System.

---

## 🎮 What is this game?

You play as an ordinary person — no wealth, no connections, just curiosity and a wrench.
Your **Aunt Stella**, a brilliant aerospace engineer, vanished 15 years ago.
She left behind a half-built aircraft, a cryptic flight log, and a trail of clues
stretching from Earth to the outer rim of the Solar System.

You build ships from scrap. You follow her breadcrumbs. Planet by planet,
you uncover what she discovered — and why she never came back.

**Core Pillar:** *"Tactile Engineering"* — the bridge between *Willy Werkel* whimsy
and *Interstellar* realism.

---

## 🛠️ Tech Stack

| Area             | Technology                                   |
|------------------|----------------------------------------------|
| Engine           | Unity 6 LTS                                  |
| Render Pipeline  | HDRP (High Definition Render Pipeline)       |
| IDE              | JetBrains Rider                              |
| Language         | C#                                           |
| Key Packages     | Space Graphics Toolkit (SGT), Shader Graph   |
| Version Control  | Git / GitHub                                 |
| Design Docs      | Obsidian (see `/Design` vault)               |
| Target Platform  | PC (Windows / Mac)                           |

---

## 📁 Project Structure
```markdown
SearchForHorizon/
├── Assets/
│ ├── _Game/
│ │ ├── Scenes/ ← One scene per planet/chapter
│ │ ├── Scripts/
│ │ │ ├── Building/ ← Ship assembly mechanics
│ │ │ ├── Exploration/ ← Surface traversal, interaction
│ │ │ ├── Narrative/ ← Stella's log system, clue triggers
│ │ │ ├── Launch/ ← Takeoff & landing sequences
│ │ │ ├── Vehicle/ ← VehicleController, Thruster, WheelCollider
│ │ │ ├── World/ ← WorldShifter (Floating Origin)
│ │ │ └── UI/
│ │ ├── Art/
│ │ │ ├── Models/
│ │ │ ├── Textures/
│ │ │ └── VFX/
│ │ ├── Audio/
│ │ └── Data/ ← ScriptableObjects (PlanetData, PartData)
│ ├── HDRP/ ← Render pipeline assets & volume profiles
│ └── ThirdParty/ ← SGT, external packages
├── Packages/
├── ProjectSettings/
├── Builds~/ ← Git-ignored
└── Design/ ← Obsidian vault (see below)
```
---

## ⚙️ Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- Unity **6 LTS** with HDRP template
- [JetBrains Rider](https://www.jetbrains.com/rider/)
- Git

### Setup

```bash
git clone https://github.com/YOUR_USERNAME/search-for-horizon.git
```
1. Open Unity Hub → Add → select the cloned project folder
2. Let Unity resolve all packages automatically
3. Run Window → Rendering → HDRP Wizard → click Fix All
4. Go to Edit → Preferences → External Tools → set External Script Editor to Rider
5. Open Assets/_Game/Scenes/01_Earth_Garage.unity and press Play

---

## 🌱 Inspirations
- Willy Werkel baut Flugzeuge / Raumschiffe
- Aviassembly
- Outer Wilds
- Mario Galaxy
- NASA, ESA, SpaceX, BlueOrigin