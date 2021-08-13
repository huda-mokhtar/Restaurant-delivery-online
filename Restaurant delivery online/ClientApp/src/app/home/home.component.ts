import { Component, OnInit } from '@angular/core';
import { log } from 'console';
import { ReataurantService } from '../_service/Resturants.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export default class HomeComponent implements OnInit {
  city: string;
  restaurant: string;
  constructor(public reataurantservice: ReataurantService) { }
  ngOnInit(): void {
  
  }
  Search() {
    console.log(this.city, this.restaurant);
  }
}
