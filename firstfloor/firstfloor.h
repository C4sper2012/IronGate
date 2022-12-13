#ifndef FIRSTFLOOR_H_
#define FIRSTFLOOR_H_

#include <SPI.h>
#include <WiFiNINA.h>
#include <MQTT.h>
#include <DHT.h>
#include <Wire.h>  // I2C Library
#include <utility/wifi_drv.h>
#include <Servo.h>
#include <Adafruit_GFX.h> // Adafruit OLED Display
#include <Adafruit_SSD1306.h> // Adafruit OLED Display

#define DHTTYPE DHT11
#define DHTPIN 2
#define SOUNDSENSORPIN 7
#define ECHOPIN 1 // attach pin D2 Arduino to pin Echo of HC-SR04
#define TRIGGERPIN 0 //attach pin D3 Arduino to pin Trig of HC-SR04

#define GREEN 25
#define RED 26
#define BLUE 27
#define SERVO A5

#define OLED_RESET 4 // Reset pin # (or -1 if sharing Arduino reset pin)
#define SCREEN_WIDTH 128 // OLED display width, in pixels
#define SCREEN_HEIGHT 64 // OLED display height, in pixels

// Mosquitto broker
const char mosquittoHost[] = "10.135.16.65";

const char firstFloorTemp[] = "Home/FirstFloor/Temp";
const char firstFloorHumid[] = "Home/FirstFloor/Humid";
const char firstFloorMotion[] = "Home/FirstFloor/Motion";
const char firstFloorWindow[] = "Home/FirstFloor/Window";
const char firstFloorSound[] = "Home/FirstFloor/Sound"; 

const char groundFloorWindow[] = "Home/GroundFloor/Window";
const char basementWindow[] = "Home/Basement/Window";

#pragma region Thingspeak

// Thingspeak
// const char ServoChannel[] = "channels/1916369/subscribe/fields/field5";
// const char ServoPublishChannel[] = "channels/1916369/publish";
// const char TemperatureChannel[] = "channels/1916370/publish";
// const char SoundChannel[] = "channels/1916393/publish";

#pragma endregion
const char ssid[] = "SibirienAP";
const char pass[] = "Siberia51244";

unsigned long lastMillis = 0;
unsigned long lastSoundMillis = 0;
unsigned long lastSRMillis = 0;

int temperature = 0;
int humidity = 0;

bool windowIsOpen = false;

#endif /* FIRSTFLOOR_H_ */
