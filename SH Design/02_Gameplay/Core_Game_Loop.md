# Core Gameplay Loop

Five phases per planet chapter. Each has a distinct mood and mechanic set.

[Workshop] → [Launch] → [Journey Map] → [Landing] → [Exploration]  
↑ |  
└──────────── Parts + Next Blueprint ─────────────────┘

---

## Phase A — The Workshop 🔧
*"Willy Werkel Mode" — Cozy, tactile, satisfying*

1. Read `PlanetData` for the next destination (gravity, atmosphere, terrain)
2. Scavenge parts from the local environment (feeds back from Phase E)
3. **Tactile Building:** Bolt parts onto the Base Cockpit in 3D space
4. Validate build: Mass vs. Thrust vs. Fuel budget (visual indicator, not hard math)
5. Optional: Test sub-systems on local test pad

**No fail state here.** Tinker freely.
Each new Stella blueprint unlocks new part categories.

> Details → [[Building_Mechanic]]

---

## Phase B — The Launch 🚀
*"The Tension" — Focused, brief, earned*

- Not manual flight — **system management**
- Throttle control (thermal gauge — don't overheat)
- Staging timing (drop boosters at correct altitude)
- **Fail State:** Abort → parachute → safe reset to garage. Never punishing.

Duration: ~1–3 minutes per launch.

> Details → [[Launch_And_Landing]]

---

## Phase C — The Journey 🌌
*"The Awe" — Wonder, scale, storytelling*

- Stylized solar system map / time-skip animation (replaces loading screen)
- Visualize trajectory (Hohmann Transfer orbit as a drawn arc)
- Show real distance and travel time — conveyed, not waited through
- Play a Stella log fragment as audio during this screen

**Purpose:** Make the universe feel real and vast without a boring wait.

---

## Phase D — The Landing 🪂
*"7 Minutes of Terror" — Tense, cinematic, planet-unique*

- Heat shield alignment (angle of attack)
- Parachute deployment (atmosphere-dependent — unavailable on Moon, Asteroids)
- Retro-rocket firing (suicide burn timing)
- All parameters driven by `PlanetData` → each planet feels mechanically distinct

> Details → [[Launch_And_Landing]]

---

## Phase E — Exploration 🚶
*"The Discovery" — Quiet, curious, emotional payoff*

- Walk or drive on the planetary surface
- Find Stella's cache: workshop, habitat, beacon, or rover
- Collect her log entry → unlocks next Flight Log chapter
- Scavenge parts → feeds back into Phase A
- Environmental storytelling: her footprints, tools, handwriting, personal items
