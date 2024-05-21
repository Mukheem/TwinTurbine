//Library
#include <WiFi.h>
//#include <ArduinoWebsockets.h>
#include <WebSockets2_Generic.h>


const char* ssid = "dsv-extrality-lab";            // Replace with your network SSID
const char* password = "expiring-unstuck-slider";  // Replace with your network password

const int photoPin = A1;  // Analog pin connected to the photoresistor
int lightValue = 0;       // Variable to store the light intensity

//using namespace websockets;  // Enable access to websockets classes & functions
using namespace websockets2_generic;
WebsocketsServer server;  // Initialize a WebSocket server
WebsocketsClient client;  // Initialize a WebSocket client

const int LED_PIN = 13;  // Pin number for LED
String currentMessage = "";
void setup() {
   Serial.begin(9600);   // Initialize serial communication
  Serial1.begin(9600);  // Initialize serial communication for communication with Arduino+
  Serial1.println(1);  
  Serial.println("Trying to Connect to WiFi");  // Print a message indicating an attempt to connect to WiFi
  WiFi.begin(ssid, password);                   // Trying to connect to WiFi
  // Trying to connect to WiFi within every 1 second until it get connected
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.println("Trying to Connect to WiFi");
  }
  Serial.println("Connected to WiFi");  // Print a message indicating WiFi connection is successful
  // Print Esp32 local IP Address
  Serial.print("IP Address: ");
  Serial.println(WiFi.localIP());
  server.listen(81);                   // Initialising websocket server on port 81
  Serial.print("Is server live? ");    // Print a message indicating whether the WebSocket server is active
  Serial.println(server.available());  // Print the number of available WebSocket connections

 
  pinMode(photoPin, INPUT);
}

void loop() {
  //Serial.println(touchRead(4)); //19708
  if (server.poll()) {  //server.poll() checks if any client is waiting to connect
    Serial.println("Client is available to connect...");
    client = server.accept();  // Accept() --> what server.accept does, is: "server, please wait until there is a client knocking on the door. when there is a client knocking, let him in and give me it's object".
    Serial.println("Client connected...");

    while (client.available()) {  // Loop while there is data available from the WebSocket client

      Serial.println("Waiting for client to send a message...");

      WebsocketsMessage msg = client.readNonBlocking();  //readBlocking(removes the need for calling poll()) will return the first message or event received. readBlocking can also return Ping, Pong and Close messages.
      currentMessage = msg.data();
      // log
      Serial.print("Got Message: ");
      Serial.println(msg.data());
      // Condition to blink the light at the start of program as a hello indication
      if (currentMessage.startsWith("Hello")) {
        for (int i = 0; i < 4; i++) {
          digitalWrite(LED_PIN, HIGH);  //Blink on
          delay(170);
          digitalWrite(LED_PIN, LOW);  //Blink off
        }
      }
      // Condition to take Degrees as inuput and rotate the wind turbine to that direction
      if (currentMessage.endsWith("take input")) {// message shhould be something like "180:take input"
        digitalWrite(LED_PIN, HIGH);
        int number = currentMessage.substring(0,2).toInt();  // Convert the input string to an integer

        // Sending the command to Arduino only if it's within a specific range
        if (number >= 0 && number <= 1500) {
          Serial.println("Sending command to Arduino: " + String(number));
          Serial1.println(number);  // Send the command to Arduino via Serial1
        } else {
          Serial.println("Invalid command. Please type a number between 0 and 1500.");
        }
        digitalWrite(LED_PIN, LOW);
      }

       // Original code to read analog value from photoresistor
      lightValue = analogRead(photoPin);  // Read analog value from photoresistor

      // Convert analog value to voltage
      float voltage = lightValue * (3.3 / 4096.0);  // Convert analog value to voltage (5V range)

      // Print voltage value to serial monitor
      //Serial.print("Analog Value: ");
      //Serial.println(lightValue);  // Print analog value to serial monitor
      //Serial.print("Voltage: ");
      //Serial.print(voltage, 3);  // Print voltage with 2 decimal places
      //Serial.println("V");       // Unit of measurement
      client.send("voltage:"+String(voltage));
      
    }

    // Cheking if WebSocket client is Disconnected from Esp32
    if (!client.available()) {
      Serial.println("Client Disconnected.");
    }
  }

}
  //----------------
void mina(){
  // Original code to read analog value from photoresistor
  lightValue = analogRead(photoPin);  // Read analog value from photoresistor

  // Convert analog value to voltage
  float voltage = lightValue * (3.3 / 4096.0);  // Convert analog value to voltage (5V range)

  // Print voltage value to serial monitor
  Serial.print("Analog Value: ");
  Serial.println(lightValue);  // Print analog value to serial monitor
  Serial.print("Voltage: ");
  Serial.print(voltage, 3);  // Print voltage with 2 decimal places
  Serial.println("V");       // Unit of measurement

  // Check if there is any input from the serial monitor
  if (Serial.available()) {
    String input = Serial.readStringUntil('\n');  // Read input from serial monitor
    input.trim();                                 // Remove leading and trailing whitespace

    // Check if the input consists only of numeric characters
    boolean isNumeric = true;
    for (size_t i = 0; i < input.length(); i++) {
      if (!isDigit(input[i])) {
        isNumeric = false;
        break;
      }
    }

    if (isNumeric) {
      int number = input.toInt();  // Convert the input string to an integer

      // Sending the command to Arduino only if it's within a specific range
      if (number >= 0 && number <= 1500) {
        Serial.println("Sending command to Arduino: " + String(number));
        Serial1.println(number);  // Send the command to Arduino via Serial1
      } else {
        Serial.println("Invalid command. Please type a number between 0 and 1500.");
      }
    } else {
      Serial.println("Invalid command. Please type a valid number.");
    }
  }

  delay(1000);  // Delay for readability
}
