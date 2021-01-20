# **Moodle XML Requirements**

## **Pflichtfelder**

- Fragetitel
- Fragetext
- Fragetyp
- min. 1 Testfall

Wird nicht auf korrekten Inhalt geprüft.

---

## **XML Inhalt**

- XML Felder für Einstellungen werden erzeugt egal ob Inhalt vorhanden
  - Für Import egal ob vorhanden: weglassen für kleinere Filesizes?
- Code und Testfälle als Klartext in XML gespeichert
- Optionaler Header
  - Hiermit kann Kategorie beim Import wiederhergestellt werden
- Textfelder mit HTML Tags formatiert
- Das Feld "Sortierung" der Testfälle wird nicht als Wert im XML gespeichert, sondern richtet sich beim Import nach der Reihenfolge der aufgelisteten Tests im XML.

---

## **Moodle Import**

- Aufgaben können mehrfach importiert werden (Auch komplett idente Aufgaben inkl. Titel)
- Fehlerhafte Aufgabenstellungen können importiert werden, zeigen beim editieren jedoch einen Error an

---

## **Grober XML Aufbau**

### **Neue Frage**

```XML
  <question type="coderunner"></question>
```

---

### **1 Coderunner-Fragetyp**

#### **Fragetyp**

Legt die Programmiersprache und den Fragetypen des Coderunner beispiels fest.

```XML
  <coderunnertype>c_function</coderunnertype>
```

#### **Vorlagen-Debugging - Flag**

- 0: aus
- 1: ein

Wenn aktiv, wird für jeden Testfall das generierte Programm in der Ausgabe angezeigt.

```XML
  <showsource>0</showsource>
```

#### **Antwortfeld**

Legt die Anzahl der Zeilen im Antwortfeld fest.

```XML
  <answerboxlines>18</answerboxlines>
```

#### **Vorabprüfung**

Vorabprüfung erlaubt den Studenten das Überprüfen ihrer Antworten bereits vor der Abgabe.

- 0: Deaktiviert
  - (Keine Vorabprüfung vorhanden)
- 1: Leer
  - (Durchläuft einen Test mit leeren Parametern)
- 2: Beispiele
  - (Durchläuft alle Tests die als "Als Beispiel verwenden" markiert wurden)
- 3: Ausgewählt
  - (Fügt Testfällen ein weiteres Feld hinzu um diese für Vorabprüfung zu wählen)
- 4: Alle
  - (Durchläuft alle Testfälle)

```XML
  <precheck>0</precheck>
```

#### **Allgemeines Feedback Ein/Ausblenden**

Legt fest ob Generelles Feedback nach Beantwortung angezeigt werden soll oder nicht

- 0: Vom Test festgelegt
- 1: Anzeigen erzwingen
- 2: Verbergen erzwingen

```XML
  <displayfeedback>1</displayfeedback>
```

#### **Alles-oder-nichts-Bewertung - Flag**

- 0: aus
- 1: ein

Wenn aktiv müssen alle Testfälle erfolgreich durchlaufen werden um Punkte zu erhalten

```XML
  <allornothing>1</allornothing>
```

#### **Abzugsystem**

Eine durch Komma getrennte Liste von Strafen.
Legt den prozentuellen Abzug von Punkten fest für aufeinanderfolgende Einreichungen.

```XML
  <penaltyregime>10, 20, ...</penaltyregime>
```

#### **Vorlageparameter**

Hier können String-Parameter festgelegt werden, die dann an die Fragen-Vorlage übergeben werden.

z.B: {age: 23}
Kann anschließend mit {{QUESTION.parameters.age}} angesprochen werden und fügt an dieser Stelle "23" ein.

```XML
  <templateparams></templateparams>
```

#### **Vorlagen-Parameter heben - Flag**

- 0: aus
- 1: ein

Wenn aktiv werden Parameter in den globalen Namespace gehoben und können direkt
referenziert werden.

```XML
  <hoisttemplateparams>1</hoisttemplateparams>
```

#### **Twig für alles - Flag**

- 0: aus
- 1: ein

