# CMPM-121-Final-Game
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
