# TwinTurbine
This group academic project, involving four participants, is part of the **Design for Complex and Dynamic Contexts (DCDC)** course at Stockholm University. Our project aims to create a digital twin prototype within an immersive environment. Utilizing Meta's Spatial Anchors, we aim to provide a collaborative experience, enhanced by IoT integration for tangible interactions.

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/1884a74f-4e91-4f04-bb66-80734ae570e6" alt="Team Logo" width="40%";" height="auto">
    <br>
    <i>TwinTurbine Logo</i>
</p>


## 1. Introduction
Welcome to **_TwinTurbine_**, a cutting-edge **digital twin** project designed to let you experience the operation of a wind turbine in a mixed reality (MR) environment. MR enables multi-user collaboration, allowing multiple users to monitor and control the wind turbine's operations from remote locations. By leveraging MR, users can visualize the wind turbine and its real-time data in a Mixed reality environment, receive immediate feedback, and interact dynamically with the physical turbine throughout the experience. As accessing a real physical turbine was not feasible, we used a **scaled physical turbine** model to accurately emulate the behavior of a real wind turbine.

### 1.1. **_Digital Twin_:**
A Digital Twin(DT) is a virtual replica of a physical object, system, or process. This digital model is designed to accurately reflect the physical counterpart, capturing its characteristics, behaviors, and states. Digital twins are used to simulate, analyze, and monitor real-world objects or systems in real-time, allowing for improved decision-making, predictive maintenance, and optimization.

In simple terms, a digital twin is like having a detailed, interactive 3D model of a machine, building, or even an entire city that you can use to see how it works, predict problems before they happen, and find ways to improve it. This entire concept operates on the basis of five components: the physical entity, the virtual entity, services,data, and the connection between the physical and digital worlds.
  
### 1.2. Five-dimension DT modeling components: 
The five-dimension DT model consists of five essential components that work together to create a comprehensive and interactive system. In TwinTurbine, these components are outlined as follows:  
1. **Physical Entity**: The actual, real-world object or system being replicated digitally. This includes the physical assets and hardware involved in the project, such as the scaled wind turbine, servo motor, generator, and photoresistor sensor. In TwinTurbine, the scaled physical entity generates a voltage, providing real-time data displayed on the GUI.The Servo motor rotates the scaled physical turbine according to the Wind direction; Generator generates electricity and Photoresistor sensor calculates the intensity of the light which is later converted to Voltage and passed on to the Digital dashboard.
2. **Virtual Entity**: A digital representation of the physical entity, simulating its characteristics and behaviors. In our project, this is visualized in a Mixed Reality environment through a VR headset. The Virtual Entity includes a virtual wind turbine and a dashboard designed to observe real-time data, control the wind turbine, and facilitate interactions.
4. **Services**: Analytical and operational functions that utilize data to generate insights and improve performance. TwinTurbine offers services such as remote monitoring and control, enabling users to observe data collected from physical entities and APIs.
5. **Data**: Data encompasses all the information collected and used by the system. In TwinTurbine, this includes real-time voltage generated from physical turbines and data from the Swedish Meteorological and Hydrological Institute (**SMHI**)), such as wind direction and temperature.
6. **Connection** The communication link that enables continuous data exchange between the physical entity and its virtual counterpart. In our project, there is a robust and continuous connection between the components and users, ensuring that physical and virtual entities are seamlessly integrated by data to provide comprehensive services.

### 1.3. The rationale behind this project:
The aim of this project is to develop an initial implementation of Digital Twin, encompassing all five components mentioned earlier, and introducing additional features to enhance the user experience. Alongside the Digital Twin components, an avatar has been introduced to visually engage users and guide them throughout the experience.

Users are initially guided by the avatar, which provides instructions and prompts them to begin by pressing the Green button on the dashboard. This action triggers data retrieval from the API, including real-time wind direction and location temperature data, which informs the rotation of both the Digital and scaled physical wind turbines accordingly. The scaled physical turbine generates voltage, with this data displayed on the MR environment's GUI.

The proposed solution serves as a valuable tool for effective remote monitoring, control, and optimization of turbine performance, facilitating **collaboration** among technicians.  The digital version of the wind turbine in TwinTurbine allows users to analyze issues without the need to visit the physical site.The **Mixed Reality environment** adds value by enabling real-time problem discussion and on-the-fly solutions.
Given that this is the initial implementation, it's important to acknowledge several limitations. However, the prototype still offers an immersive learning experience for students, professionals, and technicians, providing hands-on interaction with digital twin technology and wind turbine operations. Additionally, the avatar and visual guidance provided assist users in understanding the initial steps of interacting with the prototype.

