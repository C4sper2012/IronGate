#include "topfloor.h"

WiFiClient net;
MQTTClient client(500);
DHT dht(DHTPIN, DHTTYPE);
Servo servo;
Adafruit_SSD1306 display(SCREEN_WIDTH, SCREEN_HEIGHT, &Wire, OLED_RESET);

void connect() {
  Serial.print("checking wifi...");

  if(WiFi.status() != WL_CONNECTED) {
    setLEDStatus(255, 0, 0);
    Serial.println("Could not connect to WiFi, please restart device.");
    while(true) {
    }
  }

  Serial.print("\nconnecting...");
  while (!client.connect("NAU4KRsqEB05FzIpJCUvBy0", "NAU4KRsqEB05FzIpJCUvBy0", "lDoIYJHbpSkvHVOXAO+eqa/M")) {
    Serial.print(".");
    delay(1000);
  }

  setLEDStatus(0, 0, 255);

  Serial.println("\nconnected!");

  client.subscribe(ServoChannel);
  Serial.print("Listening on ");
  Serial.print(ServoChannel);
}

void messageReceived(String &topic, String &payload) 
{
  setLEDStatus(255, 255,255);
  
  Serial.println("incoming: " + topic + " - " + payload);
  
  if (payload == "1") {
    for (int pos = 0; pos <= 180; pos += 1) {
      servo.write(pos);
      delay(10);
    }
    windowIsOpen = true;
  }
  else if (payload == "0") {
  for (int pos = 180; pos >= 0; pos -= 1) {
      servo.write(pos);
      delay(10);
    }
    windowIsOpen = false;
  }

  setLEDStatus(0, 0, 255);
}

void setup() {
  Serial.begin(9600);

  WiFiDrv::pinMode(GREEN, OUTPUT);  //define green pin
  WiFiDrv::pinMode(RED, OUTPUT);  //define red pin
  WiFiDrv::pinMode(BLUE, OUTPUT);  //define blue pin

  pinMode(SOUNDSENSORPIN, INPUT);
  pinMode(LED_BUILTIN, HIGH);
  pinMode(TRIGGERPIN, OUTPUT); // Sets the trigPin as an OUTPUT  
  pinMode(ECHOPIN, INPUT); // Sets the echoPin as an INPUT

  if(!display.begin(SSD1306_SWITCHCAPVCC, 0x3C)) 
	{ // Address for 128x64
		Serial.println(F("SSD1306 allocation failed"));
		for(;;); // Don't proceed, loop forever
	}

  servo.attach(SERVO);

  dht.begin();
  WiFi.begin(ssid, pass);

  client.begin("mqtt3.thingspeak.com", net);
  client.onMessage(messageReceived);

  connect();
}

void loop() {
  client.loop();

  if (!client.connected()) {
    connect();
  }

  // publish a message roughly every second.
  if (millis() - lastMillis > 60000) {

    lastMillis = millis();

    temperature = dht.readTemperature();
    humidity = dht.readHumidity();

    String query = "field7=";
    query.concat(temperature);
    query.concat("&field8=");
    query.concat(humidity);

    Serial.println(query);
    client.publish(TemperatureChannel, query);
  }

  if (millis() - lastSoundMillis > 20000) {

    lastSoundMillis = millis();

    if(digitalRead(SOUNDSENSORPIN)) {
       client.publish(SoundChannel, "field7=1");
    }
  }

  if (millis() - lastSRMillis > 20000) {
    long duration; // variable for the duration of sound wave travel
    int distance; // variable for the distance measurement

    // Clears the trigPin condition
    digitalWrite(TRIGGERPIN, LOW);
    delayMicroseconds(2);
    // Sets the trigPin HIGH (ACTIVE) for 10 microseconds
    digitalWrite(TRIGGERPIN, HIGH);
    delayMicroseconds(10);
    digitalWrite(TRIGGERPIN, LOW);
    // Reads the echoPin, returns the sound wave travel time in microseconds
    duration = pulseIn(ECHOPIN, HIGH);
    // Calculating the distance
    distance = duration * 0.034 / 2;

    if(distance < 30){
      display.clearDisplay();
      display.setTextSize(2); // Normal 1:1 pixel scale
      display.setTextColor(WHITE); // Draw white text
      display.setCursor(0,0); // Start at top-left corner
      display.print("Motion triggered!");
      display.display();
      if (windowIsOpen) {
      client.publish(ServoPublishChannel, "field1=0&field3=0&field5=0");
      client.publish(SoundChannel, "field4=1");
      windowIsOpen = false;
      lastSRMillis = millis();
      }
      

    }
    else {
      display.clearDisplay();
      display.setTextSize(2); // Normal 1:1 pixel scale
      display.setTextColor(WHITE); // Draw white text
      display.setCursor(0,0); // Start at top-left corner
      display.print("First floor: Ok");
      display.display();
      if (!windowIsOpen) {
      client.publish(ServoPublishChannel, "field1=1&field3=1&field5=1");
      windowIsOpen = true;
      }
    }
  }
}

void setLEDStatus(int red, int blue, int green){
  WiFiDrv::analogWrite(RED, red);
  WiFiDrv::analogWrite(GREEN, green);
  WiFiDrv::analogWrite(BLUE, blue);
}
