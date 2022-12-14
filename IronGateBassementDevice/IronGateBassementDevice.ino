#include "includes.h"
#include "secrets.h"
#include "defines.h"

WiFiClient net;
MQTTClient client;
Servo servoMotor;
DHT dht(DHTPIN, DHTTYPE);
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

//Millis variables
unsigned long lastMillis = 0;
unsigned long waterSensorMillis = 0;

//Servo variables
int pos = 0;

//Water level variables
int level = 0;
int lastWaterLevel = level;

void connect() 
{
  Serial.print(String("checking for wifi " + String(SECRET_SSID) + "..."));
  while (WiFi.status() != WL_CONNECTED) {
    //Set the RGB to red
    WiFiDrv::analogWrite(26, 255);
    Serial.print(".");
    delay(1000);
    WiFiDrv::analogWrite(26, 0);
    delay(1000);
  }

  Serial.print("\nconnecting to ");
  Serial.print(SECRET_hostName);
  Serial.print("...");
  while (!client.connect(SECRET_clientID, SECRET_username, SECRET_password)) {
    //Set the RGB to yellow
    WiFiDrv::analogWrite(25, 255);
    WiFiDrv::analogWrite(26, 255);
    Serial.print(".");
    delay(1000);
    WiFiDrv::analogWrite(25, 0);
    WiFiDrv::analogWrite(26, 0);
    delay(1000);
  }

  Serial.println("\nconnected!");
  
  //Set the RGB to green
  WiFiDrv::analogWrite(25, 255);

  client.subscribe("Home/Basement/Window");
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

//Send messages
void sendMessage(String restTopic , String payload, bool retained = false, int qos = 0) 
{
  String fullTopic = String("Home/Basement/" + restTopic);
  client.publish(fullTopic, payload, retained, qos);
  Serial.println(String("Data send - " + payload));
  Serial.println(String("Topic - " + fullTopic));
}

//Update OLED display
void updateOLED()
{
  display.clearDisplay();
  display.setCursor(0,0);
  display.print(String("Flood level: " + String(level)));
  display.setCursor(0,28);
  display.print(String("Temperatures: " + String(dht.readTemperature())));
  display.setCursor(0,56);
  display.print(String("Humidity: " + String(dht.readHumidity())));
  display.display();
}

//Checks the water level
void checkWaterLevel()
{
  digitalWrite(POWER_PIN, HIGH);
  delay(10);
  int value = analogRead(SIGNAL_PIN);
  digitalWrite(POWER_PIN, LOW);

  level = map(value, SENSOR_MIN, SENSOR_MAX, 0, 4);
    
  //Checks the water level and notify the broker
  if(level < 1) {
    WiFiDrv::analogWrite(25, 255);
    WiFiDrv::analogWrite(26, 0);
  }
  else if (level <= 3) {
    WiFiDrv::analogWrite(25, 255);
    WiFiDrv::analogWrite(26, 255);
  }
  else if (level >= 4) {
    WiFiDrv::analogWrite(25, 0);
    WiFiDrv::analogWrite(26, 255);
  }
    
  if (lastWaterLevel != level) {
    lastWaterLevel = level;
    sendMessage("WaterLevel", String(level));
  }
}

//Checks the Humidity and Temperatures
void checkTempsAndHumi()
{
  int t = dht.readTemperature();
  int h = dht.readHumidity();

  sendMessage("Temp", String(t));
  sendMessage("Humid", String(h));  
}

void setup() {
  Serial.begin(115200);

  //Wifi settings
  WiFi.begin(SECRET_SSID, SECRET_PASS);

  //LED pins
  WiFiDrv::pinMode(25, OUTPUT); //Green
  WiFiDrv::pinMode(26, OUTPUT); //Red
  WiFiDrv::pinMode(27, OUTPUT); //Blue

  //Servo pin
  servoMotor.attach(8);

  //Client settings
  client.begin(SECRET_hostName, net);
  client.onMessage(messageReceived);

  //Diplay setting
  display.setTextSize(1);
  display.setTextColor(WHITE);

  pinMode(POWER_PIN, OUTPUT);
  dht.begin();
  connect();

  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) 
	{
		Serial.println(F("SSD1306 allocation failed"));
		for(;;);
	}
}

void loop() 
{
  //Client
  client.loop();
  if (!client.connected()) {
    connect();
  }

  //Water level sensor
  if(millis() - waterSensorMillis > 20000) {
    waterSensorMillis = millis();
    checkWaterLevel();
  }

  //DHT11 sensor
  if (millis() - lastMillis > 60000) {
    lastMillis = millis();
    checkTempsAndHumi();
  }

  //Updates the OLED
  updateOLED();
}