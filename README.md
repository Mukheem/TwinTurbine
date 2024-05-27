# TwinTurbine-DCDC
This is a group Academic Project for **DCDC** course at Stockholm University, designed to experience a **digital twin** project in immersive technology.

<p align="center">
    <img src="https://github.com/dalarna2022/TwinTurbine/blob/main/Portfolio%26Poster/WBgTeamLogo.jpeg" alt="Team Logo" width="40%";" height="auto">
    <br>
    <i>Team Logo</i>
</p>

## 1. Introduction

Welcome to **_TwinTurbine_**, which is a **digital twin** project that lets you experience working with a wind turbine in a mixed reality environment. Multiple users can observe and manage the operation of a wind turbine within a mixed-reality environment on remote sites.

### 1.1. **_Digital Twin (DT)_ description**
DT is a model representing a virtual mirror for every physical object to simulate their behaviors digitally. The virtual model can understand the state of the physical entities through sensors installed on the physical parts, so physical and virtual parts interact with each other and remain synchronous. Additionally, the physical objects would respond to the virtual simulation. This model can be used for monitoring, analyzing, optimizing, predicting, and more.
  
### 1.2. Five-dimension DT modeling components: 
The five-dimension DT model consists of five essential components. In this project, these components are outlined as follows:  
1. **Physical Entity**: Wind turbine, servo motor, and photoresistor sensor.
2. **Virtual Entity**: Virtual wind turbine as a simulator, a designed dashboard to control the wind turbine, and interactions to facilitate services.
3. **Services**: Remote monitoring, controlling, and improving the turbine's performance.
4. **Data**: The real-time data collected from physical entities,  simulations data from virtual entities, data from the services, and data about the environment.
5. **Connection** The continuous and robust connection between the above components.
 
### 1.3. The rationale behind this project:
The proposed solution is valuable for effective remote monitoring, controlling, and improving the turbine's performance. Moreover, it offers an immersive learning experience for students and professionals to understand and interact hands-on with digital twin technology and wind turbine operations.

## 2. Design Process
<!--Evidence on the general overview of how you planned, designed, and developed your project, including the goals, challenges, and solutions._]-->
This project aims to develop a digital twin of a wind turbine using immersive technologies, allowing multiple users to interact simultaneously. The design process includes brainstorming, interactions, testing different technologies, creating a Unity scene, creating a collaboration for multiple users, testing with users, solving the issues, making improvements, and showing the final project. 

### 2.1. Brainstorming:
After some brainstorming, we came up with some ideas for different stages:

- In the first step, we discussed the physical and virtual entities, their connection, and the services and functions we wanted to implement.

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/3eac9f71-99c6-40f7-a458-84a681f37e00" alt="Brainstorming" style="max-width:12%;" height="auto">
    <br>
    <i>Digital Twin Components</i>
</p>

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/f3a21469-3eeb-4d80-88a2-3b411f554682" alt="Primary Prototype for physical turbine & virtual model" style="max-width:12%;" height="auto">
    <br>
    <i>Primary Prototype for physical turbine & virtual model</i>
</p>


- Finally, we focused on the way we want to make the connection between ESP32 and Unity
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/02ff04c7-eef5-45a5-9264-c03f95653dda" alt="Connecting Unity to Arduino" style="max-width:12%;" height="auto">
    <br>
    <i>Connecting Unity to Arduino</i>
</p>



### 2.2. User Persona:
The leading target group includes LinkedIn enterprises that are interested in immersive technology. Moreover, other target users are engineers and technicians working with wind energy systems and educational institutions where the simulator can be used for training. The user persona details are as follows:

1. **LinkedIn Enterprises:**
- Industry: Various industries interested in immersive technology, such as renewable energy, manufacturing, and engineering.
- Company Size: Small to large enterprises active on LinkedIn.
- Needs: Comprehensive support and resources for successfully adopting and utilizing immersive technologies within their organizations.
- Goals: Improve operational efficiency and competitiveness by using immersive technologies for workforce training and skill development and integrate immersive technology solutions seamlessly into existing workflows and operations.

2. **Engineers and Technicians:**	
- Age: 25-50
- Occupation: Wind energy engineers and maintenance technicians.
- Skills: Familiarity with wind turbine operations and experience with VR/AR environments.
- Needs: Tools for remote monitoring, maintenance, and access to real-time feedback on turbine operations.
- Goals: Enhance understanding of turbine performance through immersive simulations and monitor and manage the physical turbine within the virtual model for different sites by multiple users.

### 2.3. Pre-User Journey:
We prepared some initial stages beforehand to avoid requiring users to complete these extra steps. Initially, two team members wear headsets and observe the below menu; after pressing **Anchor Sharing Demo**, One team member creates a room that the other can join.

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/52db79a8-0086-426b-ba05-bd0457223f8a" alt="Anchor Sharing Demo" style="max-width:12%;" height="auto">
    <br>
    <i>Anchor Sharing Demo</i>
</p>


<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/377f490c-b36b-4a3e-897c-dc083e62ab73" alt="Creating Room" style="max-width:8%;" height="auto">
    <br>
    <i>Creating Room</i>
</p>

The next stage involves spawning the avatar, turbine, and menus simultaneously using **Create New Anchor**and **Sharing Anchor**; after that, the other member can **Align Anchor**, which allows them to observe the virtual objects in the same place and the collaboration would be enabled.
At this point, the user journey begins.



