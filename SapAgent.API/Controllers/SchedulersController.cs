using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SapAgent.DataAccess.Concrete.EntityFramework;
using SapAgent.Entities.Concrete.Config;

namespace SapAgent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulersController : ControllerBase
    {
        private readonly SapAgentContext _context;

        public SchedulersController(SapAgentContext context)
        {
            _context = context;
        }

        // GET: api/Schedulers
        [HttpGet]
        public IEnumerable<Scheduler> GetSchedulers()
        {
            return _context.Schedulers;
        }

        // GET: api/Schedulers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduler([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scheduler = await _context.Schedulers.FindAsync(id);

            if (scheduler == null)
            {
                return NotFound();
            }

            return Ok(scheduler);
        }

        // PUT: api/Schedulers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScheduler([FromRoute] int id, [FromBody] Scheduler scheduler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scheduler.ID)
            {
                return BadRequest();
            }

            _context.Entry(scheduler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchedulerExists(id))
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

        // POST: api/Schedulers
        [HttpPost]
        public async Task<IActionResult> PostScheduler([FromBody] Scheduler scheduler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Schedulers.Add(scheduler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScheduler", new { id = scheduler.ID }, scheduler);
        }

        // DELETE: api/Schedulers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScheduler([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var scheduler = await _context.Schedulers.FindAsync(id);
            if (scheduler == null)
            {
                return NotFound();
            }

            _context.Schedulers.Remove(scheduler);
            await _context.SaveChangesAsync();

            return Ok(scheduler);
        }

        private bool SchedulerExists(int id)
        {
            return _context.Schedulers.Any(e => e.ID == id);
        }
    }
}