using tpFINAL.Models;

namespace tpFINAL.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {

        IEnumerable<Customer> GetCustomersWithMembership();

    }
}
