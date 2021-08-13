import { Component,OnInit } from '@angular/core';
import { Restaurant } from '../models/Restaurant';
import { ReataurantService } from '../_service/Resturants.service';
@Component({
  selector: 'app-restaurants',
  templateUrl: './restaurants.component.html',
  styleUrls: ['./restaurants.component.css']
})
export default class RestaurantsComponent implements OnInit {
  restaurents: Restaurant[];
  constructor(public reataurantservice: ReataurantService) { }
  ngOnInit(): void {
    this.reataurantservice.getAll().subscribe(a => {
      this.restaurents = a;
      console.log(a);
    })
  }
}
