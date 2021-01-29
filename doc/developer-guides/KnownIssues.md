# Known Issues

Dieses File beinhaltet eine Auflistung von Fehlern, welche uns bekannt sind. Diese konnten aus zeitlichen Gründen nicht mehr behoben werden.

## Markdown Konvertierungen

Tabellen werden nicht korrekt konvertiert. Bilder wurden nicht getestet und werden höchstwahrscheinlich auch nicht konvertiert.

## Unsauberes Error Handling

Error Handling ist zwar vorhanden, könnte aber deutlich besser ausgeführt werden. So sollten zum Beispiel im Data Access Layer mehrere eigene Exceptions eingeführt werden. Genauso sollten auch mehrere Status Codes bei der API verwendet werden (zum Beispiel 404 wenn eine Exercise nicht gefunden wird). Genauso könnte auch das Anzeigen von genaueren und besseren Meldungen im Frontend mit Angular nicht schaden.

## Test Case Problem beim Editieren

Hier gibt es einen Bug. Wenn man beim Editieren einen neuen Test Case hinzufügen will, muss man zuerst in den Bereich der Programmiersprache klicken, da sonst nicht klar wo dieser hinzugefügt werden soll.

## Validierungen

Prinzipiell gibt es einen API Call zur Validierung von Exercises. Dieser wird aber nicht verwendet. Dies wäre aber auf jeden Fall eine Empfehlung. Genauso sollten mehr Validierungne im Business Layer stattfinden, damit nicht alles gegen die Datenbank geprüft werden muss. Außerdem sollten auch Validierungen im Frontend geschehen.
