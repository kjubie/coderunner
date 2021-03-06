# HTML/Markdown Konvertierung

Dieses Dokument deckt jene Probleme ab, welche bei der Konvertierung dieser Formate entstehen.

Pinzipiell werden für die Konvertierungen folgende Packages verwendet:

* Markdown => HTML: <https://www.nuget.org/packages/Markdig/>
* HTML => Markdown: <https://www.nuget.org/packages/ReverseMarkdown/>

Hier würde ich empfehlen ein eigenes Testprogramm zu schreiben, bei welchem diese Packages für weitere Fälle getestet werden können.

Prinzipiell lag unser Hauptaugenmerk auf den Code Blocks. Bei der Konvertierung von Markdown zu HTML werden bei dem generierten HTML Klassen in den entsprechenden Tags hinzugefügt. Diese Klassen geben die Programmiersprache an.

Ein Beispiel für C#:

```html
<code class="language-csharp">
int x = 0;
int y = x - 1;
    
Console.WriteLine(y);
</code>
```

Das zugehörige CSS bzw. Stylesheet zu diesen Klassen wird aber nicht erstellt. Das ist natürlich nicht ideal. Aber tatsächlich ist dieses Format standardisiert und kann mittels <https://highlightjs.org/> realisiert werden. Nun ist aber das Problem, dass Moodle nicht in der Lage zu sein scheint in herkömmlicher Manier Stylesheets und Scripts zu inkludieren.
Folgende Optionen könnten interessant sein, um dieses Dilemma zu umgehen:

* Dieses Plugin könnte eventuell einiges an Kopfzerbrechen beheben? <https://moodle.org/plugins/pluginversion.php?id=14813>
* Warum nicht gleich einen Markdown Editor in Moodle verwenden? <https://moodle.org/plugins/editor_marklar>

Da wir aber für beide Optionen nicht genügend Wissen, Berechtigungen und Zeit hatten, haben wir folgende vorübergehende Lösung verwendet:

<http://hilite.me/>

Mit dieser API kann Code in banales HTML umgewandelt werden.

Sollte aus einem bestimmten Grund, die eben genannte Option beibehalten werden, so wäre es sinnvoll, dass das zugehörige Python Script heruntergeladen wird und damit auch kein API Call benötigt wird.
