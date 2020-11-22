import {Component, Input, OnInit} from '@angular/core';

@Component({
  selector: 'star-rating',
  templateUrl: './star-rating.component.html',
  styleUrls: ['../home.component.css']
})
export class StarRatingComponent implements OnInit {

  @Input() rating: number;

  public maxItem: any[];
  public ratedCount: number;

  constructor() {
    this.ratedCount = 0;
  }

  ngOnInit() {
    this.maxItem = [];
    for (let i = 0; i < 5; i++) {
      this.maxItem.push(i + 1);
    }
  }
}