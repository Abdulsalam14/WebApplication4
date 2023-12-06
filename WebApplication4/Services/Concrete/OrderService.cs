using System.Linq.Expressions;
using WebApplication4.Entities;
using WebApplication4.Repositories.Abstract;
using WebApplication4.Services.Abstract;

namespace WebApplication4.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Order entity)
        {
            _orderRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var order=_orderRepository.Get(o=>o.Id==id);
            _orderRepository.Delete(order);
        }

        public Order Get(Expression<Func<Order, bool>> expression)
        {
           return _orderRepository.Get(expression);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void Update(Order entity)
        {
            _orderRepository.Update(entity);
        }
    }
}
