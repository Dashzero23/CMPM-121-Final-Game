# CMPM-121-Final-Game (F2 Dev Log Updated)
## First Devlog Entry - 11/18/23
### Introducing the team
Code Lead: Jeevithan Mahenthran/Jeevi (https://github.com/Jeeevii)  
Design Lead: Gabriel Li/Gabe (https://github.com/gabriel-yunjia)  
Art Lead: Nguyen Vu/Dash (https://github.com/Dashzero23)  

### Tools and materials
The engine we are using for this project is Unity3D, since Dash and Gabe have some experience and knowledge about the engine and Jeevi wanted to tryout the engine a while ago.  
The language will be C# as it is the default language for Unity3D.  
We are going to use VSCode as our IDE, Blender for our 3D models and Piskel for some of our 2D arts. VSCode is a stable for coding IDE and we have been using it since forever. Dash has good experience with Blender and had implemented 3D animation in previous games. Piskel is a free and simple pixel art website that can import/export images and fits what we need.

### Outlook
We are hoping to accomplish a complex wave spawning mechanics with different type of enemies while keeping the code data-driven and readable, enemies/turret AI as well as 3D animations on enemies/turrets.  
The hardest part of this project is probably getting all enemies/turret animated and implement/balance the wave spawning mechanic.  
Dash is hoping to improve on his Blender skills while Gabe and Jeevi are looking to improve on their level/AI design and general coding skill.  

## F0 Dev Log
### How we satisfied the software requirements
[F0.a] The player can move around in a 5x5 grid with WASD  
[F0.b] The game only updates after the player moved  
[F0.c] The player can reap/sow the tile they are standing on top of, further info can be seen in Debug.log  
[F0.d] There are sun and water level and sun is randomly generated/removed every turn, while water is always true once a tile has water once  
[F0.e] There are 2 type of plants (carrot and grass) and 2 growth level (seed and grown)  
[F0.f] Currently the plant grow if the tile has both water and sun and the growth level is seed  
[F0.g] The play scenario is completed if the player has at least 10 grown carrots  
### Reflection
Our plans changed quite a bit as we shifted Dash into a helper in developing the main mechanics while Gabe is now focused on player interactions for latter requirements. We decided to not use Blender as it would take more time and less efficient than simply using Piskel for 2D arts so Dash can spend more time helping the code side.

## F1 Dev Log
### How we satisfied the software requirements
[F0.a] The player can move around in a 5x5 grid with WASD  
[F0.b] The game only updates after the player moved  
[F0.c] The player can reap/sow the tile they are standing on top of, further info can be seen in Debug.log  
[F0.d] There are sun and water level and sun is randomly generated/removed every turn, while water is always true once a tile has water once  
[F0.e] There are 2 type of plants (carrot and grass) and 2 growth level (seed and grown)  
[F0.f] Currently the plant grow if the tile has both water and sun and the growth level is seed  
[F0.g] The play scenario is completed if the player has at least 10 grown carrots  
[F1.a] My team use SoA style with the struct CellState in the script GridCell and the main array is stored in FarmGrid script, the Undo and Redo array is stored within the GridCell  
[F1.b] There are an Undo/Redo button and allowed to undo to the beginning and redo til where they are at. The undo/redo array is stored as array of arrays, where the arrays inside are the current state of the game (status of every grid cell on the board), once the player made a move, it pushes the current state array into the undo array, and remove from it when undo is used, the recently undo'ed array is pushed into redo, and if redo is called, the process happen vice versa  
[F1.c] The player can save the game into any file name and load any file name that is saved locally, and put a Debug.log message when can't find a file when loading. The save method is simply converting the undo/redo array and the current state of the game into string and int since JSON can't read my customized struct as input. I made Serialized Data so I can store my own struct in order to store all the data I wanted, then I made a list of arrays, where the arrays are either current state of the game (single array) or undo/redo array (array or arrays). For loading saved file, I do the save file but in reversed, and applied the save data into the current game's variable, overwriting and updating all arrays and cell status.  
[F1.d] There is an AutoSave file that is saved every move the player made, and the player can load it manually using the same load file button. I simply call the save file function described in F1.c everytime the player move and the file name is AutoSave.   
### Reflection  
A lot of changes happen as Dash is now the Engine Lead due to him being very familar with Unity. Jeevi will now be helping with debugging and refining/refactoring the code and Yunjia is focusing on F2 and F3 requirements.


## F2 Dev Log
### F0 + F1 Changes:
[F0.a] The player can move around in a 5x5 grid with WASD  
[F0.b] The game only updates after the player moved  
[F0.c] The player can reap/sow the tile they are standing on top of, further info can be seen in Debug.log  
[F0.d] There are sun and water level and sun is randomly generated/removed every turn, while water is always true once a tile has water once  
[F0.e] There are 2 type of plants (carrot and grass) and 2 growth level (seed and grown)  
[F0.f] Currently the plant grow if the tile has both water and sun and the growth level is seed  
[F0.g] The play scenario is completed if the player has at least 10 grown carrots  
[F1.a] My team use SoA style with the struct CellState in the script GridCell and the main array is stored in FarmGrid script, the Undo and Redo array is stored within the GridCell
[F1.b] There are an Undo/Redo button and allowed to undo to the beginning and redo til where they are at. The undo/redo array is stored as array of arrays, where the arrays inside are the current state of the game (status of every grid cell on the board), once the player made a move, it pushes the current state array into the undo array, and remove from it when undo is used, the recently undo'ed array is pushed into redo, and if redo is called, the process happen vice versa  
[F1.c] The player can save the game into any file name and load any file name that is saved locally, and put a Debug.log message when can't find a file when loading. The save method is simply converting the undo/redo array and the current state of the game into string and int since JSON can't read my customized struct as input. I made Serialized Data so I can store my own struct in order to store all the data I wanted, then I made a list of arrays, where the arrays are either current state of the game (single array) or undo/redo array (array or arrays). For loading saved file, I do the save file but in reversed, and applied the save data into the current game's variable, overwriting and updating all arrays and cell status.  
[F1.d] There is an AutoSave file that is saved every move the player made, and the player can load it manually using the same load file button. I simply call the save file function described in F1.c everytime the player move and the file name is AutoSave.  
### How we satisfied the software requirements
[F2.a]
For our external DSL for scenario design, we used JSon as our pre-exisiting data language. Here is a snippit of our scenario definition.

```
[
  {
    "training": {
      "grid_size": [5, 5],
      "plant_types:": ["carrot", "grass"],
      "win_conditions": [
        ["carrot", "min", 10]
      ],
      "instructions": "collect at least 10 carrots"
    }
  },
  {
    "drought": {
      "grid_size": [10, 10],
      "available_plants": ["carrot", "grass"],
      "win_conditions": [
        ["carrot", "min", 10],
        ["grass", "max", 0]
      ],
      "special_events": [
        [5, "drought: no water"],
        [7, "solar storm"]
      ],
      "human_instructions": "collect all carrots and no grass at all."
    }
  }
]
```

In Natural Language:
1. Training Scenario:
   
  - Grid Size: The training scenario is set in a grid of 5 by 5 tiles.
  - Plant Types: There are two types of plants available, namely "carrot" and "grass."
  - Win Conditions: To successfully complete the training, you need to have at least 10 carrots.
  - Instructions: The goal is to collect at least 10 carrots according to the given instructions.
    
2. Drought Scenario:
   
  - Grid Size: The drought scenario takes place in a larger grid of 10 by 10 tiles.
  - Available Plants: Similar to the training scenario, you have access to "carrot" and "grass."
  - Win Conditions: To win during the drought, you need a minimum of 10 carrots, and there should be no grass at all (maximum of 0 grass).
  - Special Events: There are two special events: at the 5th turn, there is a "drought" event, where the water level will be significantly lower and at the 7th turn, a "solar eclipse" occurs, where sun levels will be down. 
  - Instructions: The goal here is to collect all carrots and ensure that there is no grass at all, following the provided instructions.

In simpler terms, for the training scenario, you're aiming to collect a bunch of carrots. In the drought scenario, you not only want to collect carrots but also make sure there's no grass growing, and you'll need to deal with some challenges like a drought and a solar eclipse along the way.

### Reflection

Nothing Changed that much regarding each team memebers tasks, but one thing that I learned from doing the F2 Requirements is that Unity isn't the best for doing internal or External DSLs. Unity primarily uses C# as its scripting language. While C# is a powerful and versatile language, it may not be the best choice for creating dynamic DSLs. DSLs often benefit from a more flexible language with dynamic features, which may be found in languages like Python or JavaScript. These languages allow for more concise and expressive syntax, making it easier to define and execute DSL-like constructs. If we were to start over we might chose a JS-based engine link phaser to create this game. 

## F3 Dev Log
### F0 + F1 + F2 Changes:  
[F0.a] The player can move around in a 5x5 grid with WASD, now with on screen buttons  
[F0.b] The game only updates after the player moved  
[F0.c] The player can reap/sow the tile they are standing on top of, now with on screen buttons, further info can be seen in Debug.log  
[F0.d] There are sun and water level and sun is randomly generated/removed every turn, while water is always true once a tile has water once  
[F0.e] There are 2 type of plants (carrot and grass) and 2 growth level (seed and grown)  
[F0.f] Currently the plant grow if the tile has both water and sun and the growth level is seed  
[F0.g] The play scenario is completed if the player has at least 10 grown carrots  
[F1.a] My team use SoA style with the struct CellState in the script GridCell and the main array is stored in FarmGrid script, the Undo and Redo array is stored within the GridCell  
[F1.b] There are an Undo/Redo button and allowed to undo to the beginning and redo til where they are at. The undo/redo array is stored as array of arrays, where the arrays inside are the current state of the game (status of every grid cell on the board), once the player made a move, it pushes the current state array into the undo array, and remove from it when undo is used, the recently undo'ed array is pushed into redo, and if redo is called, the process happen vice versa  
[F1.c] The player can save the game into any file name and load any file name that is saved locally, and put a Debug.log message when can't find a file when loading. The save method is simply converting the undo/redo array and the current state of the game into string and int since JSON can't read my customized struct as input. I made Serialized Data so I can store my own struct in order to store all the data I wanted, then I made a list of arrays, where the arrays are either current state of the game (single array) or undo/redo array (array or arrays). For loading saved file, I do the save file but in reversed, and applied the save data into the current game's variable, overwriting and updating all arrays and cell status.  
[F1.d] There is an AutoSave file that is saved every move the player made, and the player can load it manually using the same load file button. I simply call the save file function described in F1.c everytime the player move and the file name is AutoSave.  
[F2.a]
For our external DSL for scenario design, we used JSon as our pre-exisiting data language. Here is a snippit of our scenario definition.  

```
[
  {
    "training": {
      "grid_size": [5, 5],
      "plant_types:": ["carrot", "grass"],
      "win_conditions": [
        ["carrot", "min", 10]
      ],
      "instructions": "collect at least 10 carrots"
    }
  },
  {
    "drought": {
      "grid_size": [10, 10],
      "available_plants": ["carrot", "grass"],
      "win_conditions": [
        ["carrot", "min", 10],
        ["grass", "max", 0]
      ],
      "special_events": [
        [5, "drought: no water"],
        [7, "solar storm"]
      ],
      "human_instructions": "collect all carrots and no grass at all."
    }
  }
]
```

In Natural Language:
1. Training Scenario:
   
  - Grid Size: The training scenario is set in a grid of 5 by 5 tiles.
  - Plant Types: There are two types of plants available, namely "carrot" and "grass."
  - Win Conditions: To successfully complete the training, you need to have at least 10 carrots.
  - Instructions: The goal is to collect at least 10 carrots according to the given instructions.
    
2. Drought Scenario:  
   
  - Grid Size: The drought scenario takes place in a larger grid of 10 by 10 tiles.
  - Available Plants: Similar to the training scenario, you have access to "carrot" and "grass."
  - Win Conditions: To win during the drought, you need a minimum of 10 carrots, and there should be no grass at all (maximum of 0 grass).
  - Special Events: There are two special events: at the 5th turn, there is a "drought" event, where the water level will be significantly lower and at the 7th turn, a "solar eclipse" occurs, where sun levels will be down.  
  - Instructions: The goal here is to collect all carrots and ensure that there is no grass at all, following the provided instructions.  

In simpler terms, for the training scenario, you're aiming to collect a bunch of carrots. In the drought scenario, you not only want to collect carrots but also make sure there's no grass growing, and you'll need to deal with some challenges like a drought and a solar eclipse along the way.  
### How we satisfied the software requirements
[F3.a] We internationalized the game by using Dictionary data type to change every visible text to the player to different language based on the current chosen language, we translated all the text manually as Gabe is proficient with Chinese and Dash's friend is proficient in Arabic. We made a button that rotate through 3 languages: English, Arabic and Chinese. It also includes text from things that aren't on the screen initially but appear at the game goes on (winning screen and restart button)  
[F3.b] There are 3 languages, default is English, logographic one is Chinese, right to left is Arabic  
[F3.c] Our game is made in Unity and it comes with option to publish into mobile platform, and we are getting the result we wanted by installing the game files directly onto the device (currently Android and BlueStack (an Android emulator on PC)), we have added mobile supported control with buttons on the screen  
[F3.d] Currently there is no part of the game required internet to work as everything are ran based of the code that is already installed, and it has been tested on our device  
## Reflection
This is the final dev log and final part of our development on this game, so we are happy that we worked with each other for this far. Toward the end, since Gabe did a lot during F2 phase, so we shifted Dash and Jeevi to be the one working on this final stretch. There are other options for Internationalization/Localization in Unity as we could literally import the Localization package and let it do the job, however, we figured it would not be applicable for all applications, and came up with using Dictionary to link keyword with phases we wanted it to be eg. {"Movement", "Use WASD to move around"}. Dash came up with the idea and implement most of it, Gabe did the Chinese translation and Jeevi helped with some code issues and refactoring.
