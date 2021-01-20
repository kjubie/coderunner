# Aufbau

Das Projekt ist in mehrere Komponenten aufgeteilt. Vorwiegend wird hier zwischen einzelnen Layern unterschieden:

* **Service Layer**: beinhaltet die benötigten Klassen für die API und genauso ist auch die ClientApp Teil dieses Layers
* **Business Layer**: beinhaltet die Business Logik.
* **Data Access Layer**: beinhaltet Klassen zur Anbindung an die Datenbank.
* **Export Service Layer**: beinhaltet Klassen zur Konvertierung für das Moodle Format.

Jeder dieser Layer verfolgt dabei eine ähnlich Aufteilung. So wurde versucht für jeden Layer Entities, Interfaces und Unit Tests zu verwenden.

## Packages

Auf Solution Ebene ist hier nur StyleCop zu erwähnen. Dieses Package dient einem einheitlichen Coding-Stil im Projekt. Hier können aber natürlich Konfigurationen vorgenommen werden und dies gelingt mit dem File `stylecop.json`. Dieses ist auf Solution und jetzt einzelne CS-Projekt referenziert auf dieses als Link. Das bedeutet, dass dieses File nicht in jedem einzelnen Projekt einzeln erstellt oder später angepasst werden muss. In einem `csproj` sieht dies wie folgt aus:

```xml
<ItemGroup>
    <AdditionalFiles Include="..\stylecop.json" Link="stylecop.json" />
</ItemGroup>
```

## Weitere Anmerkungen

### .NET Version

Bei der Entwicklung wurden stets die aktuellsten Versionen von .NET verwendet. Das bedeutet:

* .NET 5
* .NET Standard 2.1
* C# 9

Da C# 9 nicht defaultmäßig verwendet wird (<https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version>), mussten hier einzelne Anpassungen getroffen werden. So wurde etwa bei einem .NET Standard Projekt folgender Eintrag im `csproj` getätigt:

```xml
<PropertyGroup>
    <TargetFramework>netstandard2.1</TargetFramework>
    <LangVersion>9.0</LangVersion>
    <GenerateDocumentationFile>true</GenerateDocumentationFile>
</PropertyGroup>
```

### Azure Devops

Dieses Projekt wurde auch mit Azure Devops verknüpft und dementsprechend wurden hier auch Tests ausgeführt. Die entsprechende Pipeline befindet sich im build-Ordner.
