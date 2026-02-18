# Launch & Landing Mechanics

> Space flights between planets are **not simulated**.
> Only the **takeoff** and **landing sequences** are interactive.
> Transit = stylized Journey Map screen (Phase C).

---

## Launch Sequence (Phase B)

### What the Player Controls
- **Throttle:** Slider or hold-button — manage heat gauge
- **Staging:** Button prompt at correct altitude markers (e.g., "Drop boosters now")
- **Abort:** Always available — triggers parachute/safe reset, no progress loss

### What the Game Simulates (Automatically)
- Trajectory based on current planet's gravity + atmosphere
- Fuel consumption based on `VehicleController.TotalMass` + engine thrust
- Thermal buildup based on `PlanetData.AirDensity`

### Failure States (All Non-Punishing)
| Failure              | Result                          |
|----------------------|---------------------------------|
| Engine overheat      | Shutdown → abort parachute      |
| Fuel exhaustion      | Glide/fall → abort parachute    |
| Structural failure   | Dramatic breakup → cut to Buffa safe in escape pod |
| Manual abort         | Parachute → safe landing        |

**On any failure:** Return to garage with a short Buffa reaction. No progress lost.

---

## Landing Sequence (Phase D)

### Atmosphere-Dependent Mechanics

| Planet         | Heat Shield | Parachute | Retro-rockets | Notes                    |
|----------------|-------------|-----------|---------------|--------------------------|
| Earth          | Optional    | ✅        | Optional      | Easiest                  |
| Moon           | ❌          | ❌        | ✅ Required   | Suicide burn only        |
| Mars           | ✅          | ⚠️ Partial | ✅ Required  | Thin air = partial chute |
| Asteroid Belt  | ❌          | ❌        | ✅ Required   | Micro-gravity — gentle   |
| Europa         | Optional    | ❌        | ✅ Required   | Ice surface — legs needed|
| Saturn Rings   | N/A         | N/A       | N/A           | No surface landing       |

### Player Actions (Landing)
1. **Entry angle:** Aim reticle into correct entry corridor (too steep = overheat, too shallow = skip off)
2. **Chute deployment:** Button prompt at correct altitude (atmosphere permitting)
3. **Suicide burn:** Throttle up at correct altitude marker to zero vertical velocity
4. **Touchdown:** Land within the target zone — Buffa celebrates

### Feel Goal
Each landing should feel **earned and unique per planet**.
Moon = silent, tense, precise. Mars = dusty, dramatic, relief.
Europa = crystalline, alien, beautiful.
