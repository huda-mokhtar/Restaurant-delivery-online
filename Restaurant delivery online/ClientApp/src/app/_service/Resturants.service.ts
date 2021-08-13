import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Restaurant } from '../models/Restaurant';


@Injectable({
  providedIn: 'root'
})
export class ReataurantService {

  constructor(public http: HttpClient) { }
  getAll() {
    return this.http.get<Restaurant[]>("https://localhost:44383/Restaurants");
  }
 
}
