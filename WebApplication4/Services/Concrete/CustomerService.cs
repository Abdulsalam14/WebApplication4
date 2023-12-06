using System.Linq.Expressions;
using WebApplication4.Entities;
using WebApplication4.Repositories.Abstract;
using WebApplication4.Services.Abstract;

namespace WebApplication4.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository  _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        
        public void Add(Customer entity)
        {
            _customerRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var customer=_customerRepository.Get(c=>c.Id==id);
            _customerRepository.Delete(customer);
        }

        public Customer Get(Expression<Func<Customer, bool>> expression)
        {
            return _customerRepository.Get(expression);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public void Update(Customer entity)
        {
            _customerRepository.Update(entity);
        }
    }
}
