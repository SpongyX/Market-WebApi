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
    public class StuffDetailsController : ControllerBase
    {
        private readonly IStuffDetailRepository _context;

        public StuffDetailsController(IStuffDetailRepository context)
        {
            _context = context;
        }

        // GET: api/StuffDetails
        [HttpGet]
        [Route("api/StuffDetails/GetStuffDetail")]
        public  Task<ActionResult<IEnumerable<StuffDetail>>> GetstuffDetails()
        {
            return (Task<ActionResult<IEnumerable<StuffDetail>>>)_context.FindAll();
        }

        // GET: api/StuffDetails/5
        [HttpGet("GetStuffDetail-{id}")]
        public async Task<ActionResult<StuffDetail>> GetStuffDetail(int id)
        {
            var stuffDetail = _context.FindById(id);

            if (stuffDetail == null)
            {
                return NotFound();
            }

            return stuffDetail;
        }
        // //GET: api/StuffDetails/5
        [HttpGet("GetStuffDetailByStuffid-{id}")]
        public async Task<ActionResult<IEnumerable<StuffDetail>>> GetStuffDetailByStuffid(int id)
        {
            var stuffDetail = _context.GetStuffDetail(id);

            if (stuffDetail == null)
            {
                return NotFound();
            }

            return stuffDetail.ToList();
        }

        // PUT: api/StuffDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStuffDetail(int id, StuffDetail stuffDetail)
        {
            try
            {
                _context.Update(stuffDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }
            return NoContent();
        }

        // POST: api/StuffDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StuffDetail>> PostStuffDetail(StuffDetail stuffDetail)
        {
            _context.Create(stuffDetail);
            return CreatedAtAction("GetStuffDetail", new { id = stuffDetail.Id }, stuffDetail);
        }

        // DELETE: api/StuffDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StuffDetail>> DeleteStuffDetail(int id)
        {
            var stuffDetail = _context.FindById(id);
            if (stuffDetail == null)
            {
                return NotFound();
            }
            _context.Delete(stuffDetail);
            _context.Save();
            return stuffDetail;
        }

        private bool StuffDetailExists(int id)
        {
            return _context.isExists(id);
        }
    }
}
