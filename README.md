# Infinity

Infinity is a puzzle game where the objective is to connect all the lamps to the energies, to do this you must place the pieces correctly based on their shape and the type of line.

By turning on all the lamps you will gradually unlock the other Stages. There are currently three difficulty levels, but you can easily enter the GameDesign screen and create your own Stages.

I dare you to win the third Stage 😉

Download APK: https://drive.google.com/file/d/1wgdT7UfPOG4JjGa6TUqzrTTTf2T7e0Bf/view?usp=sharing

Icon: 

<img src="https://user-images.githubusercontent.com/64444068/138526659-6c69de3a-8821-458c-8c0b-8257148e1e46.png" width="100" height="100" />
Gameplay:

<img src="https://user-images.githubusercontent.com/64444068/138524196-08574d3a-40de-4d18-a9d7-e62234d16c59.png"/>
   
## Scenes
- Application Manager

Responsible for managing scenes, audio and object pool.

- MainMenu

It generates all playable stages from the stages registered in the Game tab of the GameDesign screen. 

- Gameplay

Controls the loading and progression of each stage.
 
## Game Design Screen

To access the Game Design screen just click on Infinity on the toolbar.

![image](https://user-images.githubusercontent.com/64444068/138476944-0aefc655-6862-435e-add2-0220ff901c83.png)

- Infinity Settings

You can set values for each development environment you want to work with.

![image](https://user-images.githubusercontent.com/64444068/138477020-7ade1e7e-a35d-4f3f-acc8-6c884fea25c5.png)

- Game

Here you define which Stage will be available to be played. If you want to test a specific stage directly from the Gameplay scene, just select the desired stage in Test Stage.

![image](https://user-images.githubusercontent.com/64444068/138474889-53a90305-627d-459e-a16b-8590e982d0a4.png)

- Puzzle

On this tab you can define the game parameters, such as the speed of the pieces and their initial spacing

![image](https://user-images.githubusercontent.com/64444068/138476625-e2bd02eb-8027-4c34-b6a8-a294164bb61c.png)

- Stages

Here you can create and edit the Stages.

![image](https://user-images.githubusercontent.com/64444068/138475699-497bb893-6122-49ff-832a-56c93e6a8b3a.png)

- Toolbar

You can copy and paste values from any subtab. It is also possible to delete Stages.

![image](https://user-images.githubusercontent.com/64444068/138476010-f11ef110-d8b8-4394-86c1-238294e14c7c.png)

## Assets

For this project I used [FMOD](https://www.fmod.com/) and [Odin Inspector](https://odininspector.com/) which are my favorite assets. Odin was essential for the GameDesign screen and the stage editor.

- Data

This is where all Scriptable Objects in the game are stored, and you can access the data from the GameDesign screen. The only two exceptions are GameEvent, which are Scriptable Objects of events to communicate between namespaces that don't know each other. (I honestly hoped to use them more often)

![image](https://user-images.githubusercontent.com/64444068/138525751-8b188b16-7476-4cf2-b181-356519808881.png)

- Prefabs

To facilitate the maintenance of the prefabs, I used variants of a base prefab that has the main components that are common to all.

![image](https://user-images.githubusercontent.com/64444068/138486886-b71a3d70-4721-4459-96ec-321b9f48be0d.png)
![image](https://user-images.githubusercontent.com/64444068/138478870-061ab549-9c99-43ee-a7c9-60aa7156d4ba.png)

- Scripts

All scripts are using XML documentation and are separated by their assembly definition and namespaces. I believe that anyone can understand the code well, as the largest MonoBehaviour has only 113 lines (Puzzle Controller).

![image](https://user-images.githubusercontent.com/64444068/138525046-e1517234-2856-4024-9e77-cebe47d4f2d6.png)

## Conclusion

I only took four days to complete this project, I did it in a hurry but I am satisfied with the final result. 😁

The only things I would do differently if I had the time would be to improve the level editor and the graphics as a whole. 
