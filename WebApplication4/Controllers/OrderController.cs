using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dtos;
using WebApplication4.Entities;
using WebApplication4.Services.Abstract;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetAll();

            var datatoreturn = orders.Select(o =>
            {
                return new OrderDto
                {
                    Id = o.Id,
                    OrderDate = o.OrderDate,
                    ProductName=o.Product?.Name,
                    CustomerName=o.Customer?.Name
                };
            });

            return Ok(datatoreturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var order = _orderService.Get(o => o.Id == id);
            if (order == null) return NotFound();
            var datatoreturn = new OrderDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                ProductName = order.Product?.Name,
                CustomerName = order.Customer?.Name
            };
            return Ok(datatoreturn);
        }


        [HttpPost]
        public IActionResult Post([FromBody] OrderExtendDto value)
        {
            try
            {
                var entity = new Order
                {
                    OrderDate = DateTime.Now,
                    ProductId=value.ProductId,
                    CustomerId=value.CustomerId,
                };
                _orderService.Add(entity);
                var addedorder = _orderService.Get(o => o.Id == entity.Id);
                var datatoreturn = new OrderDto
                {
                    Id = addedorder.Id,
                    OrderDate = addedorder.OrderDate,
                    ProductName = addedorder.Product?.Name,
                    CustomerName = addedorder.Customer?.Name
                };
                return Ok(datatoreturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OrderExtendDto value)
        {

            try
            {
                var item = _orderService.Get(o => o.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                item.ProductId=value.ProductId;
                item.CustomerId=value.CustomerId;
                _orderService.Update(item);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = _orderService.Get(c => c.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                _orderService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
