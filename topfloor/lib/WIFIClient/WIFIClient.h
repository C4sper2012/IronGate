#ifndef WIFIClient_H_
#define WIFIClient_H_

#include <WiFiNINA.h>
#include <Arduino.h>

bool connectWiFi();
extern WiFiClient net;

const char ssid[] = "SibirienAP";
const char pass[] = "Siberia51244";


#endif /* WIFIClient_H_ */