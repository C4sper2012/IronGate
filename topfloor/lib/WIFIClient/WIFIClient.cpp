#include "WIFIClient.h"

WiFiClient net;

bool connectWiFi(){
    WiFi.begin(ssid, pass);
    if(WiFi.status() != WL_CONNECTED){
      return false;
    }
    else  {
      return true;
    }
}