# DesignPatternAssignment
Alice Tarkanmäki Bohman

This is just a very simple top down shooter with a player and a few enemies that randomly wanders around within a specific radius.

Patterns used:
A singleton is used in the Manager script as a Manager.instance
A state machine is used in the Enemy script to decide how the enemies should behave and react if the player gets within range
Pooling is used in the BulletPool script and also in the Projectile script to send it back into the pool after hitting or reaching a time limit
