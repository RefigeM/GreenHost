using GreenHost.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenHost.Controllers
{
    public class HomeController : Controller
    {
        private readonly GreenHostDbContext _context;

        public HomeController(GreenHostDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
         
            return View(await _context.Members.Include(x => x.Department).ToListAsync());
        }
    }
}
