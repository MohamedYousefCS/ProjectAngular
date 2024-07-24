using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day2.Models;
using Day2.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentTempsController : ControllerBase
    {
        private readonly ITIContext _context;

        public DepartmentTempsController(ITIContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentTemps
        [HttpGet]
        [Authorize(Roles ="instructors")]
        public async Task<ActionResult<IEnumerable<DepartmentTemp>>> GetDepartmentTemps()
        {
             return await _context.DepartmentTemps.Select(a=>new DepartmentTemp() { Id=a.Id,Name=a.Name,NumberOfStudents=a.NumberOfStudents}).ToListAsync();
        }

        // GET: api/DepartmentTemps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentTemp>> GetDepartmentTemp(int id)
        {
            var departmentTemp = await _context.DepartmentTemps.FindAsync(id);

            if (departmentTemp == null)
            {
                return NotFound();
            }

            return departmentTemp;
        }

        // PUT: api/DepartmentTemps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartmentTemp(int id, DepartmentTemp departmentTemp)
        {
            if (id != departmentTemp.Id)
            {
                return BadRequest();
            }

            _context.Entry(departmentTemp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentTempExists(id))
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

        // POST: api/DepartmentTemps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentTemp>> PostDepartmentTemp(DepartmentTemp departmentTemp)
        {
            _context.DepartmentTemps.Add(departmentTemp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartmentTemp", new { id = departmentTemp.Id }, departmentTemp);
        }

        // DELETE: api/DepartmentTemps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartmentTemp(int id)
        {
            var departmentTemp = await _context.DepartmentTemps.FindAsync(id);
            if (departmentTemp == null)
            {
                return NotFound();
            }

            _context.DepartmentTemps.Remove(departmentTemp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentTempExists(int id)
        {
            return _context.DepartmentTemps.Any(e => e.Id == id);
        }
    }
}
