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

#define SECRET_SSID "SibirienAP"
#define SECRET_PASS "Siberia51244"

#define DHTPin 2
#define BUTTON 3
#define GREENLED 25
#define REDLED 26
#define BLUELED 27
#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 64
#define OLED_RESET 4

#define SS_PIN 13
#define RST_PIN 7//6
 
// extern const char hostName[] = "dandelionfoe677.cloud.shiftr.io";
// extern const char clientName[] = "arduino MKR 1010 LED and Temp";
// extern const char username[] = "dandelionfoe677";
// extern const char password[] = "avmhcvQMNAmNki4b";
extern const char hostName2[] = "mqtt3.thingspeak.com";
// extern const char clientName2[] = "FiY4CCM3FykaFS4HCQMsAQI";
// extern const char username2[] = "FiY4CCM3FykaFS4HCQMsAQI";
// extern const char password2[] = "dQQtXzEmULVutVCZ590F2oPv";


extern const char username3[] = "DgciLSs4AAUdCy8AAjsoFgE";
extern const char clientName3[] = "DgciLSs4AAUdCy8AAjsoFgE";
extern const char password3[] = "GYsbytl/X62bjKR9JbYHEsQP";

extern const char tempAndHumPubChannel[] = "channels/1916370/publish";
extern const char servoPubChannel[] = "channels/1916369/publish";

extern const char groundFloorWindow[] = "channels/1916369/subscribe/fields/field3";

extern const char basementTemp[] = "channels/1916370/subscribe/fields/field1";
extern const char basementHumid[] = "channels/1916370/subscribe/fields/field2";

extern const char localTemp[] = "channels/1916370/subscribe/fields/field4";
extern const char localHumid[] = "channels/1916370/subscribe/fields/field5";

extern const char firstfloorTemp[] = "channels/1916370/subscribe/fields/field7";
extern const char firstfloorHumid[] = "channels/1916370/subscribe/fields/field8";

extern const char motionChannel[] = "channels/1916393/subscribe/fields/field4";


