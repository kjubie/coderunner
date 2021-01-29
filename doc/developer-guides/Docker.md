# Docker Dokumentation

In diesem Dokument befinden sich Information zur Dockerisierung von FHTW-Coderunner.

## Dockerfile

Im Dockerfile befinden sich die Instruktionen zum bauen des images.
Dabei entspricht das Dockerfile im Großen und Ganzen dem Standard Dockerfiletemplate für asp.net Applikationen, welches von Visual Studio automatisch generiert wird.

Es wurde Anfangs mittels Visual Studio mittels der "add docker support" Funktion generiert und danach ein wenig modifiziert.

### Build Phasen

Da wir vor diesem Projekt noch nicht mit Docker gearbeitet haben, hat uns die Aufteilung des Dockerfiles in verschiedene Phasen ein wenig verwirrt. Deswegen wollten wir an dieser Stelle unsere Erkenntnisse dazu festhalten.

Das aufteilen des Dockerfiles in mehrere Phasen ist eine Praxis die [multi-stage builds](https://docs.docker.com/develop/develop-images/multistage-build/) heißt. Es wird gemacht um die größe des Images gering zu halten und den Build Prozess zu optimieren, indem sich in jeder Build Phase nur jene Dinge im Image befinden, die auch benötigt werden. Zum Beispiel wird in der Build Phase (wo FROM * AS build steht) die Applikation gebuildet und in der Publish Phase nur die gebauten Dateien hinüberkopiert.

Das Alles ist an sich sehr nützlich, nur ist es besonders wichtig zu wissen wo, wann und welche Dateien wohin kopiert werden. Es gab bei uns mehrere Probleme bei denen Dateien zur Runtime zur Verfügung stehen sollten, diese aber nur zur Build Phase kopiert wurden.

### Base Images

Die Base Images sind die Umgebung in der die Applikation im Container läuft bzw. gebuildet wird. Am Anfang wurden die Images vom Standard Template verwendet.

```DockerFile
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
...
FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
...
```

Allerdings gab es ab Januar 2021 das Problem, dass die Microsoft Paket Zertifikate ausgelaufen sind und deswegen das publishen des Images nicht mehr möglich war. Wegen der Abgabe des Projektes am 29.01.2021 konnten wir nicht auf einen Fix von Microsoft warten und sind deswegen auf andere Images umgestiegen.

```DockerFile
FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
...
FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
...
```

Der genaue Unterschied zwischen den Images ist uns nicht bekannt außer, dass buster-slim Debian 10 und focal Ubuntu  20.04 als OS haben.

### Nodejs und Angular

Um FHTW-Coderunner starten zu können, muss zuerst nodejs und alle dependencies für Angular installiert werden. Das geschieht an zwei Stellen im Dockerfile.

```Dockerfile
RUN apt-get update -yq \
    && apt-get -yq install curl gnupg git \
    && curl -sL https://deb.nodesource.com/setup_12.x | bash \
	&& apt-get -yq install nodejs
```

Dieses Command wird sowohl beim aspnet Image, als auch beim sdk Image ausgeführt. Warum es an beiden Stellen benötigt wird ist nicht ganz klar, aber es hat vermutlich damit zu tun, dass nodejs sowohl im build image als auch im finalen image gebraucht wird. Die vorgehensweise wurde einem [Guide](https://medium.com/swlh/create-an-asp-net-core-3-0-angular-spa-web-application-with-docker-support-86e8c15796aa) entnommen.

### ClientApp im Container

Eines der ersten Probleme, welches beim dockerisieren aufgetreten ist ist, dass bei einem release build die Dateien zur ClientApp nicht in den Container kopiert wurden. Dieses Problem hat sich durch den Error:

```bash
...
npm ERR! path ClientApp/package.json
npm ERR! code ENOPACKAGEJSON
npm ERR! errno -2
npm ERR! syscall open

npm ERR! package.json ENOENT: no such file or directory, open    'ClientApp/package.json'
...
```

gezeigt. Der Auslöser des Problem ist vermutlich das falsche kopieren wie beim Kapitel "Build Phasen" erklärt. Um die Inhalte richtig zu kopieren, wurden folgende Zeilen bei der final Phase hinzugefügt:

```Dockerfile
...
COPY --from=build /src/ClientApp /app/ClientApp
WORKDIR /app/ClientApp
RUN npm install
WORKDIR /app
...
```

Dadurch wird der Ordner ClientApp vom Build Image zum Final Image kopiert.
Anschließend wird npm install ausgeführt, um die Dependencies zu installieren.

## DockerCompose

Um den Container mit der Datenbank Container zu starten wurde Unterstützung für docker compose zum Projekt hinzugefügt. Genau wie auch das Dockerfile wurde das docker-compose.yml von Visual Studio automatisch generiert. Zum automatischen generieren muss einfach im Context Menü `FHTW.CodeRunner.Services->Add->Container Orchestrator Support...` ausgewählt werden.

```
! Visual Studio erstellt neben dem docker-compose.yml auch ein docker-compose.override.yml
```

Zu den generierten Dateien wurden noch die Datenbank hinzugefügt und die jeweiligen Ports gesetzt.

## Zertifikat

! Das in diesem Absatz beschriebene Problem wurde gelöst, das Zertifikat wurde nicht in den Container kopiert.

Um die Applikation starten zu können, benötigt man ein SSL Zertifikat. Dafür wurde ein selbst signiertes development Zertifikat erstellt bzw das von Visual Studio erstellte Zertifikat exportiert. Dieses Zertifikat scheint aber nur zu funktionieren wenn `ASPNETCORE_ENVIRONMENT` auf `Development steht`.

Das Passwort zum Zertifikat steht in der `docker-compose.override.yml` Datei sollte es benötigt werden, bzw. kann jederzeit das Zertifikat mit einem neuen ersetzt werden.

## Volume Mounts

In den von Visual Studio erstellten `docker-compose.override.yml` werden normalerweise zwei Pfade in den Container gemountet.

```Dockerfile
- ${APPDATA}/Microsoft/UserSecrets:/root/.microsoft/usersecrets:ro
- ${APPDATA}/ASP.NET/Https:/root/.aspnet/https:ro
```

In diesem Pfaden befinden sich das benötigte developer Zertifikat und Passwort. Allerdings, weil wir das Zertifikat in den Container kopieren, benötigen wir sie nicht und haben sie entfernt um den Container auch auf Linux ausführen zu können.

## Mögliche Fehler

Beim containerisieren von FHTW-Coderunner sind teilweise Probleme aufgetreten, welche für uns nicht erklärbar bzw. reproduzierbar waren. Deswegen, sollten diese Fehler auftreten, sind sie hier dokumentiert.

### Hashsum Missmatch beim Image builden

Beim builden des Images ist es manchmal vorgekommen, dass während dem ausführen des `apt-get update` Commands zu einem Hashsum Missmatch Error gekommen ist und deswegen der build fehlschlägt.

Die Vermutung ist, dass das entweder an den Microsoft Images oder and den Ubuntu/Debian Repositorien liegt. Wenn dieser Fehler auftritt hat immer nur kurzes warten und erneutes ausführen geholfen.

### Nodejs installation schlägt fehl

Beim Builden kann es ebenfalls passieren, dass `+ apt-get install -y lsb-release > /dev/null 2>&1` während dem installieren von nodejs fehlschlägt.

Der Grund ist unbekannt und die Lösung ist die gleiche wie beim Hashsum Missmatch, kurzes warten und erneutes ausführen.

### Apt-Get Update Connection Failed

Beim häufigen builden des Images während des Troubleshootings ist es 2-mal vorgekommen, dass die Verbindung mit den Debian/Ubuntu Servern nicht mehr möglich war. Der Grund ist unbekannt und ein Neustart des Computers hat beide male funktioniert.

### ng serve Port Probleme

Dieses Problem ist beim starten des fertigen Containers aufgetreten. Beim start der Application hat SpaService ng serve mit einem random Port ausgeführt und weil dieser Port im Container nicht exposed war kam es zum Error (der Grund ist nur eine Vermutung). Beim Troubleshooting ist aufgefallen, dass im StartUp.cs `ng serve` ausgeführt wenn die Applikation in einem Developer Environment gestartet wird. Deswegen wurde temporär im `docker-compose.override.yml` die Variable `ASPNETCORE_ENVIRONMENT` auf `Production` gesetzt. Danach kam es aber zum Zertifikat Problem (siehe Zertifikat Kapitel) und es wurde zu Development zurückgesetzt. Aus irgendeinem unbekannten Grund trat das ng serve Problem danach nicht mehr auf. Die Docker Compose Dateien waren aber genau gleich, der einzige unterschied wahr, dass das dev Zertifikat hinzugefügt wurde (siehe Zertifikat Kapitel).

Sollte das Problem wieder auftreten kann versucht werden im `ClientApp/package.json` beim `ng serve` einen fixen, freien Port zu setzten.
