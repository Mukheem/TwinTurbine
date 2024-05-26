# TwinTurbine-DCDC
This is a group Academic Project for **DCDC** course at Stockholm University, designed to experience a **digital twin** project in immersive technology.

<figure style="text-align:center">
    <img src="https://github.com/dalarna2022/TwinTurbine/blob/main/Portfolio%26Poster/WBgTeamLogo.jpeg" alt="Communication" style="max-width:20%;" height="auto">
    <figcaption><i>"Team Logo" with white background</i></figcaption>
</figure>

<p align="center">
    <img src="https://github.com/dalarna2022/TwinTurbine/blob/main/Portfolio%26Poster/WBgTeamLogo.jpeg" alt="Communication" width="20%">
    <br>
    <i>"Team Logo" with white background</i>
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
4. **Data**: The real-time data collected from physical entity,  simulations data from virtual entities, data from the services, and data about the environment.
5. **Connection** The continuous and robust connection between above components.
 
### 1.3. The rationale behind this project:
The proposed solution is valuable for effective remote monitoring, controlling, and improving the turbine's performance. Moreover, it offers an immersive learning experience for students and professionals to understand and interact hands-on with digital twin technology and wind turbine operations.

## 2. Design Process
<!--Evidence on the general overview of how you planned, designed, and developed your project, including the goals, challenges, and solutions._]-->
This project aims to develop a digital twin of a wind turbine using immersive technologies, allowing multiple users to interact simultaneously. The design process includes brainstorming, interactions, testing different technologies, creating a Unity scene, creating a collaboration for multiple users, testing with users, solving the issues, making improvements, and showing the final project. 

### 2.1. Brainstorming:
After some brainstorming, we came up with some ideas for different stages:

- In the first step, we discussed the physical and virtual entities, their connection, and the services and functions we wanted to implement.

<figure style="text-align:center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/03e1ef34-4b37-421a-b54a-28db34e8059b" alt="DTComponents" style="max-width:100%;" height="auto">
    <figcaption style="padding-top: 10px;"><i>Digital Twin Components</i></figcaption>
</figure>


<figure style="text-align:center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/7ca62bda-072b-40ea-a0ed-361c86724b81" alt="Primary Prototype" style="max-width:100%;" height="auto">
    <figcaption><i>Primary Prototype for physical turbine & virtual model</i></figcaption>
</figure>

- Then, we shared our ideas on how to rotate the servo motor from Arduino and which physical turbine is better to provide.
<figure style="text-align:center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/7ca62bda-072b-40ea-a0ed-361c86724b81" alt="Primary Prototype" style="max-width:100%;" height="auto">
    <figcaption style="margin-top: 10px;"><i>Primary Prototype for physical turbine & virtual model</i></figcaption>
</figure>

<figure style="text-align:center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/c1b97fd4-f495-4e54-8c17-a1d949cca986" alt="Wind Turbine" style="max-width:100%;" height="auto">
    <figcaption style="padding-top: 10px; margin-top: 10px;"><i>Servo motor and wind turbine</i></figcaption>
</figure>


- Finally, we focused on the way we want to make the connection between ESP32 and Unity
<figure style="text-align:center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/d910c49e-2518-4181-8831-0987415b2977" alt="Communication" style="max-width:100%;" height="auto">
    <figcaption><i>Connecting Unity to Arduino</i></figcaption>
</figure>


### 2.2. User Persona:
The leading target group includes Linkedin enterprises that are interested in immersive technology. Moreover, other target users are engineers and technicians working with wind energy systems and educational institutions where the simulator can be used for training. The user persona details are as follows:

1. **LinkedIn Enterprises:**
- Industry: Various industries interested in immersive technology, such as renewable energy, manufacturing, and engineering.
- Company Size: Small to large enterprises active on LinkedIn.
- Needs: Comprehensive support and resources for successfully adopting and utilizing immersive technologies within their organizations.
- Goals: Improve operational efficiency and competitiveness by using immersive technologies for workforce training and skill development and integrate immersive technology solutions seamlessly into existing workflows and operations.

2. **Engineers and Technicians:**	
- Age: 25-50
- Occupation: Wind energy engineers and maintenance technicians.
- Skills: Familiarity with wind turbine operations, and experience with VR/AR environments.
- Needs: Tools for remote monitoring, maintenance, and access to real-time feedback on turbine operations.
- Goals: Enhance understanding of turbine performance through immersive simulations and monitor and manage the physical turbine within the virtual model for different sites by multiple users.

