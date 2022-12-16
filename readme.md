# The IronGate Project

The future is now! Every home needs great security, and with great security, comes alot of sensors.

The IronGate Project secures your house with state of the art security tools like, MQTT notification, RFID card readers, Online status of electronics and so much more.

 <center><img style="width: 60%;" src="https://blog.gemalto.com/wp-content/uploads/2018/10/IoT-Home-Security.jpg"/></center>

## Goals
Find these under [ProjektFormulering.md](ProjektFormulering.md)

## Technical Details
### Libraries
This section contains information about what libraries the different devices uses.

#### First floor device
| Part | Library | Author  | Version |
|------|---------|---------|---------|
| MKR Wifi 1010 | WifiNINA | Arduino | 1.8.13 |
| DHT11 | Adafruit Unified Sensor | Adafruit | 1.1.6 |
| DHT11 | DHT sensor library | Adafruit | 1.4.4 |
| Servo | Adafruit SoftServo | Adafruit | 1.0.2 |
| None | MQTT | Joel Gaehwiler | 2.5.0 |
| None | ArduinoJson | Benoit Blanchon | 6.19.4 |
| OLED | Addafruit SSD1306 | Adafruit | 2.5.6 |
| OLED | Adafruit GFX Library | Adafruit | 1.11.3 |

#### Ground floor device
| Part | Library | Author  | Version |
|------|---------|---------|---------|
| MKR Wifi 1010 | WifiNINA | Arduino | 1.8.13 |
| DHT11 | Adafruit Unified Sensor | Adafruit | 1.1.6 |
| DHT11 | DHT sensor library | Adafruit | 1.4.4 |
| Servo | Adafruit SoftServo | Adafruit | 1.0.2 |
| None | MQTT | Joel Gaehwiler | 2.5.0 |

#### Bassement floor device
| Part | Library | Author  | Version |
|------|---------|---------|---------|
| MKR Wifi 1010 | WifiNINA | Arduino | 1.8.13 |
| DHT11 | Adafruit Unified Sensor | Adafruit | 1.1.6 |
| DHT11 | DHT sensor library | Adafruit | 1.4.4 |
| Servo | Adafruit SoftServo | Adafruit | 1.0.2 |
| OLED | Addafruit SSD1306 | Adafruit | 2.5.6 |
| None | MQTT | Joel Gaehwiler | 2.5.0 |

## MQTT Broker (New)

### Topic descriptions
This section contains descriptions about all the topics the devices use.

#### IronGate-WindowControl
The *windows* channel is the IronGate window control channel and is used by the diffrent devices to subscribe and listen to.

## Thingspeak (Deprecated)

### Channel descriptions
This section contains descriptions about all the channels the devices uses.

#### 1916369 - IronGate-WindowControl
The *1916369* channel is the IronGate window control channel and is used by the diffrent devices to subscribe and listen to.

The only devices that also has publish permission on this channel is the **Ground floor device**, **First floor device** and the **Client test device**.

#### 1916370 - IronGate-TemperatureAndHumidity
The *1916370* channel is the IronGate temperatures and humidity channel and is used by all devices to publish their temperatures and humidity data to.

The only devices that can subscribe to this channel is the **Ground floor device** and the **Client test device**.

#### 1916393 - IronGate-Uncategorized
The *1916393* channel is the IronGate uncategorized data channel and is used for specific data like the *WLDS-Modul* water level and the *SS-Modul* sound detected data.

The only devices that can subscribe to this channel is the **Ground floor device** and the **Client test device**.

#### Topics

| FirstFloor | Purpose |
|----------- | --------|
| Home/FirstFloor/Temp | Temperature data | 
| Home/FirstFloor/Humid | Humidity data |
| Home/FirstFloor/Motion | Motion sensor data |
| Home/FirstFloor/Sound | Sound sensor data |
| Home/FirstFloor/Window |Servo controls |

| GroundFloor | Purpose |
| -------------- | ------ |
| Home/GroundFloor/Temp | Temperature data |
| Home/GroundFloor/Humid | Humidity data |
| Home/GroundFloor/Window | Servo controls |

| Basement | Purpose | 
| ---------| ------- | 
| Home/Basement/Temp | Temperature data |
| Home/Basement/Humid | Humidity data | 
| Home/Basement/WaterLevel | Water level data |
| Home/Basement/Window | Servo controls |

### Access
This section contains information about what credentials the diffrent devices is using.

#### First floor device
- Host = 10.135.16.65
- Username = IronGate
- ClientId = FirstFloor_Arduino
- Password = Qjc2WZFw

#### Ground  floor device
- Host = 10.135.16.65
- Username = IronGate
- ClientId = GroundFloor_Arduino
- Password = Qjc2WZFw

#### Bassement floor device
- Host = 10.135.16.65
- Username = IronGate
- ClientId = Basement_Arduino
- Password = Qjc2WZFw

## Diagrams
### Psysical Architecture
![Psysical Architecture](Documentation/ArchitectureDiagram.drawio.png "Psysical Architecture")

### Flowcharts
This section contains the flowchart of the diffrent devices.

#### First floor device

#### Ground floor device
##### RFID access flowchart
![RFID Access Flowchart](Documentation/RFIDAccessFlowchart.png "RFID Access Flowchart")

##### RFID simplified flowchart
![RFID simplified flowchart](Documentation/RFID.drawio.png "RFID simplified flowchart")

##### Climate control flowchart
![Climate control flowchart](Documentation/Climate.drawio.png "Climate control flowchart")

##### HIPO flowchart
![HIPO](Documentation/HIPO.drawio.png "HIPO")
#### Bassement floor device
##### Water level sensor flowchart
![Water Level Sensor Flowchart](Documentation/WaterLevelSensorFlowchart.png "Water Level Sensor Flowchart")

## Use of third party apps and libraries
The diagram, images and flowcharts was created in [Draw.io](https://www.draw.io).

## Responsibles  
|Name|Role|
|----|----|
|Nicklas|Developer|
|Casper|Developer|
|Tobias|Developer|
