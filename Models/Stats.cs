using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebApp.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public DateTime Day { get; set; }
        public int Hits { get; set; }
        public int UniqueHits { get; set; }
        public string Ip { get; set; }

    }
}
