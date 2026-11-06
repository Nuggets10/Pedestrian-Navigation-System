# Overview
**Pedestrian Navigation System** is a Unity package to simulate pedestrians in a 3D environment using a node based navigation system.

![Image](https://github.com/user-attachments/assets/af491d37-e6b2-4f01-ace3-4df6cc675d19)

The package includes a demo scene that showcases all its features.
# Installation
You can download and install the package directly from the official Unity Asset Store [here](https://assetstore.unity.com/packages/tools/utilities/pedestrian-navigation-system-314767).
Alternatively, you can clone this repository to your project's folder.

# Set up
To properly set up the navigation system, follow these steps:
- Create an empty GameObject and attach the **PedestrianSystemController.cs** component to it.
- Configure the attached script as desired. A description of each parameter is provided here on GitHub or by hovering over the variables in the Inspector.
  - The script also needs a pedestrian prefab. You can assign the one provided with the package or create your own. To do that, just create a gameobject and assign the **PedestrianSystemMover.cs** component to it.
- Create a new node by clicking the **"Add node to the scene"** button in the Inspector.
- Duplicate and position the newly created node to design the pedestrians' path. Ensure all nodes are children of the same GameObject.
- For each node, specify its adjacent nodes in the Inspector. Once everything is set up correctly, green lines indicating the path will appear.

![Image](https://github.com/user-attachments/assets/4ebf6d14-aea1-42f9-b7fe-29b8804b5b84)