Wenn aktiv wird Twig-Makroprozessor auch auf Fragentext, Musterantwort, Antwort-Preload und Testfall-Felder angewandt.
Muss ein sein, wenn Randomisierung innerhalb der Vorlagenparameter benutzt werden möchte.

```XML
  <twigall>0</twigall>
```

---

### **2 Anpassung**

#### **Vorlage**

Beinhält die Vorlage für Anpassung als Klartext.

```XML
    <template></template>
```

#### **Ist ein Kombinator - Flag**

Gibt an ob Vorlage eine Kombinatorvorlage ist.

- 0: aus
- 1: ein

```XML
    <iscombinatortemplate></iscombinatortemplate>
```

#### **Mehrere stdins erlauben - Flag**

- 0: aus
- 1: ein

```XML
    <allowmultiplestdins></allowmultiplestdins>
```

#### **Test-Trenner (regex)**

Regulärer PHP-Ausdruck um Ausgabe des Programmablaufs wieder in einzelne Testläufe aufzuteilen.

```XML
    <testsplitterre></testsplitterre>
```

#### **Benotung**

Gibt an wie Anpassung Benotet wird.

- EqualityGrader
- NearEqualityGrader
- RegexGrader
- TemplateGrader

```XML
    <grader></grader>
```

#### **Resultatespalten**

JSON-codierte Liste an Spaltenspezifizierern.

```XML
    <resultcolumns></resultcolumns>
```

#### **Antwort des Studierenden**

Gibt Plugin für Editor an, für Coding Fragen meist Ace verwendet.

- None
- gapfiller
- graph
- html
- table

Ist das Feld Leer wird automatisch Ace verwendet.

```XML
    <uiplugin></uiplugin>
```

#### **Vorlage verwendet Ace - Flag**

Gibt an ob Ace Editor für die Vorlage verwendet wird.

- 0: aus
- 1: ein

```XML
    <useace>0</useace>
```

---

### **3 Weitergehende Anpassung**

#### **Ist Prototyp?**

Gibt den Prototyp Typ an.

- 0: No
- 1: Yes (built-in)
- 2: Yes (user defined)

```XML
    <prototypetype>0</prototypetype>
```

#### **Sandbox**

Legt fest welche Sandbox verwendet wird.

- DEFAULT
- jobesandbox
- ideonesandbox

```XML
    <sandbox></sandbox>
```

#### **Zeitbegrenzung (s)**

Legt die CPU Zeitbegrenzung in Sekunden fest.

```XML
    <cputimelimitsecs></cputimelimitsecs>
```

#### **Speicherbegrenzung (MB)**

Legt fest wie viel MB Speicher zur Verfügung steht.

```XML
    <memlimitmb></memlimitmb>
```

#### **Parameter**

Beinhält Sandboxparameter als JSON.

```XML
    <sandboxparams></sandboxparams>
```

#### **Sandbox-Sprache**

Legt die Sandbox Computersprache fest.

```XML
    <language></language>
```

#### **Ace-Sprache**

Legt die Sprache fest, die für den Ace-Editor verwendet wird.

```XML
    <acelang></acelang>
```

---

### **4 Allgemeines**

#### **Fragetitel**

```XML
  <name>
    <text></text>
  </name>
```

#### **Fragetext**

```XML
  <questiontext format="html">
    <text><![CDATA[<p></p>]]></text>
  </questiontext>
```

#### **Erreichbare Punkte**

Feld kann nie leer sein!
Gibt die zu erreichenden Punkte an

```XML
  <defaultgrade>1.0000000</defaultgrade>
```

#### **Allgemeines Feedback**

Wird nach Beantwortung der Frage angezeigt. (Unabhängig der gewählten Antwort).
Optionales Inputfeld!
Anzeige kann im Coderunner-Fragetyp festgelegt werden.

```XML
  <generalfeedback format="html">
    <text></text>
  </generalfeedback>
```

#### **ID-Nummer**

Optional!
Wenn verwendet, muss ID in jeder Fragenkategorie eindeutig sein!

```XML
  <idnumber></idnumber>
```

---

### **5 Antwort**

#### **Beim Speichern prüfen - Flag**

Legt fest ob Beispielantwort beim Speichern ausgeführt werden soll.

