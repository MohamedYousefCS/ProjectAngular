using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Day2.Models;

namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsTempController : ControllerBase
    {
        private readonly ITIContext _context;

        public DepartmentsTempController(ITIContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentsTemp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentTemp>>> GetDepartments()
        {
            return await _context.DepartmentTemps.ToListAsync();
        }

        // GET: api/DepartmentsTemp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentTemp>> GetDepartment(int id)
        {
            var department = await _context.DepartmentTemps.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/DepartmentsTemp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentTemp department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/DepartmentsTemp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostDepartment(string deptname, int numberOfStds)
        {
            _context.DepartmentTemps.Add(new DepartmentTemp(){Name = deptname, NumberOfStudents = numberOfStds});
                await _context.SaveChangesAsync();
            return Created();
        }

        // DELETE: api/DepartmentsTemp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.DepartmentTemps.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.DepartmentTemps.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _context.DepartmentTemps.Any(e => e.Id == id);
        }
    }
}
