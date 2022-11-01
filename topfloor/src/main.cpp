#include <Arduino.h>

int buttonpin = 6; // define D0 Sensor Interface
int val = 0;// define numeric variables val
void setup ()
{
  Serial.begin(9600);
  pinMode (LED_BUILTIN, OUTPUT) ;// define LED as output interface
  pinMode (buttonpin, INPUT) ;// output interface D0 is defined sensor
}
void loop ()
{
val = digitalRead(buttonpin);// digital interface will be assigned avalue of pin 3 to read val
Serial.println(val);
if (val == HIGH) // When the sound detection module detects a signal,LED flashes
{
digitalWrite (LED_BUILTIN, HIGH);
}
else
{
digitalWrite (LED_BUILTIN, LOW);
}
}