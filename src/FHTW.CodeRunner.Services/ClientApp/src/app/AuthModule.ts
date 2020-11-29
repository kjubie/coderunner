import { NgModule } from '@angular/core';
import { JwtModule } from '@auth0/angular-jwt';

@NgModule({
    declarations: [
    ],
    imports: [
    ],
    providers: [

    ],
    exports: [
    ]
})
export class AuthModule {

    public static forRoot() {
        return {
            ngModule: JwtModule.forRoot({
                config: {
                  tokenGetter: () => {
                      return localStorage.getItem('name');
                  }
                }
            })
        }
    }
}