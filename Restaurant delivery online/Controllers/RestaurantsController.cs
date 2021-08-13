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
    public class RestaurantsController : ControllerBase
    {
        private IRestaurant _repo;
        public RestaurantsController(IRestaurant repo)
        {
            _repo = repo;
        }
        // GET: /Restaurants
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> Get()
        {
            List<Restaurant> Restaurants = _repo.GetAll();
            if (Restaurants.Count == 0)
            {
                return NoContent();
            }
            if (Restaurants == null)
            {
                return BadRequest();
            }
            return Ok(Restaurants);
        }

        // GET /Restaurants/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Restaurant Restaurant = _repo.GetById(id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Ok(Restaurant);
        }
        //Get /Restaurants/cairo
        [HttpGet, Route("/getByCity")]
        public async Task<IActionResult> getByCity([FromQuery(Name = "city")] string city, [FromQuery(Name = "restaurant")] string restaurant)
        {
            List<Restaurant> restaurants = _repo.GetByCity(city, restaurant);
            return Ok(restaurants);
        }
        // POST /Restaurants
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Restaurant Restaurant)
        {
            if (Restaurant == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Restaurant> Restaurants = _repo.Add(Restaurant);

            if (Restaurants == null)
            {
                return BadRequest();
            }
            return Ok(Restaurants);
        }

        //Patch /Restaurants/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<Restaurant>> Patch(int id, [FromBody] Restaurant restaurant)
        {
            if (restaurant == null || restaurant.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Restaurant Restaurant = _repo.GetById(id);
            if (Restaurant == null)
            {
                return NotFound();
            }

            var Restaurants = _repo.Update(restaurant);
            if (Restaurants == null)
            {
                return BadRequest();
            }

            return Ok(Restaurants);
        }

        // DELETE /Restaurants/5
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
            var Restaurants = _repo.Delete(id);

            if (Restaurants == null)
            {
                return new NoContentResult();
            }

            return Ok(Restaurants);

        }
    }
}
