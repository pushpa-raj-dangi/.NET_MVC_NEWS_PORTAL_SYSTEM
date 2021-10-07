using NewsWebApp.Data;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Repositories
{
    public class UserRepository : GenericRepository<AppUser>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override AppUser Get(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
