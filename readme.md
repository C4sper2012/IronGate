# The IronGate project

The future is now! Every home needs great security, and with great security, comes alot of sensors.

The IronGate Project secures your house with state of the art security tools like, MQTT notification, RFID card readers, Online status of electronics and so much more.

 <center><img style="width: 60%;" src="https://blog.gemalto.com/wp-content/uploads/2018/10/IoT-Home-Security.jpg"/></center>

## Technical information
 
| Sensor | Library | Author  | Version |
|--------|---------|---------|---------|
| DHT11  | DHT_Unified_Sensor| 1.4.4   |
| WLDSM  | None    | None    |  None   |

| Device | Library | Author  | Version |
|--------|---------|---------|---------|
| OLED   |   SSD1306 |Adafruit | 2.5.7 |
| OLED   | Adafruit GFX Library| 1.11.3|
| MQTT   | MQTT | Joel Gaehwiler | 2.5.0 |
| Servo  | Servo| Michael Margolis | 2.5.0 |




<h3>Jeg har lavet noget Technical setup, Tilføjelser/Rettelser?</h3>
/Tobias

## Technical setup "Working progress." 

### First floor:
- Climate monitoring in rooms.
- Window opening system(time based event?).
    - connected to in-door climate?
- Smart lighting.

### Ground floor:
- RFID Unlock/Lockdown (Affect all system systems).
    - Turns on selected lights
    - Closes all windows.

### Basement/Garage:

- Moisture monitoring(In case of flood when not home).
    - Alerts user?


### All levels:
- All Level has motions sensors that activates when alarm is armed.
- Main hub(HMI) to control the systems.
- Bluetooth redundancy if WiFi or MQTT fails?

<br>

---

- All peripherals at each level is hooked up to a mainboard using SPI or I2C.
- The mainboard uses SPI or I2C to connect to a second board with built-in WiFi and Bluetooth.
- The 3 WiFi boards communicate with each other using MQTT over WiFi. 

