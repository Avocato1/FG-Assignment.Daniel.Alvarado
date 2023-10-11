# FG-Assignment.Daniel.Alvarado
Futuregames Assignment, Racegame

For the assignment, I choose to make a racing game. 

How to start the game- To start the game. open the Assets folde, Scenes folder, Main Menu Folder and open the Main Menu scene. From there you can choose from all the different playmodes and levels. All the scripts are in the scripts folder. If you want to take a look at the prefabs there is also a prefab folder. The input actions are located in the Inputs Folder, and all the assets used are in the AssetStore folder. 

Inputs:
For GamePad, these are the inputs: 
R2(RightTrigger): Acceleration
L2(LeftTrigger: Reverse/Brake
X(ButtonSouth):Drift/Handbrake or Submit in UI
L3(LeftStick): Steering
Options(Start): Pause
Share(Select): ResetPosition
D-Pad: UI Navigation

For KeyBoard, these are the inputs: 
W: Acceleration
S: Reverse/Brake
Space:Drift/Handbrake
A&D: Steering
Escape: Pause
Q: ResetPosition
WASD: UI Navigation
Enter: Submit

For KeyBoard2, these are the inputs: 
ArrowKeyUp: Acceleration
ArrowKeyDown: Reverse/Brake
Space:Drift/Handbrake
ArrowKeyLeft and Right: Steering
7(NumPad): Pause
9(NumPad): ResetPosition
ArrowKeys: UI Navigation
Enter: Submit

In my code, player 1 has controllerscheme GamePad, and player2 KeyBoard2.

The game hase two different playmodes that the player can choose from in the main menu. Those are third person gameplay, and isometric gameplay.
You can also choose from which level you want to start from in the main menu. After completing each level, you can choose to either continue to the next level or play a different level. And you can also change level anytime from the pause menu while your playing.
Each playmodes have three different levels. Both gamemodes have the same levels, but with different camera views. The game has full controller support for any controller (i have only tried with dualsense since thats what i have), and you can also use the keyboard for inputs. I have three different controlschemes for the players, but I only use two since its splits screen with two players. Those are GamePad, Keyboard and Keyboard2.

The game hase power ups/ collectible items which are speed boost, fuel and health. The car start with 100 health and fuel. It consumes 1 fuel every .5 second and if its 0, the car respawn at the start line or the checkpoint if the player has gone through it. The car also takes damage when colliding with walls if the speed is over 40KM/H. You can also damage another player when hitting them with a speed over 40km/h.
The health pickups are to increase health when health is less then 100. You can also fall out of the map and take damage from that. When falling out of map, or when health is 0, the cars position is reset to either the start position or the checkpoint. With enough speed, a player can bump in to another player and knock them away. 
There is also coins to collect, and for every 30 coins collected, the player gets a speed boost. All the score collected in eachlevel does not carry over to the next level, so there is no leaderboard system in the game. 
On level 1 and 3, there is a jump. To make the jump, the player needs to go through the speed boost that are placed before the jump. I want the game to kind of feel like Mario Kart. 

The UI navigatin with gamepad inputs can sometimes be a little bit buggy, but the mouse will always work to click on the buttons. And also the fuel pickups get bugged, its supposed to refuel the car to 100 max, but sometimes it gets over 100. Sometimes the NextLevel Button loads the same scene, if it does that you can just change level from either the Main or Pause menu, but usually it works fine. 

If you want to play with controller, dont forget to plug in it before you start the game, otherwise it wont work. 

Code Documentation:
Copy and paste this link: https://docs.google.com/document/d/1wQ8w-X8B1-DAyJtjPRrf1gg8MfVH_vuXQwasvZuNxB4/edit

Sources of inspiration: 
https://www.youtube.com/watch?v=0XpSNJKINAQ
https://www.youtube.com/watch?v=QQs9MWLU_tU
https://www.youtube.com/watch?v=8ZxVBCvJDWk&list=LL&index=5
https://www.youtube.com/watch?v=MBM_4zrQHao&t=432s
https://docs.unity3d.com/Manual/class-WheelCollider.html
https://docs.unity.cn/560/Documentation/Manual/WheelColliderTutorial.html
https://www.youtube.com/watch?v=OmobsXZSRKo
https://www.youtube.com/watch?v=vO_18bhd2nA&t=391s
https://www.youtube.com/watch?v=ZPUtQ4pGGWs&t=0s
https://discussions.unity.com/t/c-figure-out-when-a-number-int-reaches-every-tens/121994

Assets Used: https://assetstore.unity.com/packages/tools/physics/prometeo-car-controller-209444
https://assetstore.unity.com/packages/3d/racetrack-karting-microgame-add-ons-174459
https://assetstore.unity.com/packages/3d/environments/roadways/modular-lowpoly-track-roads-free-205188
https://assetstore.unity.com/packages/2d/gui/icons/20-logo-templates-with-customizable-psd-vector-sources-174999
https://assetstore.unity.com/packages/3d/props/gold-coins-1810

Unity Version of the project: 2022.3.9f1

Regards, Daniel Alvarado
