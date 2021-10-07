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

namespace NewsWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<int>> GetComments()
        {
            return await _context.Comments.Include(u=>u.AppUser).Where(x=>x.IsApproved==false).CountAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }
        [Authorize]
        [HttpPut("{id}")]

        public IActionResult EditComment(int id)
        {
            var comment = _context.Comments.SingleOrDefault(g => g.CommentId == id);
                comment.IsApproved = true;
                _context.SaveChanges();
         return Ok(comment);
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutComment(int id, [FromBody] Comment comment)
        //{
        //    if (id != comment.CommentId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(comment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CommentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //[HttpPost]
        //public async Task<ActionResult<Comment>> PostComment(Comment comment)
        //{
        //    _context.Comments.Add(comment);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetComment", new { id = comment.CommentId }, comment);
        //}

        
        [HttpDelete("{id}")]
        public async Task<ActionResult<Comment>> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return Ok(comment);
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
