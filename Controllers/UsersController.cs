using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Data;
using NewsWebApp.Models;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment, UserManager<AppUser> userManager)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            

            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {

            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            var userViewModel = new UserViewModel
            {
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
                Profile = user.ProfileImg,


            };
            return View(userViewModel);
        }
        [HttpPost]
        public IActionResult Edit(UserViewModel appUser)
        {
            string profile = fileUpload(appUser.ProfileImg);
            var userInDb = _context.Users.FirstOrDefault(u => u.Id == appUser.Id);
            userInDb.Email = appUser.Email;
            userInDb.PhoneNumber = appUser.PhoneNumber;
            userInDb.UserName = appUser.UserName;
            userInDb.ProfileImg = profile;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }   


        string fileUpload(IFormFile file)
        {
            string unique = null;
            try
            {
                if (file.FileName != null)

                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                    unique = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, unique);
                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            return unique;
        }
    }


}