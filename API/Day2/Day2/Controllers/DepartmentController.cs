using Day2.DTO;
using Day2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day2.Repository;
using Day2.UnitOfWork;
namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        UnitOfWOrks unit;
        public DepartmentController(UnitOfWOrks unit)
        {
            this.unit = unit;
        }
        [HttpGet]
        public ActionResult getall()
        {
            List<Department> depts = unit.DepartmentRepository.selectall();
            List<departmentDTO> deptsDTO = new List<departmentDTO>();
            foreach (var d in depts)
            {
                departmentDTO ddto = new departmentDTO()
                {
                    id = d.ID,
                    name = d.name,
                    location = d.Loc,
                    studentsNames = d.Students.Select(n => n.name).ToList()
                };

                deptsDTO.Add(ddto);

            }
            return Ok(deptsDTO);
        }


        [HttpGet("{id}")]
        public ActionResult getbyid(int id)
        {
            Department d = unit.DepartmentRepository.selectbyid(id);
            if (d == null) return NotFound();
            else
            {
                departmentDTO ddto = new departmentDTO()
                {
                    id = d.ID,
                    name = d.name,
                    location = d.Loc,
                    studentsNames = d.Students.Select(n => n.name).ToList()
                };

                //foreach(Student s in d.Students)
                //{
                //    ddto.studentsNames.Add(s.name);
                //}
                return Ok(ddto);
            }

        }
    }
}
