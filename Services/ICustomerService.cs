using tpFINAL.Models;

namespace tpFINAL.Services
{
    public interface ICustomerService
    {

        IEnumerable<Customer> GetCustomers();

    }
}
