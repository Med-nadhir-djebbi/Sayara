using Microsoft.AspNetCore.Mvc;
using tpFINAL.Models;
using tpFINAL.Services;

namespace tpFINAL.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var customers = _customerService.GetCustomers();

            var customerViewModels = customers.Select(c => new CustomerViewModel
            {
                Id = c.Id,
                Name = c.Name,
                DiscountRate = c.Membership != null ? c.Membership.DiscountRate : 0
            });

            return View(customerViewModels);
        }

    }
}