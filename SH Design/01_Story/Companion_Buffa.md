# Buffa — The Companion

## What Is Buffa?

A small, silent **robot pet** left behind by Stella in the garage.
Buffa has no dialogue, no subtitles, no HUD label. Just behaviour and reaction.

Stella built Buffa as a stress-test instrument for her early vehicles — 
measuring vibration, G-forces, and atmospheric pressure.
She left it behind because she knew whoever followed would need company.

## Role in Gameplay

Buffa is the player's **emotional cue system**:

| Situation              | Buffa's Reaction                              |
|------------------------|-----------------------------------------------|
| High G-force (launch)  | Grabs onto nearest surface, eyes wide         |
| Zero gravity           | Floats, spins slowly, clearly delighted       |
| Planetary landing      | Peers out the window, twitches antenna        |
| Finding Stella's cache | Recognises her scent/signal, visibly excited  |
| Dangerous situation    | Hides behind player, peeks out               |
| Beautiful vista        | Sits next to player, stares at the horizon   |

## Design Rules

- **Never speaks or uses text**
- **Never dies** — Buffa is indestructible and always safe
- **Always present** — rides in a dedicated seat/cradle in every vehicle
- Buffa's reactions should make players *feel* what the game wants them to feel
  without being told

## Technical Notes

- Buffa is a simple animated character — no complex AI needed
- Reactions are triggered by physics values (G-force float, velocity, altitude)
  and narrative trigger zones (Stella's cache locations)
- Animation states: `Idle`, `Nervous`, `Excited`, `Floating`, `Hiding`, `Watching`