### 2.3. User Journey:
The user journey starts with audio narration that welcomes users and provides an informative project overview. They would observe a virtual wind turbine, which is a replica of the physical wind turbine placed on the table nearby.  They can interact with the prototype by pressing the green button, enabling it to start working. This prototype receives wind direction data from the Swedish Meteorological and Hydrological Institute (SMHI) and aligns the direction of both the physical and virtual turbines accordingly to optimize performance. When the wind flows at a certain speed, the physical wind turbine generates electricity. Then the generated voltage from the turbine would be displayed on the menu to show how much voltage is produced by the wind speed. If they press the red button for an emergency, the wind turbine would be shut down. They can walk around the environment, collaborate with each other, and see the latest state of the turbine.


### 2.4. Wireframes and Prototypes:
Since this experience is in a mixed reality (MR) environment, it includes objects the user can interact with in the virtual and physical environment. Virtual entities act as simulators for physical entities, allowing for seamless interaction. Moreover, the experience is designed for multiple users, enabling them to visualize and modify settings while observing changes made by others. To understand which technologies would fulfill the experience, the team members tried various technologies and tools to see which works best for achieving the project's goals.

#### 2.4.1 Organizing physical entities: 
organizing tangible items is an important part of this project. To understand how to rotate the physical wind turbine, the team members tried various strategies and tools to see which was more appropriate for the project.

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/fa257692-f7d2-404d-9e8d-6e579506210e" alt="SVM and wind turbine" style="max-width:12%;" height="auto">
    <br>
    <i>Servo motor and wind turbine</i>
</p>

#### 2.4.2 Sensors: 
In this experience, the physical wind turbine is emulated using a servo motor. A photoresistor, which includes a light source, is integrated into the wind turbine. When the turbine operates, it generates light, and the photoresistor detects the light's voltage. So real-time data, (the **voltage** generated by the turbine) is collected from the physical entity and transferred to the virtual environment for monitoring and visualization.

#### 2.4.3 API: 
Real-time data, including the **wind direction**, **temperature**, and **wind speed** are collected from the Swedish Meteorological and Hydrological Institute (SMHI). Additionally, we display the **location** and set it to **Kista**.


#### 2.3.4 3D Printing: 
The team used a 3D printing prototype to set up the physical entity. The template has been created in **Fusion 360** App, and the template is provided below.

####Complete

#### 2.4 Testing: 
During the entire process, several tests were conducted to ensure the project's effectiveness. User testing was done to ensure that the voltage generated by the physical turbine or the variables gathered from SMHI API were shown in the virtual model correctly for both users and whether users could use the start or emergency buttons to control the physical turbine and observe changes made by other contributors' simulations. Additionally, overall feedback on the experience has been checked to see if the User Interface (UI) is appropriately designed. Some notes were collected during participants' testing. Below are pictures from the testing phase:


## System description
Wind Turbine includes the following features: 
### Features
- Physical Wind turbine components
- Immersive and realistic wind turbine model
- An environment where participants can see an avatar and hear narrations describing digital twins and our project.
- Multi-user Collaboration, supporting multiple users to interact and collaborate within the virtual environment, observing each other's actions and changes in real time.
- Graphical User Interface (GUI), displaying real-time data such as wind speed, direction, temperature, and turbine-generated voltage, collected from physical sensors and APIs.
- Poke interactions for controlling buttons within the virtual environment.

Watch the demo video or try the live version.

####Complete
Link: <https://extralitylab.dsv.su.se/>

## Installation
To install and run WindTurbine on your platform or device, follow the instructions below:
- The experience is possible using Meta Oculus Quest 3 or Pro
- Unity version 2021.3.32f1

You also need to install the following dependencies or libraries for your project:
- Oculus XR Plugin
- XR Interaction Toolkit
- A NuGet Package Manager for Unity: https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity


## Circuit Board
Please follow the following circuit board representation to setup the physical buttons. 
Requirements: 
- ESP32-S2 ThingPlus Sparkfun
- Arduino Uno
- Breadboards
- Photoresistor
- Servo motor
- Jumper wires
- Transistor
  Please be informed that the LED is the symbol of the physical wind turbine.

 <p align="center">
    <img src="1360" alt="Sketch" src="https://github.com/Mukheem/TwinTurbine/assets/145973209/eb509178-3073-45ef-8773-60967e5f8caf" alt="Circuit Board" style="max-width:12%;" height="auto">
    <br>
    <i>Circuit Board</i>
</p>


## Usage

[_Usage section showing how to use your project and interact with its features. You can use examples, screenshots, gifs, or videos to demonstrate the user interface, controls, and feedback of your project. You can also provide tips, tricks, or best practices for using your project effectively._]

To use [Your App XR} and interact with its features, follow the guidelines below:

- To move around, use the touchpad or the joystick on your controller, or swipe on your phone screen.
- To select ...a planet or a moon, point at it with your controller or your phone, or gaze at it with your headset.
- To zoom in or out, use the trigger or the button on your controller, or pinch on your phone screen.
- To access the information panel, press...
- To use voice commands, say "OK" followed by one of the following phrases:
  - "Show me [X]" - to show X element
  - "Close window Y" - to close window Y
  
Some tips, tricks, and best practices for using [Your App XR} effectively:

- Tip 1
- Tip 2

## Draft Poster
<figure style="text-align:center">
    <img src="https://github.com/dalarna2022/TwinTurbine/blob/main/Portfolio%26Poster/Draft%20poster.jpeg" alt="Communication" style="max-width:100%;" height="auto">
    <figcaption><i>Draft Poster</i></figcaption>
</figure>

<<<<<<< HEAD


=======
>>>>>>> f456fae95097232eece324078f3866b31fe13009
## References

Acknowledge here the sources, references, or inspirations that you used for your project. Give credit to the original authors or creators of the materials that you used or adapted for your project (3D models, source code, audio effects, etc.)

## Contributors

The authors of the project, contact information, and links to their websites or portfolios.
