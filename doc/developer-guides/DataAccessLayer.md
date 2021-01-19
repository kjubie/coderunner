# DataAcces Layer

Nachfolgend werden einzelne Besonderheiten des Service Layer erläutert. Die zugehörigen Projekte beginnen mit `FHTW.CodeRunner.DataAccess`.

## Entity Framework Core

Für den Data Access wir das Entity Framework Core (v 5.0.2)verwendet.
Der dazugehörigen DbContext (CodeRunnerContext) befindet sich im `FHTW.CodeRunner.DataAccess.Sql` Projekt.
Die Entities wurden mittels der Database-First Methode erstellt und vom Framework automatisch generiert.

## PostgreSQL DB

Die PostgreSQL Datenbank wurde von dem Herrn Alexander Sus vorgegeben.
Sie läuft in einem einem Docker Container und kann deswegen während der Entwicklung leicht neu aufgesetzt werden, sollte es zu Problemen kommen. Genaueres zum aufsetzen der Datenbank mit Docker steht im Setup Guide.

- PostgreSQL Version: 13
- Port: 5432 (Default)
- Datenbank: coderunnerdb
- User: postgres
- Password: admin (!nur für Entwicklungszwecke, vor dem Deploy ändern)

## Repository Pattern

Der Data Access wurde mit dem Repository Pattern umgesetzt. Alle DB queries laufen über die Repositories ab und sind auch somit das Interface zum BusinessLayer. Die Interfaces zu den Repositories befinden sich im `FHTW.CodeRunner.DataAccess.Interfaces` Project und die dazu gehörigen Implementierungen im `FHTW.CodeRunner.DataAccess.Sql` Projekt.

## Entities

Die Entities befinden sich im `FHTW.CodeRunner.DataAccess.Entities` Projekt. Weil die Entities automatisch generiert wurden gibt es mehr navigational Properties als eigentlich gebraucht sind. Diese Properties wurden behalten wegen der Möglichkeit, dass sie später noch verwendet werden.

Genauere Informationen zu den Aufbau der Entities befinden sich im Datenstruktur Dokument.
