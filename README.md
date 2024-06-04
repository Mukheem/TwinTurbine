# TwinTurbine
This group academic project, involving four participants, is part of the **Design for Complex and Dynamic Contexts (DCDC)** course at Stockholm University. Our project aims to create a digital twin prototype within an immersive environment. Utilizing Meta's Spatial Anchors, we aim to provide a collaborative experience, enhanced by IoT integration for tangible interactions.

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/1884a74f-4e91-4f04-bb66-80734ae570e6" alt="Team Logo" width="40%";" height="auto">
    <br>
    <i>Team Logo</i>
</p>


## 1. Introduction
Welcome to **_TwinTurbine_**, a cutting-edge **digital twin** project designed to let you experience the operation of a wind turbine in a mixed reality (MR) environment. MR enables multi-user collaboration, allowing multiple users to monitor and control the wind turbine's operations from remote locations. By leveraging MR, users can visualize the wind turbine and its real-time data in a Mixed reality environment, receive immediate feedback, and interact dynamically with the physical turbine throughout the experience. As accessing a real physical turbine was not feasible, we used a **scaled physical turbine** model to accurately emulate the behavior of a real wind turbine.

### 1.1. **_Digital Twin (DT)_ description**
A Digital Twin is a virtual replica of a physical object, system, or process. This digital model is designed to accurately reflect the physical counterpart, capturing its characteristics, behaviors, and states. Digital twins are used to simulate, analyze, and monitor real-world objects or systems in real-time, allowing for improved decision-making, predictive maintenance, and optimization.

In simple terms, a digital twin is like having a detailed, interactive 3D model of a machine, building, or even an entire city that you can use to see how it works, predict problems before they happen, and find ways to improve it. This entire concept operates on the basis of five components: the physical entity, the virtual entity, services,data, and the connection between the physical and digital worlds.
  
### 1.2. Five-dimension DT modeling components: 
The five-dimension DT model consists of five essential components that work together to create a comprehensive and interactive system. In TwinTurbine, these components are outlined as follows:  
1. **Physical Entity**: The actual, real-world object or system being replicated digitally. This includes the physical assets and hardware involved in the project, such as the scaled wind turbine, servo motor, generator, and photoresistor sensor. In TwinTurbine, the scaled physical entity generates a voltage, providing real-time data displayed on the GUI.
2. **Virtual Entity**: A digital representation of the physical entity, simulating its characteristics and behaviors. In our project, this is visualized in a Mixed Reality environment through a VR headset. The Virtual Entity includes a virtual wind turbine and a dashboard designed to observe real-time data, control the wind turbine, and facilitate interactions.
4. **Services**: Analytical and operational functions that utilize data to generate insights and improve performance. TwinTurbine offers services such as remote monitoring and control, enabling users to observe data collected from physical entities and APIs.
5. **Data**: Data encompasses all the information collected and used by the system. In TwinTurbine, this includes real-time voltage generated from physical turbines and data from the Swedish Meteorological and Hydrological Institute (**SMHI**)), such as wind direction and temperature.
6. **Connection** The communication link that enables continuous data exchange between the physical entity and its virtual counterpart. In our project, there is a robust and continuous connection between the components and users, ensuring that physical and virtual entities are seamlessly integrated by data to provide comprehensive services.

### 1.3. The rationale behind this project:
The aim of this project is to develop an initial implementation of Digital Twin, encompassing all five components mentioned earlier, and introducing additional features to enhance the user experience. Alongside the Digital Twin components, an avatar has been introduced to visually engage users and guide them throughout the experience.

Users are initially guided by the avatar, which provides instructions and prompts them to begin by pressing the Green button on the dashboard. This action triggers data retrieval from the API, including real-time wind direction and location temperature data, which informs the rotation of both the Digital and scaled physical wind turbines accordingly. The scaled physical turbine generates voltage, with this data displayed on the MR environment's GUI.

The proposed solution serves as a valuable tool for effective remote monitoring, control, and optimization of turbine performance, facilitating **collaboration** among technicians.  The digital version of the wind turbine in TwinTurbine allows users to analyze issues without the need to visit the physical site.The **Mixed Reality environment** adds value by enabling real-time problem discussion and on-the-fly solutions.
Given that this is the initial implementation, it's important to acknowledge several limitations. However, the prototype still offers an immersive learning experience for students, professionals, and technicians, providing hands-on interaction with digital twin technology and wind turbine operations. Additionally, the avatar and visual guidance provided assist users in understanding the initial steps of interacting with the prototype.

