using Microsoft.AspNetCore.Mvc;
using Notes_Website.Models;
using System.Diagnostics;
using Notes_Website.Data;
using Microsoft.EntityFrameworkCore;

namespace Notes_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(bool? forgetuser)
        {
            if (forgetuser != null) // Delete the user name cookie
            {
                const string CookieKeyUName = "_UserName";
                Response.Cookies.Delete(CookieKeyUName);
            }

            ViewBag.CurrentDate = DateTime.Now;
            ViewBag.NoteCount = _context.NoteModel.Count();
            ViewBag.LastNDate = _context.NoteModel.OrderBy(n => n.Added).FirstOrDefault();

            //return View();
            return await Notes();
        }

        public async Task<IActionResult> Notes()
        {
            IQueryable<NoteModel> query = _context.NoteModel;

            query = query.OrderByDescending(m => m.Added);

            query = query.Take(1);
            return View("Index", await query.ToListAsync());
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