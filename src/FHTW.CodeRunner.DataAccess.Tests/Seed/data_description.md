# Data Description

## General Notes

1) Most string data is simply the name of the field with an incremented value appended (Example: "Name": "Name_1")
2) All exercises and its versions are currently created/modified by the same user.
3) Values that are prefixed with "n" exist multiple times in the db, but are supposed to be the same.

## Duplicated Fields

The following fields exists multiple times, but are supposed to be the same.

Alles was unter Allgemein im GUI ist existiert mehrfach pro sprache:

- FieldLindes
- GradingFlag
- SubtractSystem
- ObtainablePoints
- idnum (but maybe not?) !!!!!!!!!!!!!!!!!! maybe to feedback and such
- solution
- prefill
- AllowFiles
- FilesRequired
- FilesRegex
- FilesDescription
- FilesSize

## Exercises

In the next paragraphs the composition of certain exercises is explain. It is intended as a handy reference material, but not guaranteed to be up to date.

The structure is portrait as a tree. The exercise number corresponds to the id.

- Exercise 1 (V. 1, 2, 3) (testcases 2 per language)
  - English
    - C++
    - C#
  - German
    - C++
    - C#

- Exercise 2 (V. 1) (testcases 1 per language)
  - English
    - Python
    - Java
  - German
    - Python
    - Java

- Exercise 3 (V. 1) (testcases 1 per language)
  - German
    - C

## Just Some Notes

S = Sprache
P = Programmiersprache
N = none

N {
  "FieldLines": 18,
  "GradingFlag": true,
  "SubtractSystem": "10, 20, ...",
  "OptainablePoints": 10,
  "IdNum": 123,
}

S {
  "FullTitle": "Voller_Titel_1_V2",
  "Introduction": "Einleitung_1_V2",
}

P {
  "Solution": "Solution_1_c++",
  "Prefill": "Prefill_1_c++",
}

S & P {
  "Description": "Description_1_c++",
  "Hint": "Hint_1_c++",
  "Feedback": "Feedback_1_c++",
}
