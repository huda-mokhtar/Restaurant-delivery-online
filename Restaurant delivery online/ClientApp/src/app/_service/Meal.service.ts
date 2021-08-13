import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Meal } from '../models/Meal';


@Injectable({
  providedIn: 'root'
})
export class MealService {

  constructor(public http: HttpClient) { }
  
  getAllMeals(id:any) {
    return this.http.get<Meal[]>('https://localhost:44383/Meals/GetAllMeals/'+id );
  }
 
}
