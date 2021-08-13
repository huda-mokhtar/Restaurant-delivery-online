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
    public class BillsController : ControllerBase
    {
        private IGenericService<Bill> _repo;
        public BillsController(IGenericService<Bill> repo)
        {
            _repo = repo;
        }
        // GET: /Bills
        [HttpGet]
        public async Task<ActionResult<List<Bill>>> Get()
        {
            List<Bill> bills  = _repo.GetAll();
            if (bills.Count == 0)
            {
                return NoContent();
            }
            if (bills == null)
            {
                return BadRequest();
            }
            return Ok(bills);
        }

        // GET /Bills/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Bill bill = _repo.GetById(id);

            if (bill == null)
            {
                return NotFound();
            }
            return Ok(bill);
        }
        // POST /Bills
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Bill bill)
        {
            if (bill == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Bill> bills = _repo.Add(bill);

            if (bills == null)
            {
                return BadRequest();
            }
            return Ok(bills);
        }

        //Patch /Bills/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<Bill>> Patch(int id, [FromBody] Bill bill)
        {
            if (bill == null || bill.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Bill Oldbill = _repo.GetById(id);
            if (Oldbill == null)
            {
                return NotFound();
            }

            var bills = _repo.Update(bill);
            if (bills == null)
            {
                return BadRequest();
            }

            return Ok(bills);
        }

        // DELETE /Bills/5
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
            var bills = _repo.Delete(id);

            if (bills == null)
            {
                return new NoContentResult();
            }

            return Ok(bills);

        }
    }
}
