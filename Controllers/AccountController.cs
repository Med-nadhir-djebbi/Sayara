using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tpFINAL.Models;
using tpFINAL.Data;

namespace tpFINAL.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public IActionResult GetAllUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult PanierParUser()
        {
            var currentuser = _userManager.GetUserId(User);
            var pro = _context.paniers
            .Where(c=>c.UserID==currentuser)
            .ToList();
            return View(pro);
        }

    }
}
