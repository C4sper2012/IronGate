#ifndef KY037_H_
#define  KY037_H_

#include <Arduino.h>
#include "MQTT.h"

#define SOUNDSENSORPIN 6

bool soundIsActive();
void onDetectInterrupt();

#endif // KY037_H_
