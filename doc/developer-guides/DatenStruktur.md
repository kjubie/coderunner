# **DatenStruktur**

In diesem Dokument wird der Aufbau und Zusammenhang der Entities beschrieben.
Die genaueren Informationen zu den einzelnen Properties befinden sich entweder im Code oder in der MoodleXML Dokumentation.

## **Begriffserklärungen**

Die folgenden Entities beinhalten Felder die in Moodle vorhanden sind:

- Exercise
- ExerciseHeader
- ExerciseBody
- Testsuite
- Testcase
- Tag

Gegenüberstellung der Begriffe aus Moodle und den Begriffen in unseren Entities:

|      Entity Properties                    |     Moodle Felder                         |
|      :---:                                |     :---:                                 |
|      Exercise.Title                       |     Der Name der Frage im Moodle          |
|      ExerciseHeader.FullTitle             |     Der Title im Fragetext                |
|      ExerciseHeader.Introduction          |     Teil des Fragetexts                   |
|      ExerciseHeader.TemplateParam         |     Vorlageparameter                      |
|      ExerciseHeader.TemplateParamLiftFlag |     Vorlagen-Parameter heben              |
|      ExerciseHeader.TwigAllFlag           |     Twig für alles                        |
|      ExerciseBody.Description             |     Teil des FrageTexts                   |
|      ExerciseBody.Hint                    |     Teil des FrageTexts                   |
|      ExerciseBody.FieldLines              |     Antwortfeld                           |
|      ExerciseBody.GradingFlag             |     Alles-oder-nichts-Bewertung           |
|      ExerciseBody.SubstractSystem         |     Abzugsystem                           |
|      ExerciseBody.ObtainablePoints        |     Erreichbare Punkte                    |
|      ExerciseBody.IdNum                   |     ID-Nummer                             |
|      ExerciseBody.Solution                |     Antwort                               |
|      ExerciseBody.Prefill                 |     Vorbelegung des Antwortfelds          |
|      ExerciseBody.Feedback                |     Allgemeines Feedback                  |
|      ExerciseBody.AllowFiles              |     Anhänge erlauben                      |
|      ExerciseBody.FilesRequired           |     Anhänge erforderlich                  |
|      ExerciseBody.FilesRegex              |     Regulärer Ausdruck                    |
|      ExerciseBody.FilesDescription        |     Beschreibung                          |
|      ExerciseBody.FilesSize               |     Maximal zulässige Dateigröße          |
|      TestSuite.TemplateDebugFlag          |     Vorlagen-Debugging                    |
|      TestSuite.TestOnSaveFlag             |     Beim Speichern prüfen                 |
|      TestSuite.GlobalExtraParam           |     Global extra                          |
|      TestSuite.RuntimeData                |     Laufzeit-Daten                        |
|      TestSuite.PreCheck                   |     Vorabprüfung                          |
|      TestSuite.GeneralFeedbackDisplay     |     Allgemeines Feedback Ein/Ausblenden   |
|      TestSuite.FkQuestionType             |     Fragetyp                              |
|      TestCase.OrderUsed                   |     Sortierung                            |
|      TestCase.TestCode                    |     Testfall [n]                          |
|      TestCase.StandardInput               |     Standardeingabe                       |
|      TestCase.ExpectedOutput              |     Erwartete Ausgabe                     |
|      TestCase.AdditionalData              |     Zusätzliche Vorlagedaten              |
|      TestCase.Points                      |     Punkte                                |
|      TestCase.UseAsExampleFlag            |     Als Beispiel verwenden                |
|      TestCase.HideOnFailFlag              |     Rest ausblenden bei Fehler            |
|      TestCase.DisplayType                 |     Anzeige                               |
|      Tag.Name                             |     Tag Bezeichnung                       |

### **Nicht unterstützte Felder**

Manche Moodle Felder wurden ausgelassen. Das betrifft hauptsächlich die Felder die mit Anpassung zu tun haben.
Diese Anpassungsfelder sind im Moodle erst ersichtlich wenn `Anpassung` abgehakt wurde. Sie wurden aus folgenden Gründen weggelassen:

- Die Fragetyp Prototypen stehen unserer Applikation nicht zur Verfügung
- Das Ausführen des Codes in einer Sandbox wird von uns nicht unterstützt
- Die verschiedenen Input UIs würden den Rahmen dieses Projektes sprengen.

Zusätzlich wurden auch Kategoriefelder, aus den gleichen Grund wie Fragetyp Prototypen, weggelassen.

Die weggelassenen Felder sind:

- Anpassung
- Vorlage
- Vorlagensteuerung (die Felder die darin beinhaltet sind)
- Benotung
- Resultatspalten
- Input UIs (die Felder die darin beinhaltet sind)
- Prototyping
- Sandbox
- Sprachen
- Aktuelle Kategorie
- In der Kategorie sichern

**! Aufgrund der Komplexität des Aufbaus einer Moodle Frage könnte es sein, dass manche Felder bzw. Optionen noch nicht berücksichtigt oder übersehen wurden.**

## **Struktur**

### **Exercise**

Eine Aufbau einer Exercise sieht ungefähr wie folgt aus:

Das [] Symbol bedeutet, dass es sich um eine Liste handelt.

```md
- Exercise
    - ExerciseTag[]
    - ExerciseVersion[]
        - ExerciseLanguage[]
            - ExerciseHeader
            - ExerciseBody[]
                - TestSuite
                    -TestCase[]
```

Wie man sieht ist die Exercise sehr verschachtelt, das hat aber auch seinen Gründe. Das Hauptproblem bei der Exercise ist, dass es sie in verschiedenen Versionen, Sprachen und Programmiersprachen gibt.
Deswegen teilen sich die Komponenten der Exercise in verschiedene Teile auf, die entweder allgemein gültig, Sprachenspezifisch, Programmiersprachenspezifisch oder Sprachen- und Programmiersprachenspezifisch sind.
Zusätzlich teilt sich die Exercise noch in verschiedene Versionen auf.

Allgemein Gültige Komponenten:

- Exercise
- ExerciseTag (m:n Table für Tags)

Sprachenspezifische Komponenten (versioniert):

- ExerciseHeader

Programmiersprachenspezifische Komponenten (versioniert):

- TestSuite
- TestCase

Sprachen- und Programmiersprachenspezifisch Komponenten (versioniert):

- Exercise Body

Die Entities ExerciseVersion und ExerciseLanguage dienen zur Definierung der Beziehung zwischen den verschiedenen Komponenten.

### **Collection**

Der Aufbau der Collection ist ähnlich dem Aufbau der Exercise nur ein wenig vereinfacht, weil eine Collection nur in verschiedenen gesprochenen Sprachen vorhanden sein muss.

Das [] Symbol bedeutet, dass es sich um eine Liste handelt.

```md
- Collection
    - CollectionTag[]
    - CollectionLanguage[]
    - CollectionExercise[]
```

Wie bereits bei der Exercise dient die CollectionTag Entity als m:n Table für die Tags.
Collection Language beinhaltet alle sprachenspezifischen Felder und die CollectionExercise dient als Wrapper für eine Exercise. Der Wrapper dient dazu um Präferenzen für die einzelnen Exercises zu speichern, wie zum Beispiel Version und Programmiersprache.
