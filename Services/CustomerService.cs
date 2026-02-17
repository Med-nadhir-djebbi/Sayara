using tpFINAL.Models;
using tpFINAL.Repositories;

namespace tpFINAL.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _repository.GetCustomersWithMembership();
        }

    }
}
