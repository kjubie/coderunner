import { Location } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {

  title = 'app';
  public username: string;
  isCollapsed: Boolean = true;
  createExercise: Boolean = true;

  constructor(private location: Location, private loginService : LoginService, private router: Router) { }

  ngOnInit(){
    this.username = this.loginService.getUsername();
  }
  goToPreviousPage() {
    this.location.back(); // <-- go back to previous location
  }

  public logout(){
    this.loginService.logout();
    this.username = "";
    this.router.navigate(['/login']);
  }

  isLoggedIn() {
    return this.loginService.loggedIn;
  }
}
