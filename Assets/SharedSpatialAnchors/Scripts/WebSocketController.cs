using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using WebSocketSharp;

public class WebSocketController : MonoBehaviour
{

    String esp32IPAddress = "10.204.0.244";
    String esp32WebsocketPort = "81";
    // Websocket Service
    public WebSocket ws;
 

    // Serial Port to which Arduino is connected
    SerialPort arduinoPort = new SerialPort("COM4", 115200);
    public float voltageValue = 0.0f;

    public void Start(){
        ConnectWithESP32();
        //narrationController.GetComponent<NarrationController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to connect ESP32
    public void ConnectWithESP32()
    {
        Debug.Log("Connecting Unity with ESP32 via Websockets...");
        ws = new WebSocket("ws://" + esp32IPAddress + ":" + esp32WebsocketPort);
        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket connected");
            ws.Send("Hello from Unity!");
            //ws.Send("Need input");
        };
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Received message: " + e.Data);
            voltageValue = float.Parse(e.Data.Split(':')[1]);
            //Voltage:180.0
            Debug.Log(e.Data.Split(':')[1]);
            if (e.Data.Equals("Start Narration", StringComparison.OrdinalIgnoreCase)){
               // narrationControllerScript.startNarration = true;
            }
          
        };
        ws.Connect();
        Debug.Log("Websocket state - " + ws.ReadyState);
    }




    //Closing websocket upon application quit
    void OnApplicationQuit()
    {
        ws.Close();
        Debug.Log("WebSocket closed on application exit");
    }
}
