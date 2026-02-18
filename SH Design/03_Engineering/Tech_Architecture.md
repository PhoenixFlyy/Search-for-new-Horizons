# Technical Architecture

## Tech Stack
*   **Engine:** Unity 6 (HDRP).
*   **Language:** C#.
*   **Key Assets:** Space Graphics Toolkit (SGT), Shader Graph.

## Key Systems

### 1. The "Floating Origin" (Anti-Jitter)
*   **Problem:** Unity floats lose precision > 5km.
*   **Solution:** 
    *   Keep Player at `(0,0,0)`.
    *   When Player moves > `Threshold` (e.g., 2000 units), shift the **World** opposite direction.
    *   `WorldShifter.cs` handles the root object transform.

### 2. Vehicle Architecture
*   **Concept:** Modular composition over inheritance.
*   **Class: `VehicleController`**
    *   `List<Thruster> engines`
    *   `List<WheelCollider> wheels`
    *   `float TotalMass`
*   **Input Handling:**
    *   State Machine: `Garage` -> `Launch` -> `Space` -> `Atmosphere` -> `Ground`.

### 3. Planetary Data
*   **ScriptableObject:** `PlanetData`
    *   `float Gravity` (e.g., 9.81 vs 1.62)
    *   `float AirDensity` (affects Drag/Lift)
    *   `Color AtmosphereColor`
*   **Logic:** The `VehicleController` reads the current `PlanetData` on Scene Load to adjust physics parameters.