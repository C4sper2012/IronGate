#ifndef DHT11_H_
#define DHT11_H_
#include <Arduino.h>
#include <DHT.h>
#define DHTPin 2

#define DHTTYPE DHT11

void initDHT();
int readTemp();
int readHum();

#endif /* DHT11_H_ */