import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AuthGuardService } from "./auth/authgard.service";
import { ExerciseCollectionComponent } from "./exercise-collection/exercise-collection.component";
import { ShowCollectionComponent } from "./exercise-collection/show-collection/show-collection.component";
import { ExerciseCreateComponent } from "./exercise-create/exercise-create.component";
import { HomeComponent } from "./home/home.component";
import { ImportComponent } from "./import/import.component";
import { LoginComponent } from "./login/login.component";

const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'import', component: ImportComponent },
    { path: 'show-collection', component: ShowCollectionComponent },
    { path: 'exercise-collection', component: ExerciseCollectionComponent, canActivate: [AuthGuardService] },
    { path: 'exercise-create', component: ExerciseCreateComponent, canActivate: [AuthGuardService] },
    { path: '**', component: HomeComponent, canActivate: [AuthGuardService] }
];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes, { enableTracing: false }
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {
    
}