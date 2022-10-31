# The IronGate project

The future is now! Every home needs great security, and with great security, comes alot of sensors.

The IronGate Project secures your house with state of the art security tools like, MQTT notification, RFID card readers, Online status of electronics and so much more.

 <center><img style="width: 60%;" src="https://blog.gemalto.com/wp-content/uploads/2018/10/IoT-Home-Security.jpg"/></center>

## Documentaion

### Diagrams
#### Flow Chart
 <img src="https://github.com/C4sper2012/IronGate/blob/master/Documentation/Flowchart.png"/>
 <img src="https://github.com/C4sper2012/IronGate/blob/master/Documentation/HIPO.drawio.png"/>


### Technical information
 
| Sensor | Library | Author  | Version |
|--------|---------|---------|---------|
| DHT11  | DHT_Unified_Sensor| Adafruit | 1.4.4 |
| WLDSM  | None    | None    |  None   |

| Device | Library | Author  | Version |
|--------|---------|---------|---------|
| OLED   |   SSD1306 | Adafruit | 2.5.7 |
| OLED   | Adafruit GFX Library| Adafruit | 1.11.3 |
| MQTT   | MQTT | Joel Gaehwiler | 2.5.0 |
| Servo  | Servo| Michael Margolis | 2.5.0 |

### Technical setup

#### First floor
- Climate monitoring in room.
- Window opening system(Temp based).
    - connected to in-door climate.
- Smart lighting.

#### Ground floor
- RFID Unlock/Lockdown (Affect all systems).
    - Turns on selected lights
    - Closes all windows.

#### Basement

- Moisture/flood monitoring(In case of flood when not home).
    - Alerts users if any flooding is detected.
    - 


#### All levels:
- All Level has motions sensors that activates when alarm is armed.
- Main hub(HMI) to control the systems.
- Bluetooth redundancy if WiFi or MQTT fails?
- All peripherals at each level is hooked up to a mainboard using SPI or I2C.
- The mainboard uses SPI or I2C to connect to a second board with built-in WiFi and Bluetooth.
- The 3 WiFi boards communicate with each other using MQTT over WiFi. 

