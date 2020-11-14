import { Component, OnInit, Input, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppComponent } from '../app.component';

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
export class LoginComponent implements OnInit {
  constructor(private router: Router, private appComponent: AppComponent) { }
  @Input() public success: boolean;
  @Input() public username: string;


  ngOnInit() {
  }

  // Create observer object
  myObserver = {
    next: x => {
      if (x.status == "success") {
        this.success = true;
      }
    },
    error: err => { this.success = false },
    complete: () => {
      if (this.success) {
        // this.appComponent.username = this.username; 
        this.router.navigate(['/menu']);

      } else {
        console.log("no username")
        //this.appComponent.username = "";
      }
    }
  };

  login() {
    console.log("ToDo: save credentials / check with data in db...");
  }
}