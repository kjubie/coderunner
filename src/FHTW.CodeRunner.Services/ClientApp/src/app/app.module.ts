import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

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
import { ListViewComponent } from './home/layouts/list/list-view.component';
import { GridBigViewComponent } from './home/layouts/grid-big/grid-big-view.component';
import { GridSmallViewComponent } from './home/layouts/grid-small/grid-small-view.component';
import { StarRatingComponent } from './home/rating/star-rating.component';
import { AuthGuardService } from './auth/authgard.service';
import { TokenInterceptor } from './auth/toke.interceptor';
import { AppRoutingModule } from './app-routing.module';
import { AuthModule } from './AuthModule';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    HomeComponent,
    StarRatingComponent,
    ListViewComponent,
    GridBigViewComponent,
    GridSmallViewComponent,
    ExerciseCreateComponent,
    ExerciseCollectionComponent,
    GeneralTabComponent,
    WrittenLangTabComponent,
    ProgrammingTabComponent,
    TestSuitTabComponent,
    SaveTabComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    AuthModule
  ],
  providers: [
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    AppComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
