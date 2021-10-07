using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Data;
using NewsWebApp.Helpers;
using NewsWebApp.Models;
using NewsWebApp.Repositories;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly IRepository<Category> _categoryRepo;

        public CategoriesController(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IActionResult Index()
        {
            var viewModel = new CategoryViewModel
            {
                Categories = _categoryRepo.All()

            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
                return View();
            category.Slug = SlugHelper.GenerateSlug(category.Name);
            _categoryRepo.Add(category);
            _categoryRepo.Savechanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Category cat)
        {
            var rand = new Random();
            var slug = SlugHelper.GenerateSlug(cat.Name);
            while (_categoryRepo.Find(t => t.Slug == slug).Any())
            {
                slug += rand.Next(1000, 9999);
            }
            cat.Slug = slug;
            if (!ModelState.IsValid)
                return View();
           _categoryRepo.Update(cat);
           _categoryRepo.Savechanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var categories = _categoryRepo.Get(id);

            if (categories == null)
                return NotFound();

            return View("Edit", categories);
        }

        [HttpGet]

        public IActionResult Delete(int id)
        {
            var category = _categoryRepo.Get(id);
            if (category == null)
                return RedirectToAction(nameof(Index));
            return View(category);
        }

        public IActionResult DeleteConfirm(int id)
        {
            var category = _categoryRepo.Get(id);
            if (category == null)
                return RedirectToAction(nameof(Index));
            _categoryRepo.Delete(category);
            _categoryRepo.Savechanges();
            return RedirectToAction(nameof(Index));
        }

    }
}