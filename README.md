# Exam Practical - Duck Hunt

For this exam, I have recreated Duck Hunt in Unity 3D. My game doesn't quite match with the original, here is the rundown of the game loop:
- Targets spawn from the upper right and left corners randomly
- Every 5th target is a decoy, which reverses the player's movement controls until the player shoots another decoy
- If the player shoots and misses, they lose a life
- If the player lets a non-decoy target reach the bottom of the screen, they lose a life
- Each target shot increases the player's score by 100
- The goal is to shoot as many targets as possible without losing

Controls:
- WASD: Movement
- Space: Shoot


Command Pattern:
The command pattern was used to create commands for each movement input. If the player hasn't shot a decoy, these commands execute as normal. If the player has shot a decoy, the commands are executed in the opposite direction. Functionality can be added for undo/redo features, but this was unnecessary for this project.

Diagram:

![image](https://github.com/user-attachments/assets/7d5d08d3-1eeb-4ed2-a7e9-497e75beb0d0)



Object Pooling:
Object pooling was implemented for the targets. A pool of 4 targets is instantiated when the game starts, which are accessed by a spawner object every 1.5 seconds to spawn a target. When the player shoots a target, or when the target reaches the bottom of the screen, the object is deactivated and returned to the pool.
I created an alternate scene with spawning logic that did not implement object pooling to compare.

Diagram:

![image](https://github.com/user-attachments/assets/c1c07871-bbec-467b-a4f7-37ff2570d084)


Object Pool Performance:

![optimized](https://github.com/user-attachments/assets/4645bde1-28bb-42b8-940a-9768ce39857b)


Unoptimized Performance:

![Unoptimized](https://github.com/user-attachments/assets/13b48fb9-b3c4-44d0-a412-4157ce5b6368)



Singleton:
The extra pattern I implemented was singleton. Both the ReticleController and UIManager are singletons to ensure there is only ever 1 instance of them in the scene at a time, and they are globally accessible. The ReticleController is accessed by the movement commands to move the reticle. The UIManager is accessed by multiple objects to allow for the score and lives to be changed when appropriate.

Diagram:

![image](https://github.com/user-attachments/assets/004f726a-2647-4cc2-8273-00038f53267b)
