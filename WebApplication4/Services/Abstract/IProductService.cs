using WebApplication4.Entities;

namespace WebApplication4.Services.Abstract
{
    public interface IProductService:IService<Product>
    {
        public IEnumerable<Product> GetHigher();
        public IEnumerable<Product> GetHigherDiscounts();

    }
}
