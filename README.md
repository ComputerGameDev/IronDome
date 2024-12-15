# Iron Dome Defense Game

## Overview

The **Iron Dome Defense Game** is a missile defense simulation where players control a launcher to intercept incoming enemy missiles. The goal is to shoot down enemy missiles before they reach the launcher.

## Core Mechanics

### Player Actions
- **Aim and Shoot**: The player uses the mouse to target enemy missiles and launches player missiles to intercept them.
- **Missile Interception**: Player missiles destroy enemy missiles upon collision.

### Enemy Behavior
- **Enemy Missiles**: Spawn from random locations (spawners) and move toward the player's launcher.
- **Collision**: Enemy missiles explode when they hit the launcher or are intercepted by a player missile.

## Controls

- **Mouse Click**: Fires a player missile toward the clicked location.

## How to Play

1. Start the game in Unity or build the executable.
2. Enemy missiles will spawn randomly from various locations.
3. Aim and shoot at enemy missiles by clicking with the mouse.
4. Destroy all incoming enemy missiles before they reach the launcher.

### Core Scripts

1. **MissileLauncher.cs**
   - Handles player missile launching.
   - Tracks mouse input for targeting and calculates missile trajectory.

2. **EnemyMissile.cs**
   - Controls enemy missile movement toward the launcher.
   - Detects and handles collisions with player missiles.

3. **EnemyMissileSpawner.cs**
   - Spawns enemy missiles dynamically at random intervals.
   - Ensures no overlapping spawn points.

### Collision Handling

- **Player Missiles**:
  - Tagged as `PlayerMissile`.
  - Destroy enemy missiles on collision.

- **Enemy Missiles**:
  - Tagged as `EnemyMissile`.
  - Explode upon collision with player missiles or when they reach the launcher.

