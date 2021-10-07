using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Data;
using NewsWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dvm = new DashboardViewModel
            {
                NoOfComments = _context.Comments.ToList().Count(),
                NumOfCategory = _context.Categories.ToList().Count(),
                NumOfPublishedPost = _context.Posts.ToList().Count(),
                NoOfUsers =_context.Users.ToList().Count()

            };
            return View(dvm);
        }
    }
}
