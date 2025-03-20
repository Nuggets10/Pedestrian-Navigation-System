# 📦 | Pedestrian Navigation System
**Pedestrian Navigation System** is a versatile Unity package for pedestrian simulation, offering a simple setup and customizable behavior.
It utilizes a node-based navigation system.

![Image](https://github.com/user-attachments/assets/af491d37-e6b2-4f01-ace3-4df6cc675d19)

The package includes a pre-built scene that showcases all its features.

# 🚀 | Set-up
To properly set up the navigation system, follow these steps or watch the tutorial video here:
- Create an empty GameObject and attach **PedestrianSystemController.cs** to it.
- Configure the attached script as desired. A description of each parameter is provided here on GitHub or by hovering over the variables in the Inspector.
  - The script also needs a pedestrian prefab. You can assign the one provided with the package or create your own. To do that, just create a gameobject and assign **PedestrianSystemMover.cs** to it.
- Create a new node by clicking the **"Add node to the scene"** button in the Inspector.
- Duplicate and position the newly created node to design the pedestrian path. Ensure all nodes are children of the same GameObject.
- For each node, specify its adjacent nodes in the Inspector. If everything is set up correctly, green lines indicating the path will appear.

![Image](https://github.com/user-attachments/assets/4ebf6d14-aea1-42f9-b7fe-29b8804b5b84)

# 🔎 | Scripts Overview
The package contains 4 scripts:
- **PedestrianSystemController.cs** The main script, used to configure the navigation system.
- **PedestrianSystemMover.cs** Attached to the pedestrian, used to make the pedestrians move on the path. Doesn't require any value.
- **PedestrianSystemNode.cs** Attached to each node, builds a path.
- **PedestrianSystemUI.cs** Not needed to be attached to anything, it provides UI elements to make the inspector values more readable.

<p align="center">
    <img src="https://github.com/user-attachments/assets/dd3cbdea-b0ca-4168-85c2-0974c4203718" width="45%" style="vertical-align: top;">
    <img src="https://github.com/user-attachments/assets/f7f7e589-d611-4893-8cd5-291ddbd97041" width="45%" style="vertical-align: top;">
</p>




