using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebApp.Data;
using NewsWebApp.Helpers;
using NewsWebApp.Models;
using NewsWebApp.Repositories;
using NewsWebApp.ViewModels;

namespace NewsWebApp.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
        private readonly IRepository<Tag> _tagRepository;

        public TagsController(IRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public IActionResult Index()

        {
            var tags = _tagRepository.All();
            var viewModel = new TagViewModel
            {
                Tags = tags,
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Create(Tag tag)
        {
            if (!ModelState.IsValid)
                return View();
            tag.Slug = SlugHelper.GenerateSlug(tag.Name);
            _tagRepository.Add(tag);
            _tagRepository.Savechanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var tag = _tagRepository.Get(id);
            if (tag == null)
                return NotFound();
            return View("Edit",tag);
        }

        [HttpPost]
        public IActionResult Edit(Tag tag)
        {
            var rand = new Random();
            var slug = SlugHelper.GenerateSlug(tag.Name);
            while ( _tagRepository.Find(t => t.Slug == slug).Any())
            {
                slug += rand.Next(1000, 9999);
            }
            tag.Slug = slug;
            if (!ModelState.IsValid)
                return View();
            _tagRepository.Update(tag);
            _tagRepository.Savechanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var tag = _tagRepository.Get(id);
            if (tag == null)
                return RedirectToAction(nameof(Index));
            return View(tag);
        }


        public IActionResult DeleteConfirm(int id)
        {
            var tag = _tagRepository.Get(id);
            if (tag == null)
                return RedirectToAction(nameof(Index));
            _tagRepository.Delete(tag);
            _tagRepository.Savechanges();
            return RedirectToAction(nameof(Index));
        }


    }
}