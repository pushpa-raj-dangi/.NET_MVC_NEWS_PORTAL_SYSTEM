using NewsWebApp.Data;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Repositories
{
    public class TagRepository : GenericRepository<Tag>
    {
        public TagRepository(ApplicationDbContext context) : base(context)
        {

        }

        public override Tag Add(Tag entity)
        {
            return base.Add(entity);
        }
    }
}