## 2. Design Process
This project aims to develop a digital twin of a wind turbine in MR, allowing multiple users to interact simultaneously and immersively. The design process includes brainstorming, interactions, testing different technologies, creating a Unity scene, creating a collaboration for various users, testing with users, solving the issues, making improvements, and showing the final project. 

### 2.1. Brainstorming:
During some brainstorming, we came up with some ideas for different stages:
- In the first step, we discussed the physical and virtual entities, their connection, and the services and functions we wanted to implement.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/3eac9f71-99c6-40f7-a458-84a681f37e00" alt="TwinTurbine Components" style="max-width:12%;" height="auto">
    <br>
    <i>TwinTurbine Components</i>
</p>
-  Next, we gathered as a team to brainstorm ideas for the primary sketch.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/f3a21469-3eeb-4d80-88a2-3b411f554682" alt="Primary Sketch" style="max-width:12%;" height="auto">
    <br>
    <i>Primary Sketch</i>
</p>
 
- We also focused on the way we want to make the connection between different technical components.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/02ff04c7-eef5-45a5-9264-c03f95653dda" alt="Connection Between Different Technical Components" style="max-width:12%;" height="auto">
    <br>
    <i>Connection Between Different Technical Components</i>
</p>

- Regarding the GUI, we brainstormed the best methods to visualize our real-time data.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/6db0450f-5bfb-4332-a2bb-1e77574ada5e" alt="GUI Prototype" style="max-width:12%;" height="auto">
    <br>
    <i>GUI Prototype</i>
</p>

### 2.2. User Persona:
The target users of TwinTurbine are engineers and technicians engaged in wind energy systems and educational institutions utilizing the model for training purposes. The user persona details are as follows:

**Engineers and Technicians:**	
- Needs: These professionals require sophisticated tools to remotely monitor wind turbine operations. Remote monitoring capabilities enable them to keep track of generated voltage and visualize parameters such as wind direction, and temperature of the turbine's location, ensuring that the turbines operate efficiently. Additionally, real-time feedback offers immediate updates on the turbine's status. Furthermore, multi-user collaboration from different sites enhances communication and coordination among team members, facilitating efficient management of turbine operations.

**Educators and Students:**
- Needs: In an educational setting, there is a need for interactive and immersive tools to teach and learn about wind energy systems. Students benefit from hands-on interaction with digital twin technology, providing a practical understanding of wind turbine operations. Educators require tools that can simulate real-world scenarios, enhance engagement, and provide detailed data analysis to support the learning process. The TwinTurbine model serves as an effective educational aid, offering a comprehensive learning experience in a mixed reality environment

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
At this point, the user journey begins.p

### 2.3. User Journey:
The user journey starts with audio narration that welcomes users and provides an informative project overview. They would observe a virtual wind turbine, which is a replica of the physical wind turbine placed on the table nearby.  They can interact with the prototype by pressing the green button, enabling it to start working. This prototype receives wind direction data from the Swedish Meteorological and Hydrological Institute (SMHI) and aligns the direction of both the physical and virtual turbines accordingly to optimize performance. When the wind flows at a certain speed, the physical wind turbine generates electricity. Then the generated voltage from the turbine would be displayed on the menu to show how much voltage is produced by the wind speed. If they press the red button for an emergency, the wind turbine would be shut down. They can walk around the environment, collaborate with each other, and see the latest state of the turbine.


### 2.4. Wireframes and Prototypes:
Since this experience is in a mixed reality (MR) environment, it includes objects the user can interact with in the virtual and physical environment. Virtual entities act as simulators for physical entities, allowing for seamless interaction. Moreover, the experience is designed for multiple users, enabling them to visualize and modify settings while observing changes made by others. To determine the most effective technologies for our project, the team experimented with a variety of tools and methods. This included evaluating different physical wind turbines available for purchase, testing various virtual wind turbine assets, and comparing multiple servo motors. Additionally, we assessed the performance of the project using different VR headsets, specifically the Meta Quest and Varjo, to identify which platform best meets our goals.

#### 2.4.1 Organizing physical entities: 
organizing tangible items is an important part of this project. To understand how to rotate the physical wind turbine, the team members tried various strategies and tools to see which was more appropriate for the project.

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/fa257692-f7d2-404d-9e8d-6e579506210e" alt="SVM and wind turbine" style="max-width:12%;" height="auto">
    <br>
    <i>Servo motor and wind turbine</i>
</p>

