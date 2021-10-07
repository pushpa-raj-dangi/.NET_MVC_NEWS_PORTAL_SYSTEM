using NewsWebApp.Data;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NewsWebApp.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Category Add(Category entity)
        {
            var category = _context.Categories.Single(c=>c.Id == entity.Id);

            category.Slug = entity.Slug;
            category.Name = entity.Name;
            return base.Add(entity);
        }

        public override IEnumerable<Category> Find(Expression<Func<Category, bool>> predicate)
        {
            return base.Find(predicate);
        }

        
    }
}
