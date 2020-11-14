import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  languages: string[] = ["German", "English"];
  programmingLangs: string[] = ["C#", "Java", "Python", "..."];

  languageDropdown() {
    document.getElementById("languageDropdown").classList.toggle("show");
    document.getElementById("languageDropdown").onmouseleave = function close() {
      document.getElementById("languageDropdown").classList.toggle("show", false);
    }
  }

  programmingDropdown() {
    document.getElementById("programmingDropdown").classList.toggle("show");
    document.getElementById("programmingDropdown").onmouseleave = function close() {
      document.getElementById("programmingDropdown").classList.toggle("show", false);
    }
  }
}
