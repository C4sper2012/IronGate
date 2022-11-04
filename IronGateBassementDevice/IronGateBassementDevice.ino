#include <WiFiNINA.h>
#include <utility/wifi_drv.h>
#include <MQTT.h>
#include <Adafruit_Sensor.h>
#include <DHT.h>
#include <Servo.h>
#include <Adafruit_SSD1306.h>
#include "secrets.h"

#define DHTPIN 7
#define DHTTYPE DHT11

#define POWER_PIN  1
#define SIGNAL_PIN A1
#define SENSOR_MIN 0
#define SENSOR_MAX 25

#define SCREEN_WIDTH 128
#define SCREEN_HEIGHT 64
#define OLED_RESET 4

const char ssid[] = SECRET_SSID;
const char pass[] = SECRET_PASS;

const char hostName[] = "mqtt3.thingspeak.com";
const char clientID[] = "CQ0EDQI2GxoiETYQEAAwEhE";
const char username[] = "CQ0EDQI2GxoiETYQEAAwEhE";
const char password[] = "ZZP3jZxHza3XO1XMJ4AFbk65";

WiFiClient net;
MQTTClient client;
Servo servoMotor;
DHT dht(DHTPIN, DHTTYPE);
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

unsigned long lastMillis = 0;
unsigned long waterSensorMillis = 0;

int pos = 0;

int level = 0;
int lastWaterLevel = level;

void connect() 
{
  Serial.print("checking for wifi ");
  Serial.print(SECRET_SSID);
  Serial.print("...");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(1000);
  }

  Serial.print("\nconnecting to ");
  Serial.print(hostName);
  Serial.print("...");
  while (!client.connect(clientID, username, password)) {
    Serial.print(".");
    delay(1000);
  }

  Serial.println("\nconnected!");

  client.subscribe("channels/1916369/subscribe/fields/field1");
  // client.unsubscribe("");
}

void messageReceived(String &topic, String &payload) 
{
  Serial.println("\nIncoming: " + topic + " - " + payload);

  if (payload == "1" && pos != 180) {
    for (pos = 0; pos <= 180; pos += 1) {
      servoMotor.write(pos);
      delay(15);
    }
  }
  else if (payload == "0" && pos != 0) {
  for (pos = 180; pos >= 0; pos -= 1) {
      servoMotor.write(pos);
      delay(15);
    }
  }
}

void setup() {
  Serial.begin(115200);

  WiFi.begin(ssid, pass);

  WiFiDrv::pinMode(25, OUTPUT); //Green
  WiFiDrv::pinMode(26, OUTPUT); //Red
  WiFiDrv::pinMode(27, OUTPUT); //Blue

  servoMotor.attach(8);

  pinMode(POWER_PIN, OUTPUT);

  client.begin(hostName, net);
  client.onMessage(messageReceived);

  dht.begin();
  connect();

  //Set the RGB to green
  WiFiDrv::analogWrite(25, 255);

  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) 
	{
		Serial.println(F("SSD1306 allocation failed"));
		for(;;);
	}

  //Diplay setting
  display.setTextSize(1);
  display.setTextColor(WHITE);
}

void loop() 
{
  client.loop();

  if (!client.connected()) {
    connect();
  }

  //Water level sensor
  if(millis() - waterSensorMillis > 20000) {
    waterSensorMillis = millis();

    digitalWrite(POWER_PIN, HIGH);
    delay(10);
    int value = analogRead(SIGNAL_PIN);
    digitalWrite(POWER_PIN, LOW);

    level = map(value, SENSOR_MIN, SENSOR_MAX, 0, 4);
    
    Serial.print("Water level: "); Serial.println(level);

    String payloadData = String("field1=" + String(level));

    //Checks the water level and notify the broker
    if(level < 1 && lastWaterLevel != level) {
      WiFiDrv::analogWrite(25, 255);
      WiFiDrv::analogWrite(26, 0);

      client.publish("channels/1916393/publish", payloadData, false, 0);
      Serial.print("Data send - "); Serial.println(payloadData);

      lastWaterLevel = level;
    }
    else if (level <= 2 && lastWaterLevel != level) {
      WiFiDrv::analogWrite(25, 255);
      WiFiDrv::analogWrite(26, 255);

      client.publish("channels/1916393/publish", payloadData, false, 0);
      Serial.print("Data send - "); Serial.println(payloadData);

      lastWaterLevel = level;      
    }
    else if (level > 2 && lastWaterLevel != level) {
      WiFiDrv::analogWrite(25, 0);
      WiFiDrv::analogWrite(26, 255);

      client.publish("channels/1916393/publish", payloadData, false, 0);
      Serial.print("Data send - "); Serial.println(payloadData);

      lastWaterLevel = level;
    }
  }

  //DHT11 sensor
  if (millis() - lastMillis > 60000) {
  lastMillis = millis();
  int t = dht.readTemperature();
  int h = dht.readHumidity();
  String payloadData = String("field1=" + String(t) + "&field2=" + String(h));

  client.publish("channels/1916370/publish", payloadData, false, 0);
  Serial.print("Data send - "); Serial.println(payloadData);
  }

  //OLED display
  display.clearDisplay();
  display.setCursor(0,0);
  display.println();
  display.print("Flood level: "); display.println(level);
  display.println();
  display.print("Temperatures: "); display.println(dht.readTemperature());
  display.println();
  display.print("Humidity: "); display.println(dht.readHumidity());
  display.display();
    
}