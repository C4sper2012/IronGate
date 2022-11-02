#include <Arduino.h>
#include "main.h"
//#include <../.pio/libdeps/mkrwifi1010/DHT sensor library/DHT.h>

void setup() {
  Serial.begin(9600);
  initDHT();
  // put your setup code here, to run once:
}

void loop() {
  Serial.print(readTemp());
  delay(2000);
  // put your main code here, to run repeatedly:
}