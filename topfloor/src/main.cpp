#include "main.h"

void setup ()
{
  Serial.begin(9600);
  pinMode(LED_BUILTIN, OUTPUT);// define LED as output 
  pinMode(SOUNDSENSORPIN, INPUT_PULLUP);
  attachInterrupt(digitalPinToInterrupt(SOUNDSENSORPIN), onDetectInterrupt, FALLING);

  if(connectWiFi()) {
        WiFiDrv::analogWrite(RED, 0);
        WiFiDrv::analogWrite(GREEN, 255);
        WiFiDrv::analogWrite(BLUE, 0);
  }
}

void loop ()
{
  if(soundIsActive()){
    Serial.print("Motion Detected");
  }
  delay(1000);
}