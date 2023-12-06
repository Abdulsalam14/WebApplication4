using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dtos;
using WebApplication4.Entities;
using WebApplication4.Services.Abstract;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetAll();

            var datatoreturn = products.Select(p =>
                {
                    return new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        Discount = p.Discount
                    };
                });

            return Ok(datatoreturn);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.Get(p => p.Id == id);
            if(product==null)return NotFound();
            var datatoreturn = new ProductDto
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                Discount = product.Discount
            };
            return Ok(datatoreturn);
        }

        [HttpGet("GetHigherPrices")]
        public IActionResult GetHigherPrices()
        {
            var products=_productService.GetHigher();
            var datatoreturn = products.Select(p =>
            {
                return new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Discount = p.Discount
                };
            });

            return Ok(datatoreturn);
        }

        [HttpGet("GetHigherDiscounts")]
        public IActionResult GetHigherDiscounts()
        {
            var products = _productService.GetHigherDiscounts();
            var datatoreturn = products.Select(p =>
            {
                return new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Discount = p.Discount
                };
            });

            return Ok(datatoreturn);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductExtendDto value)
        {
            try
            {
                var entity = new Product
                {
                    Name = value.Name,
                    Price = value.Price,
                    Discount = value.Discount
                };

                _productService.Add(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] ProductExtendDto value)
        {

            try
            {
                var item = _productService.Get(p => p.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                item.Name = value.Name;
                item.Price = value.Price;
                item.Discount = value.Discount;
                _productService.Update(item);
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
                var item = _productService.Get(p => p.Id == id);
                if (item == null)
                {
                    return NotFound();
                }
                _productService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
