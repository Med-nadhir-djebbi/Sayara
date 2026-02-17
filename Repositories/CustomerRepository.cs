using Microsoft.EntityFrameworkCore;
using tpFINAL.Data;
using tpFINAL.Models;

namespace tpFINAL.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomersWithMembership()
        {
            return _context.Customers.Include(c => c.Membership).ToList();
        }

    }
}
