using System.Linq.Expressions;
using WebApplication4.Data;
using WebApplication4.Entities;
using WebApplication4.Repositories.Abstract;

namespace WebApplication4.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductTaskDbcontext _context;

        public ProductRepository(ProductTaskDbcontext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();

        }

        public Product Get(Expression<Func<Product, bool>> expression)
        {
            var product = _context.Products.FirstOrDefault(expression);
            return product!;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
