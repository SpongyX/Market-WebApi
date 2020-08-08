using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarketWithDependency.Data;
using MarketWithDependency.Contracts;

namespace MarketWithDependency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuffsController : ControllerBase
    {
        private readonly IStuffRepository _repo;

        public StuffsController(IStuffRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Stuffs
        [HttpGet]
        public Task<ActionResult<IEnumerable<Stuff>>> GetStuffs()
        {
            return (Task<ActionResult<IEnumerable<Stuff>>>)_repo.FindAll();
        }

        // GET: api/Stuffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stuff>> GetStuff(int id)
        {
            var stuff = _repo.FindById(id);
            if (stuff == null)
                return NotFound();
            return stuff;
        }
            // PUT: api/Stuffs/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutStuff(Stuff stuff)
            {
                try
                {
                    _repo.Update(stuff);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return NoContent();
            }

            // POST: api/Stuffs
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<Stuff>> PostStuff(Stuff stuff)
            {
                _repo.Create(stuff);
                return CreatedAtAction("GetStuff", new { id = stuff.Id }, stuff);
            }

            // DELETE: api/Stuffs/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<Stuff>> DeleteStuff(int id)
            {
                var stuff = _repo.FindById(id);
                if (stuff == null)
                    return NotFound();
                _repo.Delete(stuff);
                _repo.Save();
                return stuff;
            }
        }
    }
