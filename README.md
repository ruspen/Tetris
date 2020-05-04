# Tetris
Mobile game
# Architecture
Combination of modular system (decomposition) and MVC

Each scene has:
* Main controller (Controller) 
* UI Controller (View)
* Data (Model) It may not be if the scene uses only data from the global module
The main controller initializes and calls all the necessary modules that should be used on scene.

Modules

Each module can only be accessed through the interface. This does not apply to the global module and scenes.

Modules communicate with each other only through received events or requested data in initialization.
This is done to enable the replacement of modules without extra time

Each module has its own MVC-based architecture for maximum autonomy
The module may not have Model ow View if there is no need to use. For example, a game module may give game state information to the one who created it. And the creator, if desired, can visualize this information

Decomposition levels:
* 0 Tetris
* 1 OrbitalityGame.SceneModules (Has a scene controller that activates all the necessary modules)
* 1 OrbitalityGame.GlobalModule 
* 1 OrbitalityGame.GameModule (access through IGameController)
* 2 OrbitalityGame.GameModule.GameUIModule (access through IGameUIController)

# State Machine
During row deletion, we invoke the visualization of scores. Before the animation works, using the State Machine, we get the data of the current score and change the necessary parameter.
Honestly, this is only to show understanding of the State Machine
Tetris is a simple game that does not need to use a State Machine
The State Machine is used to create additional conditions in the animation settings that have dependent states.
For example, a hero’s animation, in different situations, can cause additional state or change animation parameters inside itself
Animation should not affect the course of the game, as this is a violation of the application architecture.
