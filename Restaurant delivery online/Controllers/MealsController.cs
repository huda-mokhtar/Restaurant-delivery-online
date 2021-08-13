using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_delivery_online.IServices;
using Restaurant_delivery_online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_delivery_online.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private IMeal _repo;
        public MealsController(IMeal repo)
        {
            _repo = repo;
        }
        // GET: /Meals
        [HttpGet]
        public async Task<ActionResult<List<Meal>>> Get()
        {
            List<Meal>meals  = _repo.GetAll();
            if (meals.Count == 0)
            {
                return NoContent();
            }
            if (meals == null)
            {
                return BadRequest();
            }
            return Ok(meals);
        }

        // GET /meals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Meal meal = _repo.GetById(id);

            if (meal == null)
            {
                return NotFound();
            }
            return Ok(meal);
        }
        // POST /meals
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Meal meal)
        {
            if (meal == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Meal> meals = _repo.Add(meal);

            if (meals == null)
            {
                return BadRequest();
            }
            return Ok(meals);
        }

        //Patch /meals/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<Meal>> Patch(int id, [FromBody] Meal meal)
        {
            if (meal == null || meal.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Meal Oldmeal = _repo.GetById(id);
            if (Oldmeal == null)
            {
                return NotFound();
            }

            var meals = _repo.Update(meal);
            if (meals == null)
            {
                return BadRequest();
            }

            return Ok(meals);
        }
        //Get /Meals/GetAllMeals/1
        [HttpGet, Route("GetAllMeals/{id}")]
        public async Task<ActionResult<List<Meal>>> GetAllMeals(int id)
        {
            List<Meal> meals = _repo.GetAllMealsByRestaurant(id);
            if (meals.Count == 0)
            {
                return NoContent();
            }
            if (meals == null)
            {
                return BadRequest();
            }
            return Ok(meals);
        }
        // DELETE /Meals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var existing = _repo.GetById(id);

            if (existing == null)
            {
                return NotFound();
            }
            var meals = _repo.Delete(id);

            if (meals == null)
            {
                return new NoContentResult();
            }

            return Ok(meals);

        }
    }
}