## Disclaimer/Attribution
This project uses a boilerplate from [Unity-SharedSpatialAnchors](https://github.com/oculus-samples/Unity-SharedSpatialAnchors). We would like to attribute and thank the original authors for their foundational work which helped in kickstarting our development.

## 2. Design Process
The aim of this project is to develop a digital twin of a wind turbine in Mixed Reality (MR), enabling multiple users to interact simultaneously and immersively. The design process began with brainstorming sessions to outline the project's scope, objectives, and potential challenges. This was followed by defining user interactions within the MR environment and testing various technologies to identify the most suitable tools for implementation. The virtual environment was then developed in Unity, including modeling the wind turbine and integrating real-time data visualization. Collaborative features were implemented to allow multiple users to engage with the digital twin simultaneously. Subsequent user testing provided feedback on usability, functionality, and overall experience, which led to the identification and resolution of technical and usability issues. Refinements were made based on user feedback and testing results. Finally, the project was compiled into a fully functional presentation, ready to be showcased to the intended audience.

### 2.1. Brainstorming:
The brainstorming phase involves generating and refining ideas to establish the project's objectives, scope, and potential challenges. Our project began with discussions that organized ideas into different stages and corresponding modules. At a high level, we divided the tasks into two main modules: the tangible part and the digital part, and the portfolio module, which showcases the project's technical capabilities to a general audience in a video format.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/3eac9f71-99c6-40f7-a458-84a681f37e00" alt="TwinTurbine Modules" style="max-width:12%;" height="auto">
    <br>
    <i>TwinTurbine Modules</i>
</p>

-  Next, we focused on the main aspect of the tangible module: the functionality of the scaled physical wind turbine. This involved determining the necessary components such as the microcontroller and motor, and how to make them work together effectively. Through our discussions, we decided to use a servo motor to rotate the turbine on its axis, allowing it to turn accurately towards the wind direction.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/f3a21469-3eeb-4d80-88a2-3b411f554682" alt="Primary Sketch" style="max-width:12%;" height="auto">
    <br>
    <i>Initial Sketch: Exploring the Feasibility of Servo Motor for Turbine Control.</i>
</p>

- Subsequently, we considered how to showcase the data generated by the physical asset to users in real-time. This led us to focus on developing a graphical user interface (GUI). We deliberated on the relevant fields and how best to present them to users.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/6db0450f-5bfb-4332-a2bb-1e77574ada5e" alt="GUI Prototype" style="max-width:12%;" height="auto">
    <br>
    <i>GUI Wireframe</i>
</p> 

- Following that, we turned our attention to finalizing the connections between all these components, from the tangible parts to the Unity environment running in the VR headset. Initially, we considered implementing a central server to manage requests between the microcontroller and Unity. However, we recognized that this approach introduced additional dependencies. After careful consideration, we opted for a direct connection between the microcontroller and Unity. This decision aimed to facilitate faster transactions and reduce maintenance requirements, representing a step towards an optimal solution.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/02ff04c7-eef5-45a5-9264-c03f95653dda" alt="Connection Between Different Technical Components" style="max-width:12%;" height="auto">
    <br>
    <i>Connections Between different components</i>
</p>



### 2.2. User Persona:
This prototype, **TwinTurbine** caters to several user groups, with a primary focus on **three key personas** during the design and development of the prototype.

**1. Engineers and Technicians:**	

This group comprises individuals responsible for engineering wind turbines for efficiency, innovation, and environmental sustainability, as well as technicians tasked with fixing issues at physical wind turbine sites.

_Engineers and Technicians_ require advanced tools for monitoring and controlling wind turbines. Traditional wind turbine monitoring and control rely on physical site visits, to identify and address both functional and cosmetic issues, <ins>posing logistical challenges and safety risks</ins>. For instance, in cases of extreme weather conditions exceeding a turbine's operational capacity, technicians typically need to conduct emergency shutdowns on-site. However, such visits become less frequent with TwinTurbine's **_XR (Extended Reality)_** capabilities. During emergencies or routine inspections, the immersive features of TwinTurbine assist in <ins>**rapid problem diagnosis**</ins> and <ins>**solution implementation**</ins>, <ins>**minimising downtime and operational costs**</ins>.

Engineers designing _novel wind turbines_ can leverage the prototype for virtual troubleshooting, eliminating the need for physical fixes. XR's immersive environment allows them to observe turbine behaviour under various conditions, manipulate the digital model, and test feasibility before real-world implementation. This surpasses the <ins>limitations of 3D displays</ins> in several aspects. The immersive experience facilitates <ins>**collaboration**</ins> and <ins>**discussion**</ins>, enabling <ins>**comprehensive analysis**</ins> and <ins>**proactive issue identification**</ins>.



**2. Educators and Students:**

This group comprises instructors developing and delivering educational programs, and students seeking knowledge and practical skills in this rapidly growing field.

Traditional methods relying on textbooks and static visuals can be dry and lack real-world context. Educators and students alike require engaging tools to promote active participation and a deeper understanding of wind turbine technology.While 3D screens or projections offer some improvement over traditional methods by addressing dryness, they still lack interactivity.

However, traditional classrooms often lack opportunities for <ins>hands-on exploration</ins> due to safety concerns. Visiting a physical turbine site <ins>poses risks</ins>, and <ins>visualizing abstract concepts</ins> like component interactions and real-time data can be challenging. 

TwinTurbine addresses these issues by providing a safe and controlled virtual environment with Mixed Reality (MR). Here, students can explore the intricacies of wind turbine operations without physical risks. The MR environment allows them to <ins>**visualize real-time data**</ins> superimposed on a physical model, fostering a deeper understanding of the <ins>**relationship between data and physical turbine behavior**</ins>. This combination of safety, visualization, and interactivity makes TwinTurbine a valuable tool for educators and students. Additionally, students gain insights into the broader concept of digital twins while exploring wind turbine technology.

**3.General Users:**

This broad user group encompasses everyone curious about _Wind energy_, _Digital twin_ technology, or _Extended reality (XR)_ – from professionals to the general public. It includes first-time viewers and encompasses the aforementioned target user groups.

Understanding a novel prototype can be challenging with traditional methods. To address this, TwinTurbine utilizes an <ins>**avatar**</ins> alongside <ins>**video**</ins> and <ins>**audio narration**</ins>. This user-friendly approach guides first-time viewers through the prototype's components and functionalities, ensuring a smooth and hassle-free onboarding experience. Additionally, the engaging nature of the avatar and narration fosters interest and encourages users to explore how TwinTurbine can address their needs.

### 2.3. Pre-User Journey:
Before users begin interacting with the prototype, several crucial steps are taken to ensure a seamless experience. Our team members meticulously prepare the environment to guarantee smooth operation.

One team member takes the role of the "host," while the other is as the "client." Both participants utilize the same application version.

The host initiates the process by launching the "Anchor Sharing Demo" from the menu and creating a room. The application leverages a unique app ID for network authentication, restricting unauthorized users from joining the room. The client receives a notification upon the room's creation and proceeds to join. The client patiently awaits the host to create, align with, and share an anchor.A brief delay (approximately two seconds) occurs before the shared spatial anchor becomes visible to the client. Upon successful visualization, the client aligns themself with the anchor, ensuring both participants share the same virtual space with accurate virtual coordinates. The video below provides a quick overview of the aforementioned steps

https://github.com/Mukheem/TwinTurbine/assets/19348206/00bda476-ee94-4509-b6ef-2a3ed65e25c1

The next steps involve spawning of the Avatar, Turbine, GUI simultaneously triggering a start to user's journey.


### 2.3. User Journey:
The user experience begins with a welcoming narration delivered by a virtual avatar. Accompanying the narration are relevant video clips that provide a clear project overview. Users are then presented with a virtual wind turbine, a digital twin of the physical model placed nearby.

The avatar guides the user through interaction with the prototype. Pressing the green button initiates the system.

Upon activation, the prototype retrieves wind direction data from the Swedish Meteorological and Hydrological Institute (SMHI) in real-time. This data is used to adjust the alignment of both the physical and virtual turbines, ensuring optimal performance based on actual wind conditions.

As wind flows at a certain speed, the scaled physical wind turbine generates electricity, illuminating a light. The light's intensity is measured by a photoresistor sensor. This sensor reading is then converted into voltage, which is displayed on a menu to provide users with real-time feedback on the energy being produced.

The user experience fosters a sense of immersion. Users can freely walk around the virtual space, collaborate with others, and observe the latest operational state of the wind turbine. This interactive environment enhances user engagement and understanding.

A detailed walkthrough video is available below for further exploration.


https://github.com/Mukheem/TwinTurbine/assets/19348206/a229755e-d4e0-48be-b5b3-d74f64afa169




### 2.4. Wireframes and Prototypes:
Visual representations and preliminary models are essential for failproof development before full-scale implementation. Since this experience is in a mixed reality (MR) environment, it includes objects that users can interact with in both virtual and physical settings. Virtual entities act as simulators for physical entities, allowing seamless interaction. Moreover, the experience is designed for multiple users, enabling them to visualize and modify settings while observing changes made by others.

To determine the most effective technologies for our project, the team experimented with various tools and methods. This included evaluating different physical wind turbines models, testing various virtual wind turbine assets, and comparing multiple servo motors, stepped motors. Additionally, we assessed the performance of the project using different VR headsets, specifically the Meta Quest 3 and Meta Quest 2 Pro, to identify which platform best meets our goals.

#### 2.4.1 Organizing physical entities: 
One of the five major components of a digital twin is the physical entity. In TwinTurbine, a scaled wind turbine serves as the physical entity, playing a prominent role in emulating an actual wind turbine to send and receive data to and from the virtual entity. The initial design envisioned the physical entity rotating on its own axis based on wind direction. We explored using a stepper motor for this purpose. However, we ultimately decided to utilize a servo motor to achieve the desired functionality.

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/fa257692-f7d2-404d-9e8d-6e579506210e" alt="SVM and wind turbine" style="max-width:12%;" height="auto">
    <br>
    <i>Protoype of WindTurbine placed over Servo motor during brainstroming phase.</i>
</p>

Later, Our discussions progressed to the logic behind the turbine's rotation. Unlike humans, servo motors don't interpret rotation in degrees, but rather in microseconds (µs) of pulse width. To bridge this gap and achieve the desired rotation based on wind direction, we implemented a conversion mechanism.

<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/a37a34d2-77a4-4313-b69b-c881388368bc" alt="Turbine Rotation" style="max-width:12%;" height="auto">
    <br>
    <i>Intial Sketches showing the direction of Turbine Rotation</i>
</p>

We employed a pre-calculation method. By determining the total time required for a 360-degree rotation, we efficiently derived the time corresponding to each individual degree.
<p align="center">
    <img src="https://github.com/Mukheem/TwinTurbine/assets/145973209/d8e76fef-a686-470f-9664-435ee04255eb" alt="Calculation" style="max-width:12%;" height="auto">
    <br>
    <i>Whiteboard showing the calculations</i>
</p>
Finally, Recognizing the time constraints involved in 3D printing a detailed wind turbine replica, the team opted for a more efficient solution. A pre-made wind turbine model with a built-in generator and light was procured from Amazon. This readily available model expedited the development process.

The wind turbine was then mounted onto a servo motor, enabling it to rotate based on wind direction data retrieved from the API.

#### 2.4.2 Sensors & MicroControllers: 
To capture real-time data on the wind turbine's performance, a _photoresistor_ sensor was strategically integrated into the model. This sensor, which does not include a light source itself, responds to the light generated by the wind turbine as it operates. The photoresistor converts the light intensity into a measurable voltage. This voltage data serves as a proxy for the actual power generated by the turbine.

The TwinTurbine prototype utilizes two microcontrollers: _Arduino Uno_ and _ESP32-S2-Thing Plus_. These microcontrollers operate in tandem to achieve efficient data transfer and control. The ESP32 fulfills the need for seamless Wi-Fi connectivity, allowing for hassle-free data transmission to the user environment without requiring additional setup.Arduino boasts a wider range of established libraries specifically designed for servo motor control, simplifying the implementation process in this project.

This Wi-Fi-enabled microcontroller ESP32, serves as the primary communication hub. It gathers data from the photoresistor sensor, which measures light intensity as a proxy for generated power. This data is then transmitted to the Unity environment using the WebSockets protocol, enabling real-time visualization. Additionally, the ESP32 receives wind direction data from Unity.Arduino Uno excels at servo motor control. It leverages readily available libraries to precisely control the wind turbine's rotation based on the wind direction data received from the ESP32.


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
