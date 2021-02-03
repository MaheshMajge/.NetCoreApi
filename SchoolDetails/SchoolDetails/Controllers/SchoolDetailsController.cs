using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDetails.Models;
using SchoolDetails.Repository;

namespace SchoolDetails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolDetailsController : ControllerBase
    {
        private readonly ICommonRepository commonRepository;

        public SchoolDetailsController(ICommonRepository commonRepository)
        {
            this.commonRepository = commonRepository;
        }
        [HttpGet]
        public IEnumerable<SchoolDetail> GetSchoolDbSet()
        {
            return commonRepository.GetSchoolDbSet();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDetail>> GetSchoolDetail(int id)
        {
            var schoolDetail = await Task.FromResult(commonRepository.GetSchoolDetail(id));

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
            try
            {
                await Task.FromResult(commonRepository.PutSchoolDetail(id, schoolDetail));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!commonRepository.SchoolDetailExists(id))
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

            await Task.FromResult(commonRepository.PostSchoolDetail(schoolDetail));
            return CreatedAtAction("GetSchoolDetail", new { id = schoolDetail.ID }, schoolDetail);
        }

        // DELETE: api/SchoolDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SchoolDetail>> DeleteSchoolDetail(int id)
        {
            var schoolDetail = await Task.FromResult(commonRepository.DeleteSchoolDetail(id));
            if (!schoolDetail)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
