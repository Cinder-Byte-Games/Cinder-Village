# Unity Learning Pathway + Project Milestones

A structured plan that pairs *theory you study* with *game features you build* in your 2D learning project.

---

## PHASE 0 — Foundations → Milestone 1: Player Movement
COMPLETE 12/17/2025

### Theory
- **Unity runtime model** (Update, FixedUpdate, LateUpdate)  
  - Core to predicting runtime behavior.
- **GameObject / Component architecture**  
  - Prevents “God scripts” and teaches composition.
- **Transforms**  
  - Positioning, parenting, movement.
- **Prefab basics**  
  - Reusable, versionable building blocks.
- **Git + meta files + text serialization**  
  - Critical for avoiding merge conflicts and corrupted scenes.

### Milestone 1 Output
- 2D player movement  
- Basic collisions  
- Animator (idle/walk)  
- Cinemachine camera follow  

---

## PHASE 1 — Architecture Basics → Milestone 2: Interactions + Items
IN PROGRESS...

### Theory
- **Prefab architecture** (nested, variants)  
- **Scene organization**  
- **ScriptableObjects as data**  
- **Events (C#, UnityEvents, Event Channels)**  

### Milestone 2 Output
- Interactable base class  
- Item pickup logic  
- Item database (ScriptableObjects)  
- Pickup notification via event channel  

---

## PHASE 2 — 2D World Systems → Milestone 3: Tilemap World

### Theory
- **Tilemap creation & workflow**  
- **Collisions** (composite colliders)  
- **Sorting layers / render order**  
- **Physics2D types** (Static / Kinematic / Dynamic)

### Milestone 3 Output
- Basic tilemap village  
- World obstacles + collision  
- Player navigates world cleanly  

---

## PHASE 3 — Inventory & UI → Milestone 4: Inventory System

### Theory
- **ScriptableObject item definitions**  
- **Inventory data modeling**  
- **Unity UI foundations**  
- **Event-driven UI**  

### Milestone 4 Output
- Inventory panel UI  
- Item slots with icons  
- Pickup → Inventory  
- Dynamic UI refresh  

---

## PHASE 4 — Crafting & Structures → Milestone 5: Crafting + Buildables

### Theory
- **Multi-step system design**  
- **SO-based recipe database**  
- **Basic state machines**  
- **Prefab placement mechanics**  

### Milestone 5 Output
- Crafting UI  
- Recipe system  
- Place structures (campfire, chest, workbench)  

---

## PHASE 5 — NPC Interaction → Milestone 6: Dialogue + Quest

### Theory
- **Trigger zones & proximity checks**  
- **Dialogue UI**  
- **Quest/state tracking**  
- **Event-driven interactions**  

### Milestone 6 Output
- NPC prefab  
- Dialogue popup  
- Simple quest (“bring 5 wood”)  
- Reward or state update  

---

## PHASE 6 — Save / Load → Milestone 7: Persistence

### Theory
- **JSON save/load**  
- **Managing ScriptableObject runtime state**  
- **Bootstrap scene**  
- **Persistent world state**  

### Milestone 7 Output
- Save/load player position  
- Save/load inventory  
- Save/load world changes (trees, structures)  

---

## PHASE 7 — Tools & Optimization → Milestone 8: Editor Tools + Pooling

### Theory
- **Custom inspectors**  
- **Editor windows**  
- **Unity Profiler**  
- **Object pooling**  

### Milestone 8 Output
- Item database custom inspector  
- Developer debug overlay  
- Object pooling for pickups  

---

## PHASE 8 — Advanced (Optional)

### Theory
- Addressables  
- Shader Graph  
- Multi-scene streaming  
- Procedural generation  
- Basic AI  
- Animation/rigging improvements

### Milestone Output (Optional)
- Weather  
- Day/night cycle  
- Procedural map  
- Enemy AI  
- Fog of war  

---

## SUMMARY MAP

```
PHASE 0 — Foundations
  → Milestone 1: Player controller

PHASE 1 — Architecture
  → Milestone 2: Items + interactions

PHASE 2 — 2D Systems
  → Milestone 3: Tilemap world

PHASE 3 — Inventory & UI
  → Milestone 4: Inventory system

PHASE 4 — Crafting & Buildables
  → Milestone 5: Crafting + placement

PHASE 5 — NPC Interaction
  → Milestone 6: Dialogue + quest

PHASE 6 — Save / Load
  → Milestone 7: Persistence

PHASE 7 — Tools/Optimization
  → Milestone 8: Editor tools + pooling

PHASE 8 — Advanced
  → Optional expansions
```