- 0: aus
- 1: ein

```XML
    <validateonsave>1</validateonsave>
```

---

### **6 Vorbelegung des Antwortfelds**

Eingefügter Text wird im Antwortfeld vorgeladen.

```XML
    <answerpreload></answerpreload>
```

---

### **7 Global extra**

Wie zusätzliche Vorlagedaten, jedoch global für alle Testfälle gültig.

```XML
    <globalextra></globalextra>
```

---

### **8 Testfälle**

Dient zum Erstellen neuer Testfälle

```XML
  <testcases>
    <testcase testtype="0" useasexample="0" hiderestiffail="0" mark="1.0000000" >
      <testcode>
        <text>test</text>
      </testcode>
      <stdin>
        <text></text>
      </stdin>
      <expected>
        <text></text>
      </expected>
      <extra>
        <text></text>
      </extra>
      <display>
        <text>SHOW</text>
      </display>
    </testcase>
  </testcases>
```

**useasexample:**

gibt an ob der Testcase als Beispiel verwendet werden soll.
Als Beispiel markierte Tests werden in der Resultatetabelle unter "Zum Beispiel:" angezeigt: Werte 0/1

**hiderestiffail:**

blendet alle nachfolgenden Tests in der Anzeige aus sobald ein Fehler auftritt: Werte 0/1

**mark:**

Gibt die erreichbaren Punkte des Testfalls an. Wert kann nur gesetzt werden, wenn Frage nicht als "Alles-oder-nichts" gekennzeichnet wurde.

**display:**

Legt fest wann und ob der Testfall angezeigt werden soll.

Werte:

- SHOW
- HIDE
- HIDE_IF_FAIL
- HIDE_IF_SUCCEED

**testcode:**

Code des Testfalls als Klartext

**stdin:**

Standardeingabe für den Test

**expected:**

Erwartete Ausgabe des Testfalls

**extra:**

Zusätzliche Vorlagedaten. Entspricht einem weiteren Inputfeld.

---

### **9 Unterstützungsdateien**

#### **Laufzeit-Daten**

Dateien die zusätzlich von den Testfällen ausgeführt werden können.
Zum Beispiel Unit Tests.

Den file Tag gibt es im Moodle Xml mehrfach, hierbei kommt es auf den Parent Tag drauf an um welche Datei es sich handelt.
Im fall der Laufzeit Daten befinden sich diese im testcases tag.

```XML
    <testcases>
      <testcase>...</testcase>
      ...
      <file name="test.zip" path="/" encoding="base64">...</file>
    </testcases>
```

### **10 Optionen für Anhänge**

#### **Anhänge erlauben**

Gibt an ob und wie viele Anhänge für die Frage zugelassen sind.

- O: Nein
- 1: 1
- 2: 2
- 3: 3
- 4: Unbegrenzt

```XML
    <attachments>0</attachments>
```

#### **Anhänge erforderlich**

Gibt an wieviele Anhänge mindestens benötigt werden, damit die Frage Bewertet werden kann.

- 0: Anhänge sind optional
- 1: 1
- 2: 2
- 3: 3

```XML
    <attachmentsrequired>0</attachmentsrequired>
```

#### **Regulärer Ausdruck**

Gibt einen RegEx an, um die Filenamen zu vereinheitlichen.

```XML
    <filenamesregex></filenamesregex>
```

#### **Beschreibung**

Gibt eine Beschreibung an welche Filenamen erlaubt sind. Wird das Feld leer gelassen, wird der RegEx selbst angezeigt.

```XML
    <filenamesexplain></filenamesexplain>
```

#### **Maximal zulässige Dateigröße**

Legt die maximale Dateigröße in Bytes fest.

```XML
    <maxfilesize>10240</maxfilesize>
```

---

### **11 Tags**

Hiermit werden neue Tags hinzugefügt.

```XML
  <tags>
    <tag><text>Hier Tag einfügen</text></tag>
  </tags>
```

### **12 Noch Unsicher**

```XML
    <penalty>0.0000000</penalty>
    <hidden>0</hidden>
    <answerboxcolumns>100</answerboxcolumns>
    <answer></answer>
```
