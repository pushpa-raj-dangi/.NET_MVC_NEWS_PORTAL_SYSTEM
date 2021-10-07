using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Data;
using NewsWebApp.Models;
using NewsWebApp.Repositories;

namespace NewsWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase

    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Post> _repository;

        public PostsController(ApplicationDbContext context, IRepository<Post> repository)
        {
            _context = context;
            _repository = repository;
        }

        public IActionResult All()
        {
            return  Ok(_repository.All());
        }


        [HttpGet("draft/count")]
        public IActionResult DraftCount()
        {

            var post = _context.Posts.OrderByDescending(pid => pid.CreatedDate).Where(x => x.PostStatus == PostStatus.Draft).Count();

            return Ok(post);
        }
        [HttpGet("trash/count")]
        public IActionResult TrashCount()
        {
            var post = _context.Posts.OrderByDescending(pid => pid.CreatedDate).Where(x => x.PostStatus == PostStatus.Trash).Count();

            return Ok(post);
        }

        [HttpGet("api/[controller]/{id}")]
        public IActionResult GetSingle(int id)
        {
            var posts = _context.Posts.SingleOrDefault(ps=>ps.Id==id);
            return Ok(posts);
        }
        [Authorize]

        [HttpDelete("{id}")]
        public async Task<ActionResult<Post>> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok(post);
        }
        
        [HttpPost("{id}")]

        public async Task<ActionResult<Post>> EditPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            post.PostStatus = PostStatus.Trash;
            await _context.SaveChangesAsync();

            return Ok(post);
        }

        //private void ScheduledPost()
        //{
        //    if(DateTime.Now)
        //}

    }




}