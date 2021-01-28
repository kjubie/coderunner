import { HttpResponse } from '@angular/common/http';
import { Component, OnInit, Input, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from '../app.component';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

@NgModule({
  imports: [NgbModule],
  declarations: [],
  exports: [],
  bootstrap: []
})
export class LoginComponent {

  constructor(private loginService: LoginService, private router: Router, private appComponent: AppComponent) { }

  @Input() public success: boolean;
  @Input() public name: string;

  // Create observer object
  myObserver = {
    next: x => {
      if (x.status == 200) {
        this.success = true;
      }
    },
    error: err => { this.success = false },
    complete: () => {
      if (this.success) {
        this.appComponent.username = this.name; 
        this.router.navigate(['/']);

      } else {
        console.log("no username")
        this.appComponent.username = "";
      }
    }
  };

  login() {
    console.log("ToDo: save credentials / check with data in db...");
  }

  PassBack(credentials) {
    this.loginService.login(credentials.name, credentials.password)
    .subscribe(this.myObserver);
  }
}