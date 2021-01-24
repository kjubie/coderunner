# DataAcces Layer

Nachfolgend werden einzelne Besonderheiten des Data Access Layer erläutert. Die zugehörigen Projekte beginnen mit `FHTW.CodeRunner.DataAccess`.

## Entity Framework Core

Für den Data Access wir das Entity Framework Core (v 5.0.2)verwendet.
Der dazugehörigen DbContext (CodeRunnerContext) befindet sich im `FHTW.CodeRunner.DataAccess.Sql` Projekt.
Die Entities wurden mittels der Database-First Methode erstellt und vom Framework automatisch generiert.

## PostgreSQL DB

Die PostgreSQL Datenbank wurde von dem Herrn Alexander Sus vorgegeben.
Sie läuft in einem einem Docker Container und kann deswegen während der Entwicklung leicht neu aufgesetzt werden, sollte es zu Problemen kommen. Genaueres zum Aufsetzen der Datenbank mit Docker steht im Setup Guide.

- PostgreSQL Version: 13
- Port: 5432 (Default)
- Datenbank: coderunnerdb
- User: postgres
- Password: admin (!nur für Entwicklungszwecke, vor dem Deploy ändern)

## Repository Pattern

Der Data Access wurde mit dem Repository Pattern umgesetzt. Alle DB queries laufen über die Repositories ab und sie sind auch somit das Interface zum BusinessLayer. Die Interfaces zu den Repositories befinden sich im `FHTW.CodeRunner.DataAccess.Interfaces` Project und die dazu gehörigen Implementierungen im `FHTW.CodeRunner.DataAccess.Sql` Projekt.

## Entities

Die Entities befinden sich im `FHTW.CodeRunner.DataAccess.Entities` Projekt. Weil die Entities automatisch generiert wurden, gibt es mehr Navigational Properties als eigentlich gebraucht sind. Diese Properties wurden behalten wegen der Möglichkeit, dass sie später noch verwendet werden könnten.

Genauere Informationen zu dem Aufbau der Entities befinden sich im Datenstruktur Dokument.

## Tests

Zum leichteren Testen des DataAccess Layers wurde ein Test Project hinzugefügt (`FHTW.CodeRunner.DataAccess.Tests`). Getestet wird in einer in-memory SQLite Database. Allerdings sind nicht alle Datenbankoperation, welche benötigt werden, von SQLite unterstützt. Deswegen wurde eine zweite Containerinstanz zum zusätzlichen testen erstellt und die mit SQLite nicht testbaren Testfälle auskommentiert. Wenn diese Testfälle getestet werden sollen muss zuerst die Test Datenbank hochgefahren werden. Genauere Information dazu befinden sich im Setup Guide.

Die uns bekannte Limitierung von SQLite ist das fehlen der APPLY Operation. Die APPLY Funktion wird von EF Core bei Projektionen verwendet. Deshalb können jene Queries welche Projection verwenden nicht mit SQLite getestet werden.

## Seed und Testdaten

Zum initialen befüllen der Datenbank mit benötigten Werten wie Programming Language, Written Language und Questiontype, als auch Testdaten (Exercises, Tags, Collection,...) wird die Datenbank mit Daten aus Json Dateien geseeded. Diese Dateien sind im Ordner `FHTW-CodeRunner\src\FHTW.CodeRunner.DataAccess.Sql\Resources` zu finden.
Die Logic zum seeden ist in `FHTW.CodeRunner.DataAccess.Sql.CodeRunnerContextExtension.cs` zu finden.

!! In der jetzigen Version der Applikation wird die Datenbank bei jedem Start geseeded. Vor dem finalen Deployment sollte das automatische seeden entfernt werden.

### Probleme beim Seeden

!! Das folgende Problem wurde mittlereweile gelöst. Zur Informationszwecken und für den Fall, dass es nochmal auftritt wurde die Erklärung des Problems in der Dokumentation beibehalten.

Beim seeden der Datenbank ist es vorgekommen, dass die von PostgreSQL generierten Ids nach dem seeden nichtmehr mit den Ids der Daten synchronisiert waren. Deswegen mussten die fixen Ids aus den Testdaten entfernt werden. Deswegen kann vor dem seeden nich tmehr einfach überprüft werden, ob die Testdaten bereits in der Datenbank sind. Aufgrund dessen muss die Datenbank beim neuen Aufsetzen explizit geseeded werden. Genauere Information dazu befinden sich im Setup Guide.

#### Lösung

Das Problem wurde gelöst indem nach dem seeden die id sequence explizit geupdated wird.

## Migrationen

Falls es gewollt ist, dass die Daten in der Datenbank beim ändern des Daten Schemas behaltet werden, wurde die Erstellung von Migrationen eingerichtet. Die Migrationen befinden sich im `FHTW.CodeRunner.Migrations` Projekt.
