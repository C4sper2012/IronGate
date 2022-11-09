#include <Arduino.h>
#include "DHT11.h"
#include <DHT.h>

DHT dht(DHTPin, DHTTYPE);

void initDHT() {
    dht.begin();
}

int readTemp() {
    int t = dht.readTemperature();
    return t;
}

int readHum() {
    int h = dht.readHumidity();
    return h;
}