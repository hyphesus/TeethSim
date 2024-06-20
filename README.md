
# Teeth Examination Simulator For Phantom-Omni haptic device

This Unity project contains my 4th-grade thesis for computer engineering bachelor's. This project aims to create an accurate and deliberate environment for Dentist students, with the help of Phantom-Omni haptic device. To be more precise, the examination process the user going through will be a cavity cleaning/filling situation. For real usage purposes, the movement speed / the impact effect of haptics are going to be evaluated based on the image processing of certain professionals at work. 

![image](https://github.com/hyphesus/TeethSim/assets/72172084/5e3cb41e-61a2-49e6-9c12-ae982b2a7cfe)

![image](https://github.com/hyphesus/TeethSim/assets/72172084/29ffc236-6f95-40e0-a049-e5e2ee11f73c)

## Setting it up

Simply download the designated Haptic Device's driver after connecting it to your Pc. Clone this repository and then go to the hierarchy. In this image, you will change the Device Identifier name of HapticActor object.
![image](https://github.com/hyphesus/TeethSim/assets/72172084/cda4d746-2488-48d3-913f-321c2b295486)

![image](https://github.com/hyphesus/TeethSim/assets/72172084/431d22cc-a141-478f-beb0-f714ca7c0a80) 
change its name based on the information of the haptic device's driver. Remember that this project has been built in Unity 2022.3.21F1. 

## How to play?

Set your FreeLook cameras with W A S D for 2d movement and CTRL - SHIFT for 3d movement. Use your haptic device to interact.

![image](https://github.com/hyphesus/TeethSim/assets/72172084/201d0424-ae2b-4bc5-9a6c-c4de2c64b7fe)


## Plugin for Haptics

https://assetstore.unity.com/packages/tools/integration/haptics-direct-for-unity-v1-197034
(for 1394 port phantom-omni's) Remember that this driver has not been updated since 2022, so there might be some updates you have to do to achieve consistent workspace for haptic device.

## How does the simulation work?

The simulation solely depends on the collision between the rotten part and the tip of the sond. When the collision happens and the user presses the K button, the rotten part gets erased one by one. 

# What are the hierarchy items?
- Main Camera: has the help window and Look Around script for information and camera control.
- SceneObjects: has the ground and stage objects which creates the environment in simulation area
- StageB / StageS: a black bordered area for a better look
- dentures-teeth 1: complete teeth mesh. Has a Mesh collider, kinematic RigidBody and custom Haptic Material for accurate interaction purposes.
- Headline: Title in-game
- SimpleStylus: dental pick mesh.
- HapticActor: customizable Haptic device initialization.
- Haptic Collider: the part that gives the haptic feeling to the user. Has a sphere collider, rigid body, Destroy On Interaction script(for rot removing) and Haptic Collider script( for collision detection and force settings).
- Scene Manager: manages scene for further uses. Deactivated and currently is not being used.
- Rotten part: ROT tagged spheres. it has kinematic rigid body.

# What's there for development?

- Dividing a tetrahedron into asymmetrical tetrahedrons and implementing these tetrahedrons for rotten part.(Since symmetrical ones are impossible)

- Creating an image processing code with pixel accurate speed measurement.

- Acquiring a more accurate jaw model (3D) and a sond model.

- Making the simulation work fine without the haptic device for debugging purposes.

- Optimization for haptic device movement within the plugin script ; dampen strength ...etc. values.

  
