# BLAZOR

## API
| Item | Endpoint | Returns|Remarks|Datatype|
|------|----------|--------|-------|---------|
|Climate|/all     | List of Climate|Gets all entries| None|
|Climate|/all/take| List of Climate|Starts at first entry and returns x amount of entries depending on take|Int32|
|Climate|/id      | Single Climate | Gets single entry with that ID| Int32|
|Climate|/date    | List of Climate| Gets all entry of that date|Datetime specified in [RFC3339 Section5.6](https://www.rfc-editor.org/rfc/rfc3339#section-5.6)   TL;DR 2015-11-20T00:00:00Z |
|Climate|/from&To | List of Climate| Gets all entries from date to enddate| Datetime specified in [RFC3339 Section5.6](https://www.rfc-editor.org/rfc/rfc3339#section-5.6)   TL;DR 2015-11-20T00:00:00Z |

| Item | Endpoint | Returns|Remarks| Datatype|
|------|----------|--------|-------|---------|
|MotionSensor|/all     | List of MotionSensor|Gets all entries| None|
|MotionSensor|/all/take| List of MotionSensor|Starts at first entry and returns x amount of entries depending on take| Int32|
|MotionSensor|/id      | Single MotionSensor | Gets single entry with that ID|Int32|
|MotionSensor|/date    | List of MotionSensor| Gets all entry of that date| Datetime specified in [RFC3339 Section5.6](https://www.rfc-editor.org/rfc/rfc3339#section-5.6)   TL;DR 2015-11-20T00:00:00Z |
|MotionSensor|/from&To | List of MotionSensor| Gets all entries from date to enddate|Datetime specified in [RFC3339 Section5.6](https://www.rfc-editor.org/rfc/rfc3339#section-5.6)   TL;DR 2015-11-20T00:00:00Z | 

