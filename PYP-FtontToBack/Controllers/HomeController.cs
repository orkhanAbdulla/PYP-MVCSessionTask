using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PYP_FtontToBack.DAL;
using PYP_FtontToBack.Models;
using System.Diagnostics;

namespace PYP_FtontToBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View(_context.Products.Include(x=>x.ProductPhotos).AsQueryable());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}