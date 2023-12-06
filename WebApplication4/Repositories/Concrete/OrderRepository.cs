using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication4.Data;
using WebApplication4.Entities;
using WebApplication4.Repositories.Abstract;

namespace WebApplication4.Repositories.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ProductTaskDbcontext _context;

        public OrderRepository(ProductTaskDbcontext context)
        {
            _context = context;
        }
        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public Order Get(Expression<Func<Order, bool>> expression)
        {
            var order = _context.Orders
                .Include(o => o.Product)
                .Include(o => o.Customer)
                .FirstOrDefault(expression);
            return order!;
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = _context.Orders.Include(o => o.Product)
                .Include(o => o.Customer);
            return orders;
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
