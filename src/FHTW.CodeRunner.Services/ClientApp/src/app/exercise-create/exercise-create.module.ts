import { NgModule } from '@angular/core';

import { AppComponent } from '../app.component';
import { ExerciseCreateComponent } from './exercise-create.component';
import { GeneralTabComponent } from './tabs/general-tab/general-tab.component';
import { ProgrammingTabComponent } from './tabs/programming-tab/programming-tab.component';
import { SaveTabComponent } from './tabs/save-tab/save-tab.component';
import { TestSuitTabComponent } from './tabs/test-suit-tab/test-suit-tab.component';
import { WrittenLangTabComponent } from './tabs/written-lang-tab/written-lang-tab.component';

@NgModule({
  declarations: [
    AppComponent,
    ExerciseCreateComponent,
    GeneralTabComponent,
    WrittenLangTabComponent,
    ProgrammingTabComponent,
    TestSuitTabComponent,
    SaveTabComponent
  ],
  imports: [],
  providers: [],
  bootstrap: [AppComponent]
})
export class ExerciseCreateModule { }
