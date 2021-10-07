using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWebApp.Data;
using NewsWebApp.Models;
using NewsWebApp.Repositories;
using X.PagedList;

namespace NewsWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {

        private readonly IRepository<Stats> _statsRepository;

        public StatsController(ApplicationDbContext context, IRepository<Stats> statsRepository)
        {
            _statsRepository = statsRepository;
        }

        // GET: api/Stats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stats>>> GetStats()
        {
            return await _statsRepository.All().ToListAsync();
        }

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public ActionResult<Stats> GetStats(int id)
        {
            var stats =  _statsRepository.Get(id);

            if (stats == null)
            {
                return NotFound();
            }

            return stats;
        }

        // PUT: api/Stats/5
        [HttpPut("{id}")]
        public IActionResult PutStats(int id, Stats stats)
        {
            if (id != stats.Id)
            {
                return BadRequest();
            }

            _statsRepository.Update(stats);

            try
            {
                _statsRepository.Savechanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Stats
        [HttpPost]
        public ActionResult<Stats> PostStats(Stats stats)
        {
            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();

            var newStats = new Stats
            {
                Day = DateTime.UtcNow,
                Hits = 1,
                Ip = remoteIpAddress,
                UniqueHits= 1,
            };
            _statsRepository.Add(stats);
            _statsRepository.Savechanges();

            return CreatedAtAction("GetStats", new { id = stats.Id }, stats);
        }

        // DELETE: api/Stats/5
        [HttpDelete("{id}")]
        public ActionResult<Stats> DeleteStats(int id)
        {
            var stats = _statsRepository.Get(id);
            if (stats == null)
            {
                return NotFound();
            }

          _statsRepository.Delete(stats);
            _statsRepository.Savechanges();

            return stats;
        }

        private bool StatsExists(int id)
        {
            return  _statsRepository.Find(e => e.Id == id).Any(e => e.Id == id);
        }
    }

    
}
