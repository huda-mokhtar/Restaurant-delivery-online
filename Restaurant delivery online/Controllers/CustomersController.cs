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
    public class CustomersController : ControllerBase
    {
        private IGenericService<Customer> _repo;
        public CustomersController(IGenericService<Customer> repo)
        {
            _repo = repo;
        }
        // GET: /Restaurants
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Get()
        {
            List<Customer> Customers = _repo.GetAll();
            if (Customers.Count == 0)
            {
                return NoContent();
            }
            if (Customers == null)
            {
                return BadRequest();
            }
            return Ok(Customers);
        }

        // GET /Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Customer Customer = _repo.GetById(id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Ok(Customer);
        }
        // POST /Customers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer Customer)
        {
            if (Customer == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Customer> Customers = _repo.Add(Customer);

            if (Customers == null)
            {
                return BadRequest();
            }
            return Ok(Customers);
        }

        //Patch /Customers/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<Customer>> Patch(int id, [FromBody] Customer customer)
        {
            if (customer == null || customer.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer Customer = _repo.GetById(id);
            if (Customer == null)
            {
                return NotFound();
            }

            var Customers = _repo.Update(customer);
            if (Customers == null)
            {
                return BadRequest();
            }

            return Ok(Customers);
        }

        // DELETE /Customers/5
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
            var Customers = _repo.Delete(id);

            if (Customers == null)
            {
                return new NoContentResult();
            }

            return Ok(Customers);

        }
    }
}
