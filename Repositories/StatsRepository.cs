using NewsWebApp.Data;
using NewsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Repositories
{
    public class StatsRepository : GenericRepository<Stats>
    {
        public StatsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
