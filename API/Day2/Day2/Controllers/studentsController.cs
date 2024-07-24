using Day2.DTO;
using Day2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Day2.Repository;
using Day2.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentsController : ControllerBase
    {
        //GenericRepository<Student> rep;
        //public studentsController(GenericRepository<Student> rep)
        //{
        //    this.rep = rep;
        //}

       UnitOfWOrks unit;
        public studentsController(UnitOfWOrks unit)
        {
            this.unit = unit;
        }
        [HttpGet]
        [SwaggerOperation(Summary ="method to return all student data",Description ="my desc")]
        [SwaggerResponse(400,"if no student",Type =typeof(void))]
        [SwaggerResponse(200,"if found any student",Type =typeof(List<studentDTO>))]
        [Authorize]
        public ActionResult getall()
        {
            List<Student> sts = unit.StudentsRepository.selectall();
            List<studentDTO> stsdto= new List<studentDTO>();

            foreach(Student s in sts)
            {
                studentDTO stdto = new studentDTO()
                {
                    id = s.ID,
                    fullname = s.name,
                    age = s.age,
                    address = s.adddress,
                    departmentName = s.dept.name
                };
                stsdto.Add(stdto);

            }



            return Ok(stsdto);
        }
        /// <summary>
        ///  fun to get student by id
        /// </summary>
        /// <param name="id"> student id</param>
        /// <returns>
        /// 404 if no student found
        /// 200+ student if any student found
        /// </returns>
        /// <remarks>
        /// request example  
        /// /api/students/2
        /// </remarks>
        [HttpGet("{id}")]
        [ProducesResponseType<studentDTO>(200)]
        [ProducesResponseType(404)]
        public ActionResult getbyid(int id)
        {
            Student s=unit.StudentsRepository.selectbyid(id);
            if (s == null) return NotFound();
            else
            {
                studentDTO sdto = new studentDTO()
                {
                    id = s.ID,
                    fullname = s.name,
                    age = s.age,
                    address = s.adddress,
                    departmentName = s.dept.name
                };
                return Ok(sdto);
            }
        }
        [HttpPost]
        [Consumes("application/json")]
        public ActionResult add(Student student)
        {
            unit.StudentsRepository.add(student);
            unit.savechanges();
            return Ok();
        }
    }
}
