# Technical Architecture

## Tech Stack

| Area              | Choice                     | Notes                                           |
|-------------------|----------------------------|-------------------------------------------------|
| Engine            | Unity 6 LTS                | Stable for multi-year solo project              |
| Render Pipeline   | HDRP                       | Volumetric lighting, physical sky, lens flares  |
| Language          | C#                         | Rider + Unity integration                       |
| Key Package       | Space Graphics Toolkit (SGT) | Planetary rendering, rings, atmospheres       |
| Shader Authoring  | Shader Graph               | HDRP-compatible visual shaders                  |
| IDE               | JetBrains Rider            | Built-in Unity profiler, Unity support plugin   |

---

## System 1 — Floating Origin (Anti-Jitter)

**Problem:** Unity float precision degrades beyond ~5 km from world origin,
causing visible mesh and physics jitter.

**Solution:** Keep the Player at `(0,0,0)` permanently.
When Player moves beyond threshold (~2,000 units), shift **all world objects** instead.

```csharp
// WorldShifter.cs — core logic
void Update() {
    if (Vector3.Distance(player.position, Vector3.zero) > shiftThreshold) {
        Vector3 offset = player.position;
        foreach (var obj in worldObjects)
            obj.transform.position -= offset;
        player.position = Vector3.zero;
    }
}
````

⚠️ **Implement this first**, before building any large scenes. Retrofitting is painful.
## System 2 — Vehicle Architecture

**Design principle:** Modular composition over inheritance.
```cs
public class VehicleController : MonoBehaviour {
    public List<Thruster> engines;
    public List<WheelCollider> wheels;
    public float TotalMass;
    public PlanetData CurrentPlanet;

    public enum VehicleState { Garage, Launch, Space, Atmosphere, Ground }
    public VehicleState State;
}

```