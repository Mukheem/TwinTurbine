#include <Servo.h>

Servo myservo;
int neutralPos = 1520;  // Neutral position in microseconds
String readString;      // String to hold incoming data

void setup() {
  myservo.attach(7, 400, 2600); // Attach servo to pin 7
  Serial.begin(9600);           // Start serial communication at 9600 baud rate
  Serial.println("Servo control initialized.");
  Serial.println("Awaiting commands.");
  Serial.println("Type '1500x' to perform a 45-degree rotation.");
}

void perform45DegreeTurn() {
  int pulseSpeed = 1500; // Speed setting for 45-degree rotation
  myservo.writeMicroseconds(pulseSpeed);
  delay(2500); // Time for 45-degree turn
  myservo.writeMicroseconds(neutralPos); // Stop the servo by resetting to neutral
  Serial.println("45-degree turn executed and stopped.");
  Serial.println("Ready"); // Send confirmation message to ESP32
}

void loop() {
  while (Serial.available()) {
    char c = Serial.read(); // Read incoming character
    readString += c;        // Append it to the readString
    delay(2);               // Allow time for next character to arrive in buffer
  }

  if (readString.length() > 0) {
    // Trim whitespace and control characters
    readString.trim();

    Serial.println("Received: " + readString); // Echo what was received

    if (readString == "1500x") {
      perform45DegreeTurn(); // Perform the 45-degree turn
    } else {
      Serial.println("Invalid command. Please type '1500x' to execute a 45-degree turn.");
    }
    readString = ""; // Clear the string for new input
  }
}
