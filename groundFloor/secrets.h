#pragma region Includes
#include <SPI.h>
#include <DHT.h>
#include <WiFiNINA.h>
#include <Adafruit_GFX.h>
#include <Adafruit_SSD1306.h>
#include <Servo.h>
#include <MQTT.h>
#include <MFRC522.h>
#include <ArduinoJson.h>
#include <Wire.h>
#pragma endregion

#pragma region WiFi credentials 
#define SECRET_SSID "SibirienAP"
#define SECRET_PASS "Siberia51244"
#pragma endregion

#define DHTPin 2
#define BUTTON 3
#define GREENLED 25
#define REDLED 26
#define BLUELED 27
#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 64
#define OLED_RESET 4
#define SS_PIN 13
#define RST_PIN 7

DHT dht(DHTPin, DHT11);

Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

MFRC522 mfrc522(SS_PIN, RST_PIN);

WiFiClient net;

MQTTClient client(500);

Servo servo;
 
unsigned long startMillis;
unsigned long currentMillis;
const unsigned long interval = 25000; // 25 sec.
//const unsigned long interval = 3600000; // 1 hour.

String baseTemp = "";
String baseHumid = "";
String groundTemp = "";
String groundHumid = "";
String firstTemp = "";
String firstHumid = "";

int state = 0;
int floorIndex = 0;

bool authenticated = false;

#pragma region Shiftr
// const char hostName[] = "dandelionfoe677.cloud.shiftr.io";
// const char clientName[] = "arduino MKR 1010 LED and Temp";
// const char username[] = "dandelionfoe677";
// const char password[] = "avmhcvQMNAmNki4b";

#pragma endregion


#pragma region Mosquitto MQTT

const char mosquittoHost[] = "10.135.16.65";
const char clientId[] = "GroundFloor Arduino";

// Subscribe and Publish channels
//###############################################################

//First Floor
const char firstFloorTemp[] = "Home/FirstFloor/Temp";
const char firstFloorHumid[] = "Home/FirstFloor/Humid";
const char firstFloorMotion[] = "Home/FirstFloor/Motion";
const char firstFloorSound[] = "Home/FirstFloor/Sound";
const char firstFloorWindow[] = "Home/FirstFloor/Window";

//Ground Floor
const char groundFloorTemp[] = "Home/GroundFloor/Temp";
const char groundFloorHumid[] = "Home/GroundFloor/Humid";
const char groundFloorWindow[] = "Home/GroundFloor/Window";

//Basement
const char basementTemp[] = "Home/Basement/Temp";
const char basementHumid[] = "Home/Basement/Humid";
const char basementWaterLevel[] = "Home/Basement/WaterLevel";
const char basementWindow[] = "Home/Basement/Window";

//###############################################################

#pragma endregion

#pragma region thingspeak

// const char hostName2[] = "mqtt3.thingspeak.com";

// const char clientName2[] = "FiY4CCM3FykaFS4HCQMsAQI";
// const char username2[] = "FiY4CCM3FykaFS4HCQMsAQI";
// const char password2[] = "dQQtXzEmULVutVCZ590F2oPv";

// const char username3[] = "DgciLSs4AAUdCy8AAjsoFgE";
// const char clientName3[] = "DgciLSs4AAUdCy8AAjsoFgE";
// const char password3[] = "GYsbytl/X62bjKR9JbYHEsQP";

// const char tempAndHumPubChannel[] = "channels/1916370/publish";
// const char servoPubChannel[] = "channels/1916369/publish";

// const char groundFloorWindow[] = "channels/1916369/subscribe/fields/field3";

// const char basementTemp[] = "channels/1916370/subscribe/fields/field1";
// const char basementHumid[] = "channels/1916370/subscribe/fields/field2";

// const char localTemp[] = "channels/1916370/subscribe/fields/field4";
// const char localHumid[] = "channels/1916370/subscribe/fields/field5";

// const char firstfloorTemp[] = "channels/1916370/subscribe/fields/field7";
// const char firstfloorHumid[] = "channels/1916370/subscribe/fields/field8";

// const char motionChannel[] = "channels/1916393/subscribe/fields/field4";

#pragma endregion
