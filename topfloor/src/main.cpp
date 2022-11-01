#include "main.h"

void setup ()
{
  Serial.begin(9600);
  pinMode (LED_BUILTIN, OUTPUT) ;// define LED as output 
  pinMode (SOUNDSENSORPIN, INPUT) ;// define LED as output 

}
void loop ()
{
  Serial.print(soundIsActive());
}