# Business Layer

Nachfolgend werden einzelne Besonderheiten des Business Layer erläutert. Die zugehörigen Projekte beginnen mit `FHTW.CodeRunner.BusinessLogic`.

## Validatoren

Für die Validierung einzelner Entities wurde FluentValidation verwendet. All die Validatoren für die Entities befinden sich hier im Ordner `Validators`.

## Exceptions

Im Ordner `Exceptions` befinden sich spezifische Exceptions, welche je nach Fehlermeldung geworfen werden und genauso wird dabei eine Inner Exception mitgegeben. Durch die Unterteilung in mehrere Exceptions kann im Service Layer darauf reagiert und entsprechende Statusmeldungen an das Frontend weitergegeben werden.

## Entities

Bei den Entities ist zu beachten, dass diese zur Vorbereitung für den Data Access Layer dienen. So werden teilweise auch über das Mapping Foreign Keys gesetzt und nach Bedarf einzelne Properties auf null gesetzt.
