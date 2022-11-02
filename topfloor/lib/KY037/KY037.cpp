#include "KY037.h"

unsigned long lastMillis = 0;

bool execute = false;

bool soundIsActive(){
    return digitalRead(SOUNDSENSORPIN);
}

void onDetectInterrupt()
{
  if(millis() > lastMillis + 5000){
    Serial.println("Sound Detected");
    lastMillis = millis();
  }
}