#include <Servo.h>

Servo myservo;
int neutralPos = 1520;  // Neutral position in microseconds
String readString;      // String to hold incoming data

void setup() {
  myservo.attach(7, 400, 2600);  // Attach servo to pin 7
  Serial.begin(9600);            // Start serial communication at 9600 baud rate
  Serial.println("Servo control initialized.");
  Serial.println("Awaiting commands.");
  Serial.println("Type an integer to perform a degree rotation.");
}

void performDegreeTurn(int inputMultiplier) { // Add delayMultiplier parameter here
  int degree = inputMultiplier * 28;
  int pulseSpeed = 1500;  // Speed setting for degree rotation
  myservo.writeMicroseconds(pulseSpeed);
  delay(degree);                            // Time for degree turn
  myservo.writeMicroseconds(neutralPos);  // Stop the servo by resetting to neutral
  Serial.println("degree turn executed and stopped.");
  Serial.println("Ready");  // Send confirmation message to ESP32
}

  int degree = 0; // Define the degree variable

void goToZeroDegree() {
  degree = 10080 - degree; // Subtract the current degree from 20160
}


void loop()
{
  while (Serial.available()) {
    char c = Serial.read();  // Read incoming character
    if (isdigit(c)) {        // Check if the character is a digit
      readString += c;       // If so, append it to the readString
    } else if (c == '\n') {  // Check if it's the end of the line
      // If so, process the received number
      int number = readString.toInt();  // Convert the string to an integer
      readString = "";                  // Clear the string for new input

      Serial.println("Received: " + String(number));  // Echo what was received

      // Perform actions based on the received number
      if (0 <= number && number <= 360) {
        goToZeroDegree();
        performDegreeTurn(number); // Pass the number as delayMultiplier
      } else {
        Serial.println("Invalid command. Please type '1500' to execute a degree turn.");
      }
    }
  }
}