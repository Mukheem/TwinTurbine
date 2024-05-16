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

    // Check if the input consists only of numeric characters
    boolean isNumeric = true;
    for (size_t i = 0; i < input.length(); i++) {
      if (!isDigit(input[i])) {
        isNumeric = false;
        break;
      }
    }

    if (isNumeric) {
      int number = input.toInt(); // Convert the input string to an integer

      // Sending the command to Arduino only if it's within a specific range
      if (number >= 0 && number <= 1500) {
        Serial.println("Sending command to Arduino: " + String(number));
        Serial1.println(number); // Send the command to Arduino via Serial1
      } else {
        Serial.println("Invalid command. Please type a number between 0 and 9999.");
      }
    } else {
      Serial.println("Invalid command. Please type a valid number.");
    }
  }
}
