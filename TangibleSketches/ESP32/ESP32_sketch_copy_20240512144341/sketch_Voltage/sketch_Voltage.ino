const int photoPin = A0; // Analog pin connected to the photoresistor
int lightValue = 0; // Variable to store the light intensity

void setup() {
  Serial.begin(9600); // Initialize serial communication
  Serial1.begin(9600); // Initialize serial communication for communication with Arduino
}

void loop() {
  // Original code to read analog value from photoresistor
  lightValue = analogRead(photoPin); // Read analog value from photoresistor
  
  // Convert analog value to voltage
  float voltage = lightValue * (5.0 / 1023.0); // Convert analog value to voltage (5V range)
  
  // Print voltage value to serial monitor
  Serial.print("Analog Value: ");
  Serial.println(lightValue); // Print analog value to serial monitor
  Serial.print("Voltage: ");
  Serial.print(voltage, 2); // Print voltage with 2 decimal places
  Serial.println("V"); // Unit of measurement
  
  // Check if there is any input from the serial monitor
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
        Serial.println("Invalid command. Please type a number between 0 and 1500.");
      }
    } else {
      Serial.println("Invalid command. Please type a valid number.");
    }
  }

  delay(1000); // Delay for readability
}