We discussed the logic behind turbine rotation:
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/a37a34d2-77a4-4313-b69b-c881388368bc" alt="Turbine Rotation" style="max-width:12%;" height="auto">
    <br>
    <i>Turbine Rotation</i>
</p>

We also calculated how the turbine should work and rotate for 90 degrees.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/d8e76fef-a686-470f-9664-435ee04255eb" alt="Calculation" style="max-width:12%;" height="auto">
    <br>
    <i>Calculation</i>
</p>

#### 2.4.2 Sensors: 
physical wind turbine from Amazon is used. Additionally, a servo motor is emulated to make the turbine ritate towards the wind direction collected from API. A photoresistor, which includes a light source, is integrated into the wind turbine. When the turbine operates, it generates light, and the photoresistor detects the light's voltage. So real-time data, (the **voltage** generated by the turbine) is collected from the physical entity and transferred to the virtual environment for monitoring and visualization.

#### 2.4.3 API: 
Real-time data, including the **wind direction**, **temperature**, and **wind speed** related to the location, are collected from the Swedish Meteorological and Hydrological Institute (SMHI). Additionally, we display the **location** wich us set to **Kista**.


#### 2.3.4 3D Printing: 
The team used a 3D printing prototype to set up the physical entity. The template has been created in **Fusion 360** App, and the template is provided below.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/b018dd51-b98a-4405-b659-f78bf3902b92" alt="WT3D" style="max-width:12%;" height="auto">
    <br>
    <i>WT 3D printing prototype </i>
</p>

#### 2.5 Graphical User Interface (GUI): 
- Initially, we designed a single GUI to display all variables together in one single GUI:
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/a3136ca9-b3c2-498e-929e-a6d611939381" alt="First GUI" style="max-width:12%;" height="auto">
    <br>
    <i>First GUI</i>
</p>

We received feedback recommending that we separate the voltage data collected from the physical turbine from the other values obtained from the API for better clarity.

#### 2.6 Testing: 
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
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/4dac81fc-cbeb-4fa0-b48c-9a699dc97de7" alt="Circuit Board" style="max-width:20%;" height="auto">
    <br>
    <i>Circuit Board</i>
</p>

### Arduino Code
You can find the Arduino Code in the following file: sketch_VoltageUnity
[Esp32_Client_test.ino](TangibleSketches/ESP32/ESP32_sketch_copy_20240512144341/sketch_VoltageUnity.ino)

### Server 
We have a Photon server enabling collaboration between multiple users. It is accessible from the following site address:
https://dashboard.photonengine.com/

## Usage
To use WindTurbine and interact with its features, follow the guidelines below:
- Ensure that both users are wearing their Meta Oculus Quest headsets and are ready to enter the virtual environment.
- You can move around by walking in the environment.
- Both controllers should be used in WindTurbine.
- Select "Create (UserA)/Join(UserB) the Room" within the menu interface. Use your controller to point at the option and press the corresponding button to select it (typically the "A" button).
- Select "Create new anchor & share it (UserA)/Align to the anchor (UserB)" to set the scene and all assets in the same location.
- Pay attention to the narrations.
- Press the virtual environment's green (start) button to activate the turbine.
- Press the red (emergency) button to reset the turbine values immediately and shut the turbine rotation.
- Visualize real-time data such as wind speed, direction, temperature, and turbine-generated voltage displayed on the GUI within the virtual environment.



## Draft Poster
<p align="center">
    <img src="https://github.com/dalarna2022/TwinTurbine/blob/main/Portfolio%26Poster/Draft%20poster.jpeg" alt="Poster" style="max-width:10%;" height="auto">
    <br>
    <i>Poster</i>
</p>

## References


## Contributors
Abdul Mukheem Shaik
<br/> mukheemuddin@gmail.com
<br/> [LinkedIn](https://www.linkedin.com/in/abdul-mukheem-shaik?utm_source=share&utm_campaign=share_via&utm_content=profile&utm_medium=android_app)

Masoomeh Advand
<br/> Masoomeh.advand@gmail.com
<br/> [LinkedIn](https://www.linkedin.com/in/masoomeh-advand-3259442aa/)

Mina Maddahi 
<br/> mima4938@student.su.se
<br/> [LinkedIn](http:///www.linkedin.com/in/mina-maddahi-9b90b5264)

Zeinab Bagheri Fard
<br/> bagherifard.zeinab@gmail.com
<br/> [LinkedIn](https://www.linkedin.com/in/zeinab-bagherifard-b6458b272/)