### 2.3. Pre-User Journey:
We prepared some initial stages beforehand to avoid requiring users to complete these extra steps. Initially, two team members wear headsets and observe the below menu; after pressing **Ancor Sharing Demo**, One team member creates a room that the other can join.
![Ancor](https://github.com/Mukheem/TwinTurbine/assets/145973209/33cfc2d0-28da-4895-85d7-320921657762)
<img width="667" alt="CP Menu" src="https://github.com/Mukheem/TwinTurbine/assets/145973209/2d828883-0fc0-4d6a-907a-3a2c1006b401">

The next stage involves spawning the avatar, turbine, and menus simultaneously using **Create New Anchor**and **Sharing Anchor**; after that, the other member can **Align member**, which allows them to observe the virtual objects in the same place and the collaboration would be enabled.
At this point, the user journey begins.



### 2.3. User Journey:
<!--A visualization of how your user interacts with your project, from the initial trigger to the final outcome, and what emotions they experience along the way.-->
In this experience, the one user at f


In this experience, the physical wind turbine is emulated using a servo motor. A photoresistor, which includes a light source, is integrated into the wind turbine. When the turbine operates, it generates light, and the photoresistor detects the light's voltage.Real-time data , including RPM of the wind turbine (represented by the servo motor) and the current generated by the turbine, are collected from the physical entity and transferred to the virtual environment for monitoring and visualization.

### 2.4. Wireframes and Prototypes:
<!-- A collection of sketches, mockups, or prototypes that show the layout, structure, and functionality of your project, and how you tested and iterated on them.-->
Since this experience is in a mixed reality (MR) environment, it includes objects the user can interact with in the virtual and physical environment. Virtual entities act as simulators for physical entities, allowing for seamless interaction. Moreover, the experience is designed for multiple users, enabling them to visualize and modify settings while observing changes made by others. To understand which technologies would fulfill the experience, the team members tried various technologies and tools to see which works best for achieving the project's goals.

#### 2.4.1 Organizning physical entities: 
organizing tangible items is an important part in this project. To understand how to rotate the physical wind turbine, the team members tried various strategies and tools to see which was more appropriate for the project.

<figure style="text-align:center">
    <img src="[https://github.com/Mukheem/TwinTurbine/assets/145973209/c1b97fd4-f495-4e54-8c17-a1d949cca986](https://github.com/Mukheem/TwinTurbine/assets/145973209/993ecd59-3dfb-4449-86f3-30509c640749)" alt="Physical Entity" style="max-width:100%;" height="auto">
    <figcaption><i>Servo motor and Arduino</i></figcaption>
</figure>


<figure style="text-align:center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/c1b97fd4-f495-4e54-8c17-a1d949cca986" alt="Physical Turbine" style="max-width:100%;" height="auto">
    <figcaption><i>Testing physical entities</i></figcaption>
</figure>


#### 2.4.2 Sensors: 
The experience includes sensors that can trigger a reaction in the experience. ESP installation using a light sensor was used to test how a button can be used. The light sensor was only used as a placeholder and instead, there will be a button used. The button will be created to instantiate objects in the virtual environment. 

#### 2.3.4 3D Printing: 
The team used a 3D printing prototype to set up the physical entity. The template is taken from the following creator: [ark19](https://www.thingiverse.com/ark19) and below are image showing its printed form.

#### 2.4 Testing: 
During the entire process, several tests were conducted to ensure the project's effectiveness. User testing was done to ensure that the voltage generated by the physical turbine or the variables gathered from XXX API were shown in the virtual model correctly for both users and whether users could use the start or emergency buttons to control the physical turbine and observe changes made by other contributors' simulations. Additionally, overall feedback on the experience has been checked to see if the User Interface (UI) is appropriately designed. Some notes were collected during participants' testing. Below are pictures from the testing phase:


## System description

### Features

[_Features and functionalities of your project. You can use bullet points, screenshots, gifs, or videos to illustrate your points. Also include a link to a demo or a live version of your project._]

For example:

- Immersive and realistic 3D models of [...]
- Interactive and intuitive controls using hand gestures and voice commands
- Customizable settings and preferences for the user experience
- Compatible with various XR platforms and devices

Watch the demo video or try the live version.

Link: <https://extralitylab.dsv.su.se/>

## Installation

[_Installation process to build and run your project. Use code blocks, tables, or lists to show the commands, steps, or requirements the chosen platform. Mention any dependencies or libraries that your project uses and how to install them._]

To install and run [Your app] on your platform or device, follow the instructions below:

| Platform | Device | Requirements | Commands |
| -------- | ------ | ------------ | -------- |
| Windows  | Meta Quest   | Unity 2022.3 or higher, Arduino | `git clone https://github.com/user/repo.git`<br>`cd project-xr`<br>`open MainScene.unity`<br>`Build and Run` |
| Android  | Phone  | Android 19 or higher, ARCore 1.18 or higher | `git clone https://github.com/user/repo.git`<br>`cd solar-system-xr`<br>`open SolarSystemXR.unity`<br>`switch platform to Android`<br>`build and run` |

You also need to install the following dependencies or libraries for your project:

- Library A - a Unity plugin for building VR and AR experiences
- Library B - a C# wrapper for speech recognition and synthesis

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
