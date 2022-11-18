# Irongate Web

## Requirements
- [ ] Collect data from thingspeak and display graph
- [X] Option to select start and end date timestamp for data
- [ ] Option to control servo from MQTT
### Webapi
- [X] Create web api that collects data from thingspeak and stores it in a database
- [ ] Mobile app uses web api to communicate rather than thingspeak
- [ ] WebApi benytter en background service til at hente data fra Thingspeak.

### Authentication
- [X] Blaozr utilize authentication as security
- [ ] Only auhtenticated users with read permission can call web api
- [ ] Users with write permissions are allowed to delete data on web api

<br>

### WebAPI

[Link to WebAPI README.md](https://github.com/C4sper2012/IrongateWebAPI/blob/develop/README.md)

<br>

## Auth0  

Settings for Auth0 in the project can be found under 

```
IronGate/IrongateBlazor/Irongate.Blazor/appsettings.json
```

```json
    "Auth0": {
    "Domain": "",
    "ClientId": "",
    "ClientSecret": ""
  }
```
Credetials be found under Settings in https://manage.auth0.com 

<br>

###  Roles 
|Name | Description|
|-----|------------|
|IronGate-Admin| The role allows both Read & Write|
|IronGate-Read| The IronGate Read role|
|IronGate-Write| The IronGate Write role|


### Link to Dashboard:

[Dashboard](https://manage.auth0.com/dashboard/eu/iron-gate/applications)

### URLS:

- Callback: ``` /callback ```

- Allowed Logout URLs: ```/```

<br>

## MQTT 

Settings can be found under:

```
IronGate/IrongateBlazor/Irongate.Blazor/appsettings.json
```

Below is MQTT settings for windows on all floors. 

```json
"Thingspeak": {
    "WindowControls": {
      "FirstFloor": {
        "Broker": "mqtt3.thingspeak.com",
        "Port": "1883",
        "ClientId": "",
        "Username": "",
        "Password": "",
        "Topic": "channels/1916369/publish/fields/field5"
      },
      "GroundFloor": {
        "Broker": "mqtt3.thingspeak.com",
        "Port": "1883",
        "ClientId": "",
        "Username": "",
        "Password": "",
        "Topic": "channels/1916369/publish/fields/field3"

      },
      "Basement": {
        "Broker": "mqtt3.thingspeak.com",
        "Port": "1883",
        "ClientId": "",
        "Username": "",
        "Password": "",
        "Topic": "channels/1916369/publish/fields/field1"

      }
```

