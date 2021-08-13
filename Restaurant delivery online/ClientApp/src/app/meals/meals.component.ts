import { Component,OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Meal } from '../models/Meal';
import { MealService } from '../_service/Meal.service';
@Component({
  selector: 'app-meals',
  templateUrl: './meals.component.html',
  styleUrls: ['./meals.component.css']
})
export class MealsComponent implements OnInit {
  meals: Meal[];
  id: number;
  constructor(public mealservice: MealService, public ar: ActivatedRoute) { }
  ngOnInit(): void {
    this.ar.params.subscribe(a => this.id = a['item']);
    this.mealservice.getAllMeals(this.id).subscribe(a => {
      this.meals = a;
      console.log(a);
    })
  }
}
