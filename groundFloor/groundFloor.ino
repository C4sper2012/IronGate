#include "secrets.h"


void setup() {
  Serial.begin(9600);
  SPI.begin();
  Wire.begin();
  mfrc522.PCD_Init();
  pinMode(BUTTON, INPUT);

  if (!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) {
      Serial.println(F("SSD1306 allocation failed"));
      while (true);
  }
  display.clearDisplay();
  display.setTextSize(1);
  display.setTextColor(WHITE);
  display.setCursor(0, 0);
  display.print("Please place Keycard: ");
  Serial.println("Please place keycard:");
  display.display();

  while (!authenticated) {
    readCard();
  } 
  WiFi.begin(SECRET_SSID, SECRET_PASS);
  dht.begin();
  servo.attach(1);
  
  WiFiDrv::pinMode(REDLED, OUTPUT);
  WiFiDrv::pinMode(BLUELED, OUTPUT);
  WiFiDrv::pinMode(GREENLED, OUTPUT);
  
  client.begin(mosquittoHost, net);
  client.onMessage(messageReceived);
  connect();
  openAllWindows();
}

void loop() {

  state = digitalRead(BUTTON);
  if(state == HIGH) {
    floorIndex++;
    delay(300);
    if (floorIndex > 2) {
      floorIndex = 0;
    }
  }
  client.loop();
  if (!client.connected()) {
    connect();
  }
  if (millis() - startMillis >= interval) {
    publishTempAndHum();
    startMillis = millis();
  }

  switch (floorIndex) {
    case 0:
    updateOLED("Basement.", baseTemp, baseHumid);
    break;
    case 1:
    updateOLED("Ground Floor.", groundTemp, groundHumid);
    break;
    case 2:
    updateOLED("First Floor.", firstTemp, firstHumid);
    break;
  }
}

void connect() {
  Serial.print("Checking wifi: ");
  Serial.print(SECRET_SSID);
  Serial.print(" ");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    WiFiDrv::digitalWrite(BLUELED, HIGH);
    delay(1000);
    WiFiDrv::digitalWrite(BLUELED, LOW);
    delay(1000);
  }

  connectMQTT();
  WiFiDrv::digitalWrite(GREENLED, HIGH);

  Serial.println("\nconnected!");
}

void messageReceived(String &topic, String &payload) {
  Serial.println(payload);
  Serial.println(topic);
  
  getPayload(topic, payload);

}

void getPayload(String topic, String payload) {

  if (topic == firstFloorMotion && payload == "1") {
    int motionDelay = millis();

    updateOledMotion();
    while (millis() < motionDelay + 3000) {}
  }
  if (topic == basementTemp) {
    baseTemp = payload;
  }
  if (topic == basementHumid) {
    baseHumid = payload;
  }
  if (topic == groundFloorTemp) {
    groundTemp = payload;
  }
  if (topic == groundFloorHumid) {
    groundHumid = payload;
  }
  if (topic == firstFloorTemp) {
    firstTemp = payload;
  }
  if (topic == firstFloorHumid) {
    firstHumid = payload;
  }
  if (topic == groundFloorWindow) {
    writeServo(payload);
  }
}

void updateOledMotion() {
  display.clearDisplay();
  display.setTextSize(1);
  display.setTextColor(WHITE);
  display.setCursor(0, 0);
  display.print("motion Detected!");
  display.display();
}

#pragma region TempAndHumid

void updateOLED(String displayHeader, String displayTemp, String displayHumid) {
    display.clearDisplay();
    display.setTextSize(1);
    display.setTextColor(WHITE);
    display.setCursor(0, 0);
    display.print(displayHeader);
    display.setCursor(0, 10);
    display.println("--------------------");
    display.setTextSize(2);
    display.setCursor(0, 20);
    display.print("Temp: ");
    display.print(displayTemp);
    display.write(248);
    display.setCursor(0, 40);
    display.print("Humid: ");
    display.print(displayHumid);
    display.print("%");
    display.display(); 
}

void publishTempAndHum() {
  int t = dht.readTemperature();
  int h = dht.readHumidity();
  String tempResult = "";
  String humidResult = "";
  tempResult += t;
  humidResult += h;
  Serial.println(tempResult);
  Serial.println(humidResult);
  client.publish(groundFloorTemp, tempResult);
  client.publish(groundFloorHumid, humidResult);
}

#pragma endregion

#pragma region MQTT 

void connectMQTT() {
  Serial.print("\nconnecting "); Serial.print(clientId); Serial.print(" To MQTT"); Serial.print(" ");
  while (!client.connect(clientId, username, password)) {
    Serial.print(".");
    delay(1000);
  }
#pragma region thingspeak subscribtions
  // while (!client.connect(clientName3, username3, password3)) {
  //   Serial.print(".");
  //   delay(1000);
  // }
  //client.subscribe("channels/1916370/subscribe");
#pragma endregion
  client.subscribe(firstFloorTemp);
  client.subscribe(firstFloorHumid);
  client.subscribe(firstFloorMotion);
  client.subscribe(firstFloorWindow);

  client.subscribe(groundFloorTemp);
  client.subscribe(groundFloorHumid);
  client.subscribe(groundFloorWindow);
  
  client.subscribe(basementTemp);
  client.subscribe(basementHumid);
  client.subscribe(basementWindow);
}

#pragma endregion

#pragma region RFID 

void readCard() {
  if ( ! mfrc522.PICC_IsNewCardPresent()) 
  {
    return;
  }
  // Select one of the cards
  if ( ! mfrc522.PICC_ReadCardSerial()) 
  {
    return;
  }
  //Show UID on serial monitor
  Serial.print("UID tag :");
  String content= "";
  byte letter;
  for (byte i = 0; i < mfrc522.uid.size; i++)
  {
     Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
     Serial.print(mfrc522.uid.uidByte[i], HEX);
     content.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " "));
     content.concat(String(mfrc522.uid.uidByte[i], HEX));
  }
  Serial.println();
  Serial.print("Message : ");
  content.toUpperCase();
  if (content.substring(1) == "40 2E 76 A5") //change here the UID of the card/cards that you want to give access
  {
    Serial.println("Authorized access");
    authenticated = true;
  }
 
 else   {
    Serial.println(" Access denied");
    delay(3000);
  }
}

#pragma endregion

#pragma region Window Controls

void openAllWindows() {
  client.publish(firstFloorWindow, "1");
  client.publish(groundFloorWindow, "1");
  client.publish(basementWindow, "1");
}

void closeAllWindows() {}

void writeServo(String value) {
  if (value == "1") {
    for (int pos = 0; pos <= 180; pos += 1) {
      servo.write(pos);
      delay(10);
    }
  }
  else if (value == "0") {
  for (int pos = 180; pos >= 0; pos -= 1) {
      servo.write(pos);
      delay(10);
    }
  }
}

#pragma endregion
