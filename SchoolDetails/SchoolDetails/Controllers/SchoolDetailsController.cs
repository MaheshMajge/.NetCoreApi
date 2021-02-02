using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDetails.Models;

namespace SchoolDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolDetailsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public SchoolDetailsController(SchoolDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  IEnumerable<SchoolDetail> GetSchoolDbSet()
        {
            return  _context.SchoolDbSet.ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDetail>> GetSchoolDetail(int id)
        {
            var schoolDetail = await _context.SchoolDbSet.FindAsync(id);

            if (schoolDetail == null)
            {
                return NotFound();
            }
            return schoolDetail;
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchoolDetail(int id, SchoolDetail schoolDetail)
        {
            if (id != schoolDetail.ID)
            {
                return BadRequest();
            }

            _context.Entry(schoolDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolDetailExists(id))
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

        // POST: api/SchoolDetails
        [HttpPost]
        public async Task<ActionResult<SchoolDetail>> PostSchoolDetail(SchoolDetail schoolDetail)
        {
            _context.SchoolDbSet.Add(schoolDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchoolDetail", new { id = schoolDetail.ID }, schoolDetail);
        }

        // DELETE: api/SchoolDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SchoolDetail>> DeleteSchoolDetail(int id)
        {
            var schoolDetail = await _context.SchoolDbSet.FindAsync(id);
            if (schoolDetail == null)
            {
                return NotFound();
            }

            _context.SchoolDbSet.Remove(schoolDetail);
            await _context.SaveChangesAsync();

            return schoolDetail;
        }

        private bool SchoolDetailExists(int id)
        {
            return _context.SchoolDbSet.Any(e => e.ID == id);
        }
    }
}
