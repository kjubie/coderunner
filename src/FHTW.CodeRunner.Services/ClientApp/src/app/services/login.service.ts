import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';
import { sha512 } from 'js-sha512';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private loginUrl = 'https://localhost:5001/api/user/authenticate';

  constructor(private httpClient: HttpClient) { }

  login(name: string, pwd: string) {
    let password = sha512(pwd);
    // { auth_token: string, status: string, message: string }
    return this.httpClient
        .post<any>(this.loginUrl, { name, password }, {observe: 'response' as 'body'})
        .pipe(tap(res => {
            console.log("login response: " + res.status);
            if (res.status == 200 && res.statusText == "OK") {
              localStorage.setItem('auth_token', res.auth_token);
              localStorage.setItem('name', name);
            } else {
              console.log("login failed");
            }
          })
        );
  }

  public getUsername(){
    return localStorage.getItem('name');
  }

  public logout() {
    localStorage.removeItem('auth_token');
    localStorage.removeItem('name');
  }

  public get loggedIn(): boolean {
    return localStorage.getItem('auth_token') !== null;
  }


}