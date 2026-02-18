# Building Mechanic — Tactile Assembly

## Design Goal

Feel like a physical toy — satisfying snaps, tangible weight, visible consequences.
Not spreadsheet engineering. Not rocket science homework.
A child should be able to build something that flies. An adult should want to optimise it.

## Core Concepts

### The Base Cockpit
- Every vehicle starts with the **Base Cockpit** — provided by Stella's first blueprint
- The Cockpit has **Attachment Nodes**: Front, Rear, Top, Bottom, Left, Right
- Parts snap to nodes with a satisfying "clunk" sound + haptic (controller)

### Part Categories (unlocked progressively)

| Category      | Examples                              | Unlocked At     |
|---------------|---------------------------------------|-----------------|
| Propulsion    | Piston engine, Ion drive, Cryo thruster | Per chapter   |
| Fuel          | Small tank, Large tank, Drop tank     | Chapter 1       |
| Lift          | Fixed wing, Delta wing, No wing (space) | Chapter 1     |
| Structure     | Hull plates, Vacuum seal, Rad shield  | Moon+           |
| Landing       | Wheels, Landing legs, Parachute       | Chapter 1       |
| Utility       | RCS thruster, Heat shield, Tether     | Moon+           |

### Mass / Thrust / Fuel Budget
- Displayed as a simple **visual meter**, not raw numbers
- Three bars: `Thrust`, `Fuel Range`, `Structural Integrity`
- Goes red when critically unbalanced — with a hint about what to fix
- Exact numbers available in a toggleable "Engineer Mode" for adult players

## Validation Before Launch

Before Phase B (Launch), the game runs a soft validation:
- ⚠️ Warning: "Your fuel range may not reach orbit" (can override)
- ⛔ Block: "No engine attached" (hard block — must fix)
- ✅ "Looks good — Buffa is buckled in"

## Stella's Blueprints

Each blueprint found in a cache unlocks:
1. A new **part category** (e.g., vacuum hull plating)
2. A new **Base Cockpit variant** (e.g., pressurized capsule for Mars)
3. A short Stella voice note explaining *why* she invented this part
