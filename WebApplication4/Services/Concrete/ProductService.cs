using System.Linq.Expressions;
using WebApplication4.Entities;
using WebApplication4.Repositories.Abstract;
using WebApplication4.Services.Abstract;

namespace WebApplication4.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Add(Product entity)
        {
            _productRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var product= _productRepository.Get(p=>p.Id == id);
            _productRepository.Delete(product);
        }

        public Product Get(Expression<Func<Product, bool>> expression)
        {
            return _productRepository.Get(expression);
        }

        public IEnumerable<Product> GetHigher()
        {
            var products = _productRepository.GetAll().OrderByDescending(o=>o.Price).Take(2);
            return products;
        }

        public IEnumerable<Product> GetHigherDiscounts()
        {
            var products = _productRepository.GetAll().OrderByDescending(o => o.Discount).Take(2);
            return products;
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
