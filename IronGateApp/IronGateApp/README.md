# IronGate App
## Introduction / Motivation
This is the companion app to the IronGate IOT system.

## Technical Details
This section contains information about the technical details og the project.

### API information

#### 1916369 - IronGate-WindowControl
##### Keys

- Write key = AWR4TJXORG6EG6IL
- Read key = F803W0EVFO7BK3GG

##### Examples
- Write a Channel Feed

    ```
    GET https://api.thingspeak.com/update?api_key=AWR4TJXORG6EG6IL&field1=0
    ```

- Read a Channel Feed

    ```
    GET https://api.thingspeak.com/channels/1916369/feeds.json?api_key=F803W0EVFO7BK3GG&results=2
    ```

- Read a Channel Field

    ```
    GET https://api.thingspeak.com/channels/1916369/fields/1.json?api_key=F803W0EVFO7BK3GG&results=2
    ```

- Read Channel Status Updates

    ```
    GET https://api.thingspeak.com/channels/1916369/status.json?api_key=F803W0EVFO7BK3GG
    ```

#### 1916370 - IronGate-TemperatureAndHumidity
##### Keys

- Write key = 967C4YZ7PEJP1SGD
- Read key = 0QYE3TAWD42POHP2

##### Examples
- Write a Channel Feed

    ``` 
    GET https://api.thingspeak.com/update?api_key=967C4YZ7PEJP1SGD&field1=0
    ``` 

- Read a Channel Feed

    ``` 
    GET https://api.thingspeak.com/channels/1916370/feeds.json?api_key=0QYE3TAWD42POHP2&results=2
    ``` 

- Read a Channel Field

    ``` 
    GET https://api.thingspeak.com/channels/1916370/fields/1.json?api_key=0QYE3TAWD42POHP2&results=2
    ``` 
- Read Channel Status Updates

    ```
    GET https://api.thingspeak.com/channels/1916370/status.json?api_key=0QYE3TAWD42POHP2
    ```

#### 1916393 - IronGate-Uncategorized
##### Keys

- Write key = C66ILQL62K6IY0Y8
- Read key = 5SUJCFNTGZ25ODE6

##### Examples
- Write a Channel Feed

    ```
    GET https://api.thingspeak.com/update?api_key=C66ILQL62K6IY0Y8&field1=0
    ```

- Read a Channel Feed

    ```
    GET https://api.thingspeak.com/channels/1916393/feeds.json?api_key=5SUJCFNTGZ25ODE6&results=2
    ```

- Read a Channel Field

    ```
    GET https://api.thingspeak.com/channels/1916393/fields/1.json?api_key=5SUJCFNTGZ25ODE6&results=2
    ```

- Read Channel Status Updates

    ```
    GET https://api.thingspeak.com/channels/1916393/status.json?api_key=5SUJCFNTGZ25ODE6
    ```l

### Nuget packages
|Name|Version|
|----|-------|
|CommunityToolkit.Mvvm | 8.0.0|
|Polly | 7.2.3|
|sqlite-net-pcl|1.8.116|
|SQLitePCLRaw.bundle_green|2.1.2|
|Newtonsoft.Json| 13.0.1 |


## Psysical Architecture

## Use of third party libraries
The diagram, images and flowcharts was created in [Draw.io](https://www.draw.io).

## Responsible People
|Name|Role|
|----|----|
|Nicklas|Developer|
|Casper|Developer|
|Tobias|Developer|
