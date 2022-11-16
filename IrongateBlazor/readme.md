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
