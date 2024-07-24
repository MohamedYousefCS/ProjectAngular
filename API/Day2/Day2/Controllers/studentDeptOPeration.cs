using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day2.Repository;
using Day2.Models;
using Day2.UnitOfWork;
namespace Day2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentDeptOPeration : ControllerBase
    {
        //GenericRepository<Student> studentrep;
        //GenericRepository<Department> deptRep;

        //public studentDeptOPeration(GenericRepository<Student> studentrep , GenericRepository<Department> deptRep)
        //{
        //    this.studentrep = studentrep;
        //    this.deptRep = deptRep;
        //}

        UnitOfWOrks myunit;

        public studentDeptOPeration(UnitOfWOrks myunit)
        {
            this.myunit = myunit;
        }
        [HttpPost]
        public ActionResult add(Student s)
        {
            myunit.DepartmentRepository.add(s.dept);
          //  myunit.DepartmentRepository.save();
            myunit.StudentsRepository.add(s);
           // myunit.StudentsRepository.save();
            //myunit.departmentRepository.save();
             myunit.savechanges();
            return Ok();


        }
    }
}
