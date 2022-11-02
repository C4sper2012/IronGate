# The IronGate project

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
| None | MQTT | Joel Gaehwiler | 2.5.0 |

### Permissions
This section contains information about what permissions the diffrent device have on the ThingSpeak broker.

#### First floor device
| Channel | Publish | Subscribe |
|---------|---------|-----------|
| 1916369 | | X |
| 1916370 | X | |
| 1916393 | X | |

#### Ground floor device
| Channel | Publish | Subscribe |
|---------|---------|-----------|
| 1916369 | X | X |
| 1916370 | X | X |
| 1916393 | X | X |

#### Bassement floor device
| Channel | Publish | Subscribe |
|---------|---------|-----------|
| 1916369 | | X |
| 1916370 | X | |
| 1916393 | X | |

#### Client test device
This device is only used for test purposes.

| Channel | Publish | Subscribe |
|---------|---------|-----------|
| 1916369 | X | X |
| 1916370 | X | X |
| 1916393 | X | X |

### Access
This section contains information about what credentials the diffrent devices is using.

#### First floor device
- Host = mqtt3.thingspeak.com
- Username = NAU4KRsqEB05FzIpJCUvBy0
- ClientId = NAU4KRsqEB05FzIpJCUvBy0
- Password = vbfXHSLyWjof5dsAFtkeccMh

#### Ground  floor device
- Host = mqtt3.thingspeak.com
- Username = DgciLSs4AAUdCy8AAjsoFgE
- ClientId = DgciLSs4AAUdCy8AAjsoFgE
- Password = GYsbytl/X62bjKR9JbYHEsQP

#### Bassement floor device
- Host = mqtt3.thingspeak.com
- Username = CQ0EDQI2GxoiETYQEAAwEhE
- ClientId = CQ0EDQI2GxoiETYQEAAwEhE
- Password = ZZP3jZxHza3XO1XMJ4AFbk65

#### Client test device
This device is only used for test purposes.

- Host = mqtt3.thingspeak.com
- Username = GCcqATMiOBASNBspJzkSMwI
- ClientId = GCcqATMiOBASNBspJzkSMwI
- Password = hSSRXoNF/co86QYUOwJVZ4jd

## Diagrams
### Psysical Architecture
![Psysical Architecture](Documentation/ArchitectureDiagram.drawio.png "Psysical Architecture")

### Flowcharts
This section contains the flowchart of the diffrent devices.

#### First floor device

#### Ground floor device
##### RFID access flowchart
![RFID Access Flowchart](Documentation/RFIDAccessFlowchart.png "RFID Access Flowchart")

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
