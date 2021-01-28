import { Component, forwardRef, Inject, Input, OnInit } from '@angular/core';
import { AppComponent } from '../app.component';
import { CollectionDataService } from '../services/exercise-collection.data.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  @Input() username: string;

  constructor(private appComponent: AppComponent, public collectionDataService: CollectionDataService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout(){
    this.appComponent.logout();
  }
}
