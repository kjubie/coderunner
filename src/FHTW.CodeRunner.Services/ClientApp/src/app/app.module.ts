import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ExerciseCollectionComponent } from './exercise-collection/exercise-collection.component';
import { ExerciseCreateComponent } from './exercise-create/exercise-create.component';
import { SaveTabComponent } from './exercise-create/tabs/save-tab/save-tab.component';
import { TestSuitTabComponent } from './exercise-create/tabs/test-suit-tab/test-suit-tab.component';
import { ProgrammingTabComponent } from './exercise-create/tabs/programming-tab/programming-tab.component';
import { WrittenLangTabComponent } from './exercise-create/tabs/written-lang-tab/written-lang-tab.component';
import { GeneralTabComponent } from './exercise-create/tabs/general-tab/general-tab.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    HomeComponent,
    ExerciseCreateComponent,
    ExerciseCollectionComponent,
    GeneralTabComponent,
    WrittenLangTabComponent,
    ProgrammingTabComponent,
    TestSuitTabComponent,
    SaveTabComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent},
      { path: 'exercise-collection', component: ExerciseCollectionComponent },
      { path: 'exercise-create', component: ExerciseCreateComponent },
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
