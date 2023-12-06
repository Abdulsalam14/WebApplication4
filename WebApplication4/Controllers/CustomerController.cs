using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dtos;
using WebApplication4.Entities;
using WebApplication4.Services.Abstract;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.GetAll();

            var datatoreturn = customers.Select(c =>
            {
                return new CustomerDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname
                    
                };
            });

            return Ok(datatoreturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.Get(c => c.Id == id);
            if (customer == null) return NotFound();
            var datatoreturn = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Surname =customer.Surname
            };
            return Ok(datatoreturn);
        }


        [HttpPost]
        public IActionResult Post([FromBody] CustomerExtendDto value)
        {
            try
            {
                var entity = new Customer
                {
                    Name = value.Name,
                    Surname = value.Surname
                };
                _customerService.Add(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerExtendDto value)
        {

            try
            {
                var item = _customerService.Get(c => c.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Name = value.Name;
                item.Surname = value.Surname;
                _customerService.Update(item);
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
                var item = _customerService.Get(c => c.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                _customerService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

