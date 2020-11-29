import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

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
import { SideMenuComponent } from './side-menu/side-menu.component';
import { MatAutocompleteModule, MatButtonToggleModule, MatCardModule, MatCheckboxModule, MatChipsModule, MatDatepickerModule, MatDialogModule, MatDividerModule, MatExpansionModule, MatGridListModule, MatIconModule, MatInputModule, MatListModule, MatMenuModule, MatPaginatorModule, MatProgressBarModule, MatProgressSpinnerModule, MatRadioModule, MatSelectModule, MatSidenavModule, MatSliderModule, MatSlideToggleModule, MatSnackBarModule, MatSortModule, MatStepperModule, MatTableModule, MatTabsModule, MatToolbarModule, MatTooltipModule } from '@angular/material';
import { CdkTableModule } from '@angular/cdk/table';

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
    SaveTabComponent,
    SideMenuComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    AppRoutingModule,
    AuthModule,
    MaterialModule
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
