using System.Linq.Expressions;
using WebApplication4.Data;
using WebApplication4.Entities;
using WebApplication4.Repositories.Abstract;

namespace WebApplication4.Repositories.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ProductTaskDbcontext _context;

        public CustomerRepository(ProductTaskDbcontext context)
        {
            _context = context;
        }
        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public Customer Get(Expression<Func<Customer, bool>> expression)
        {
            var customer = _context.Customers.FirstOrDefault(expression);
            return customer!;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _context.Customers;
            return customers;
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }
    }
}
