# Frontend

## Technische Details

Das Frontend für dieses Projekt wurde mit Angular 8 implementiert und ist in mehrere Komponenten aufgeteilt:

* Login
* Home
* Create/Edit Exercise
* Create Collection
* Summary

### Login

Der Login funktioniert mittels BasicAuthentication und der Username und Password-Hash werden (noch) im LocalStorage gespeichert.

### Home

Auf der Startseite findet man eine Liste aller Exercises/Collections die in der Datenbank gespeichert sind. Weitere Funktionalitäten der Startseite sind verschiedene Ansichten der Liste (als Liste, kleines und großes Grid-Layout), Exercises können exportiert werden oder man kann Exercises zu einer neuen Collection hinzufügen. Man kann auch hier eine Exercise auswählen und ansehen oder auch bearbeiten.

### Create/Edit Exercise

Auf dieser Seite werden Exercises erstellt bzw. auch bearbeitet. Die Exercise ist hier in Abschnitte (Header, Body) gegliedert und man kann mehrere Sprachen und Programmiersprachen beim Erstellen einer Exercise hinzufügen, aber auch wieder entfernen. Für jede Programmiersprache kann man eine beliebige Anzahl an Test Cases hinzufügen.

### Create Collection

Diese Seite dient zur Erstellung von Exercise Collections. Hierfür werden auf der Startseite beliebige Exercises ausgewählt und der Collection hinzugefügt. Anschließend können diese auf der Create Collection Seite in der "Exercise List" eingesehen werden. Zusätzlich können die restlichen benötigten Felder zur Erstellung einer Collection ausgefüllt werden. Einige Felder sind Sprachenabhängig, wodurch die Möglichkeit geboten wird, mehrere Sprachen hinzuzufügen. Nachdem die Collection vollständig konfiguriert wurde, kann diese gespeichert werden.

### Summary

Die Summary bietet nochmals einen Überblick über alle Daten der Exercise bevor diese gespeichert wird. Die gesetzten Werte können hierbei nur eingesehen, nicht jedoch bearbeitet werden.

## Weitere Anmerkungen

### Markdown-Inputs

Auf der Create Exercise Seite gibt es für einige Felder auch eigene Mardown-Inputs, um so das Formatieren der Beschreibung zu vereinfachen.
