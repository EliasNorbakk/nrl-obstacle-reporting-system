# FirstWebApplication1

# Obstacle Reporting (ASP.NET Core MVC + MariaDB + Leaflet)

En MVC-app som lar brukere registrere hinder med posisjon fra kart (Leaflet) og lagrer til en Reports database i en MariaDB-container.


# Arkitektur

UI: Razor Views (Tailwind)

Controller: ObstacleController (Håndterer GET/POST av skjema)

Data: ReportsRepository (Sender data til obstacledb.Reports i mariaDB)

Kart: Leaflet (markerer lat/lng ved museklikk på kartet, kan bruke click & drag funksjon på markøren etter plassering)

Database: MariaDB container (Lagrer innsendt data til en tabell kalt Reports)


# Reports table oppsett

ReportID: int (PK) (AI) (NN)

ObstacleName: varchar (NULL) 

ObstacleHeight: decimal (NULL)

ObstacleDescription: varchar (NULL)

ObstacleLocation: varchar (NULL)


# Drift med docker compose.

(Work-In-Progress)

Docker compose filen skal opprette to containere, en for web app serveren og en container med mariaDB med obstacledb database og ferdig Reports tabell.

1. Åpne terminal inne i prosjekt-mappen
2. Kjør "docker compose up --build" (Uten "")
3. Sjekk at containerene har blitt opprettet i docker
4. Åpne http://localhost:5173




# Testing

Scenario 1

- Bruker fyller ut skjema og trykker "Submit", data vises på "Overview" siden.

Scenario 2

- Bruker markerer punkt på kartet og kan sende inn lokasjon i rapporten. Kartposisjon lagres og vises på nytt i "Overview".

Scenario 3

- Applikasjonen tilpasses skjermstørrelse på enhet som er i bruk.


# Resultater

Etter å ha testet de tre scenarioene så er resultatet at alle på gruppen fikk prosjektet til å kjøre og fikk fullført hver sin rapport.
