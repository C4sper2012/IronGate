# Projektbeskrivelse

**Navn:** Nicklas, Tobias og Casper

**Titel:** IronGate

### Introduktion

Internet of Things (IoT) refererer til ideen om at elektroniske apparaters tilstedeværesle, vil kunne effektivisere forskellige aspekter af vores hverdag, som både kan bruges kommercielt eller privat. 

Privat kan man benytte IoT til f.eks "Smart Home", sundhedsmonitorering, pleje osv. I forretningsmiljøet bruges Internet of Things blandt andet til automatisering, produktion, effektivisering af processer og transport & logistik.

IronGate er et proof of concept af et intelligent hus, et såkaldt "Smart home", hvor fokus ligger på sikkerhed og strømbesparelse.

IronGate benytter IoT og sensorere, som simulerer et miljø hvor man bygger mange komponenter sammen, for at opnå det som menes med "Intelligent". f.eks vil man med sit smart home, kunne spare penge fordi huset selv vil kunne regulere temperaturen når ingen er hjemme eller årstiden er sommer.

IronGate vil kunne benyttes som bolig og vil sikre ejeren i tilfælde af forsøg på indbrud ved at benytte bevægelses sensorer eller hvis huset er låst, vil det betragte aktivitet som mistænkelig og informere ejeren om aktiviteten og automatisk lukke vinduer og tænde lys.

IronGate er strømvenlig og vil kunne gå i low power mode, hvis det ønskes, for dermed at slukke alt monitorering.

### Projectmål

Projektet kommer til at bestå af 3 mindre projekter i form af forskellige etager i et hus, som skal kunne kommunikere med hinanden. 
Fælles for alle projekter er at de skal bruge et DHT11-modul så brugeren kan se temperatur og fugtighed på en telefon eller browser.

Forestil et hus med to etager og en kælder, hver etage har lys og varme i alle rum som bliver styret over husets netværk. Der er også automatiske vinduer i udvalgte rum, som åbner enten manuelt eller hvis temperatur eller fugtighed er for høj.

Alle projekter vil også have et eller flere specialer som vil være unik for det specifikke projekt.

#### 1. Etage

Vil have lyd sensor modul som skal kunne fortælle om børnene larmer og skal også kunne bruges til at kunne registrere mulige indbrudstyve når ejeren ikke er hjemme.

#### Stueetagen  

Vil have en bevægelsesensor som skal kunne tjekker for bevægelse udenfor huset og derefter lukke alle vinduer i huset for at kunne undgå tyveri. 
Stueetagen skal også have en hub til at vise statusbeskeder eller lys, den skal også kunne bruges til at styrer lys og andre moduler i huset.

#### Kælderen

Kældersystemet skal kunne alarmere brugeren om oversvømmelse ved hjælp fra et WLDS-modul. 


### Virkelige scenarier


1.	Dennis tager på arbejde og låser huset med sit ID-kort, dette slår alarmsystemet til, lukker alle vinduer hvis åbne og skruer ned for temperaturen i alle rum.

2.	Dennis er ikke hjemme en dag hvor der er høj sol med varme og hvis temperaturen bliver for høj vil vinduerne på første sal åbne sig en smule, men de åbner kun hvis Dennis aktivt har indstillet det.


### Checklists

Her kan man se og tracke fremgang på de forskellige små projecters mål.

##### 1. Etage
- [X] WIFI-modul (Forbindelse til MQTT netværket)
- [X] DHT11-modul (Temperatur og luftfugtighed)
- [X] SS-modul (Lydsensor)
- [X] Servo motor (Vinduer)
- [X] Kommunikation (MQTT)
- [X] HC-SR04 US sensor modul (Bevægelsesensor)

##### Stueetagen
- [X] WIFI-modul (Forbindelse til MQTT netværket)
- [X] DHT11-modul (Temperatur og luftfugtighed)
- [X] Servo motor (Vinduer)
- [X] Kommunikation (MQTT)
- [X] RFID-modul (Låsning/oplåsning)

##### Kælderen
- [X] WIFI-modul (Forbindelse til MQTT netværket)
- [X] DHT11-modul (Temperatur og luftfugtighed)
- [X] Servo motor (Vinduer)
- [X] WLDS-modul (Vandstandsregistreringsmodul)
- [X] Kommunikation (MQTT)

##### Hub
- [X] OLED (Skærm til hub)
- [X] Status LED
- [X] HUB menu
- [X] Kommunikation (Skal sættes sammen med stueetagen fysisk)
