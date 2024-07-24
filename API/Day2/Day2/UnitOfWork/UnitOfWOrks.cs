using Day2.Models;
using Day2.Repository;

namespace Day2.UnitOfWork
{
    public class UnitOfWOrks
    {
        ITIContext db;
         GenericRepository<Student> studentsRepository;
         GenericRepository<Department> departmentRepository;

        public UnitOfWOrks(ITIContext db)
        {
            this.db = db;
            //studentsRepository = new GenericRepository<Student>(db);
            //departmentRepository = new GenericRepository<Department>(db);
        }

        public GenericRepository<Student> StudentsRepository
        {
            get
            {
                if (studentsRepository == null)
                {
                    studentsRepository = new GenericRepository<Student>(db);

                }
                return studentsRepository;
            }
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if(departmentRepository == null)
                {
                    departmentRepository = new GenericRepository<Department>(db);
                }
                return departmentRepository;
            }
        }
        public void savechanges()
        {
            db.SaveChanges();
        }
    }
}
