# Setup Guide

In diesem Guide wird erklärt wie man FHTW-Coderunner startet.

## Anforderungen

- .NET 5.0 oder höher
- Neuestes Visual Studio Update ist empfohlen
- Docker Desktop (Für Docker Engine und Compose)
- Nodejs 12.0 oder höher

## Allgemeine Schritte

### Npm Install

Um die node module zu installieren muss

```bash
...\FHTW-CodeRunner\src\FHTW.CodeRunner.Services\ClientApp> npm install
```

ausgeführt werden.

### Benutzer erstellen

Um Benutzer in der Datenbank zu seeden muss in `FHTW-CodeRunner\src\FHTW.CodeRunner.DataAccess.Sql\Resources\user.json` ein neuer Eintrag gemacht werden. Der benötigte Passwort Hash kann zum Beispiel auf https://sha512.online/ generiert werden.

## Starten mit Docker

### In Visual Studio

Um die Applikation als Container zu starten muss in Visual Studio das `docker-compose` Project durch Rechtsklick im SolutionExplorer als Startup Projekt ausgewählt werden. Sobald es ausgewählt ist, wird Visual Studio den Container bereits vorbereiten. Jetzt kann der Container durch klicken auf das `Docker Compose` Startsymbol gestartet werden. Das kann je nach Computer sehr lange dauern. Die dazugehörige Datenbank wird dabei automatisch mitgestartet.

### Aus der Cli mit build

Zum starten in Docker muss einfach nur folgendes Command ausgeführt werden:

```bash
...\FHTW-CodeRunner\src\FHTW.CodeRunner.Services\ClientApp> docker-compose up
```

Sollten Probleme auftreten kann unsere Docker Dokumentation zur Hilfe gezogen werden.

### Aus der Cli prebuild

Zum starten von einem prebuild Image muss einfach nur im Ordner `FHTW-CodeRunner/docker_release` `docker-compose up` ausgeführt werden.

## Normal starten

Wenn die Applikation auf dem eigenen Computer laufen soll, muss zuerst die Datenbank manuell gestartet werden. Dafür muss

```bash
...\FHTW-CodeRunner\database> docker-compose up
```

ausgeführt werden.

Danach kann `FHTW.CodeRunner.Service` im Solution Explorer als Startup Project ausgewählt werden. Jetzt muss nurnoch sichergestellt werden, dass rechts neben dem Startsymbol `FHTW.CodeRunner.Services` steht. Wenn das nicht der Fall ist, sollte im Dropdown-Menü mehr zur Auswahl stehen und die Applikation kann gestartet werden.

## Wichtige Tipps

### 1

Es kann nur eine Instanz der Datenbank laufen (es gibt eine beim Start von Docker und eine beim normalen starten). Mann kann einfach in der DockerDesktop den nicht benötigten Container löschen. Die testdb läuft auf einem anderen Port.
