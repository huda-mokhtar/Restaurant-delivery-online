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
    public class CitiesController : ControllerBase
    {
        private ICity _repo;
        public CitiesController(ICity repo)
        {
            _repo = repo;
        }
        // GET: /cities
        [HttpGet]
        public async Task<ActionResult<List<City>>> Get()
        {
            List<City> cities = _repo.GetAll();
            if (cities.Count == 0)
            {
                return NoContent();
            }
            if (cities == null)
            {
                return BadRequest();
            }
            return Ok(cities);
        }

        // GET /cities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            City city =_repo.GetById(id);

            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }
        // GET /cities/Cairo
        [HttpGet,Route("GetName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            if (name== "")
            {
                return BadRequest();
            }

            City city =_repo.GetByName(name);

            if (city == null)
            {
                return NotFound();
            }
            return Ok(city);
        }

        // POST /cities
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City city)
        {
            if (city == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<City> cities =_repo.Add(city);

            if (cities == null)
            {
                return BadRequest();
            }
            return Ok(cities);
        }

        //Patch /cities/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<City>> Patch(int id, [FromBody] City city)
        {
            if ( city == null || city.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            City City =  _repo.GetById(id);
            if (City == null)
            {
                return NotFound();
            }

            var cities = _repo.Update(city);
            if (cities == null)
            {
                return BadRequest();
            }

            return Ok(cities);
        }

        // DELETE api/cities/5
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
            var cities = _repo.Delete(id);

            if (cities == null)
            {
                return new NoContentResult();
            }
           
            return Ok(cities);
            
        }
    }
}

