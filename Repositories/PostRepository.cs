using Microsoft.EntityFrameworkCore;
using NewsWebApp.Data;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsWebApp.Repositories
{
    public class PostRepository : GenericRepository<Post>
    {
        public PostRepository(ApplicationDbContext _context) : base(_context)
        {
        }

        public override Post Update(Post entity)
        {
            var post = _context.Posts.Include(p => p.PostCategories).Include(p => p.PostTags).Include(u=>u.AppUser)
                    .Where(p => p.Id == entity.Id).FirstOrDefault();

            post.Name = entity.Name;
            post.Picture = entity.Picture;
            post.AppUserId = post.AppUser.Id;
            post.Slug = entity.Slug;
            post.Content = entity.Content;
            post.PostStatus = entity.PostStatus;
            post.PostCategories = entity.PostCategories;
            post.CreatedDate = entity.CreatedDate;
            post.PostTags = entity.PostTags;
            return base.Update(entity);
        }

        public override IEnumerable<Post> Find(Expression<Func<Post, bool>> predicate)
        {
            return _context.Posts.Include(p => p.PostCategories)
                .ThenInclude(c => c.Category)
                .Include(tag => tag.PostTags)
                .ThenInclude(pt => pt.Tag)
                .Include(u => u.AppUser)
                .Where(predicate)
                .OrderByDescending(pid => pid.CreatedDate)
                .Where(x => x.PostStatus == PostStatus.Publish).ToList();
        }

        public override IEnumerable<Post> All()
        {
            return _context.Posts.Include(p => p.PostCategories)
                .ThenInclude(c => c.Category)
                .Include(tag => tag.PostTags)
                .ThenInclude(pt => pt.Tag)
                .Include(u => u.AppUser)
                .OrderByDescending(pid => pid.CreatedDate)
                .Where(x => x.PostStatus == PostStatus.Publish).ToList();
        }

       

    }
}
