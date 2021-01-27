import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ImportComponent } from './import/import.component';
import { ExerciseCollectionComponent } from './exercise-collection/exercise-collection.component';
import { ExerciseCreateComponent } from './exercise-create/exercise-create.component';
import { SaveTabComponent } from './exercise-create/tabs/save-tab/save-tab.component';
import { TestSuitTabComponent } from './exercise-create/tabs/test-suit-tab/test-suit-tab.component';
import { TestCaseTabComponent } from './exercise-create/tabs/testcase-tab/testcase-tab.component';
import { ProgrammingTabComponent } from './exercise-create/tabs/programming-tab/programming-tab.component';
import { ProgrammingLangsTabComponent } from './exercise-create/tabs/programming-langs-tab/programming-langs-tab.component';
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
import { SideMenuComponent } from './side-menu/side-menu.component';
import { MatAutocompleteModule, MatButtonToggleModule, MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule, MatDialogModule, MatDividerModule, MatExpansionModule, MatGridListModule, MatIconModule, MatInputModule, MatListModule, MatMenuModule, MatPaginatorModule, MatProgressBarModule, MatProgressSpinnerModule, MatRadioModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSlideToggleModule, MatSnackBarModule, MatSortModule, MatStepperModule, MatTableModule, MatTabsModule, MatToolbarModule, MatTooltipModule } from '@angular/material';
import { CdkTableModule } from '@angular/cdk/table';
import { ProgrammingLanguageElementComponent } from './side-menu/menu-elements/programming-language/programming-language-element.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularMarkdownEditorModule } from 'angular-markdown-editor';
import { CollectionDataService } from './services/exercise-collection.data.service';
import { MarkdownModule, MarkedOptions, MarkedRenderer } from 'ngx-markdown';

@NgModule({
  exports: [
    CdkTableModule,
    MatAutocompleteModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    // MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    // MatRippleModulee,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
  ]
})
export class MaterialModule {}

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    ImportComponent,
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
    ProgrammingLangsTabComponent,
    TestSuitTabComponent,
    TestCaseTabComponent,
    SaveTabComponent,
    SideMenuComponent,
    ProgrammingLanguageElementComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    AuthModule,
    MaterialModule,
    NgbModule,
    MarkdownModule.forRoot({
      markedOptions: {
        provide: MarkedOptions,
        useValue: {
          renderer: new MarkedRenderer(),
          gfm: true,
          tables: true,
          breaks: false,
          pedantic: false,
          sanitize: false,
          smartLists: true,
          smartypants: false,
        }
      },
    }),
    AngularMarkdownEditorModule.forRoot({
      iconlibrary: 'glyph'
    })
  ],
  providers: [
    AuthGuardService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    },
    AppComponent,
    CollectionDataService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
