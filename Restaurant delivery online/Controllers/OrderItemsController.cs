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
    public class OrderItemsController : ControllerBase
    {
        private IGenericService<OrderItem> _repo;
        public OrderItemsController(IGenericService<OrderItem> repo)
        {
            _repo = repo;
        }
        // GET: /OrderItems
        [HttpGet]
        public async Task<ActionResult<List<OrderItem>>> Get()
        {
            List<OrderItem> orderItems = _repo.GetAll();
            if (orderItems.Count == 0)
            {
                return NoContent();
            }
            if (orderItems == null)
            {
                return BadRequest();
            }
            return Ok(orderItems);
        }

        // GET /OrderItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            OrderItem orderItem = _repo.GetById(id);

            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }
        // POST /OrderItems
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderItem orderItem)
        {
            if (orderItem == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<OrderItem> orderItems = _repo.Add(orderItem);

            if (orderItems == null)
            {
                return BadRequest();
            }
            return Ok(orderItems);
        }

        //Patch /OrderItems/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<OrderItem>> Patch(int id, [FromBody] OrderItem orderItem)
        {
            if (orderItem == null || orderItem.Id != id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrderItem OldorderItem = _repo.GetById(id);
            if (OldorderItem == null)
            {
                return NotFound();
            }

            var orderItems = _repo.Update(orderItem);
            if (orderItems == null)
            {
                return BadRequest();
            }

            return Ok(orderItems);
        }

        // DELETE /OrderItems/5
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
            var orderItems = _repo.Delete(id);

            if (orderItems == null)
            {
                return new NoContentResult();
            }

            return Ok(orderItems);

        }
    }
}
