void setup() {
  Serial.begin(9600); // Start serial communication at 9600 baud rate
  Serial1.begin(9600); // Start serial communication with Arduino
  delay(1000);         // Allow time for serial monitor to initialize
  Serial.println("Ready to send commands to Arduino.");
}

void loop() {
  if (Serial.available()) {
    String input = Serial.readStringUntil('\n'); // Read input from serial monitor
    input.trim(); // Remove leading and trailing whitespace

    if (input == "1500x") {
      Serial.println("Sending command to Arduino: " + input);
      Serial1.println(input); // Send the command to Arduino via Serial1
    } else {
      Serial.println("Invalid command. Please type '1500x' to send the command to Arduino.");
    }
  }
}
