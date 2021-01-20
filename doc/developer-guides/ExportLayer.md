# Export Service Layer

Nachfolgend werden einzelne Besonderheiten des Business Layer erläutert. Die zugehörigen Projekte beginnen mit `FHTW.CodeRunner.ExportService`.

## Namensgebung

Die Namensgebung ist nicht gut. Ursprünglich war dieses Projekt nur für den Export zuständig. Doch es wurde mittlerweile auch zum Beispiel um den Import erweitert. Hier müsste noch ein besserer Name gefunden werden.

## XML Serialisierung

Hier fiel die Entscheidung auf den XmlSerializer. Es hätte auch die Möglichkeit gegeben T4-Templates zu verwenden. Dies wäre besonders für den Export interessant gewesen, da keine eigenen Entities erstellt hätten werden müssen. Da jedoch für den Import das T4-Template nicht geeignet gewesen wäre fiel die Entscheidung doch eindeutig auf den XmlSerializer. So wurden mit einem vorhandenen Moodle-Xml Dokument die entsprechenden Entities generiert. Das Mapping zu diesen neuen Moodle Entities passiert mit Hilfe von AutoMapper under der Converter befindet sich in `FHTW.CodeRunner.Services.Converters`.

## Utf8StringWriter

Hier wurde eine eigene StrinWriter Klasse erstellt, da das Moodle-XML Utf8 Encoding verwendet. Standardmäßig wird nämlich Utf16 benutzt.
