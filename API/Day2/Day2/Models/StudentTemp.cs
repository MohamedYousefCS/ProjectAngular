using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class StudentTemp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrackName { get; set; }
        //public int? Age { get; set; }
        //public int DeptId { get; set; }

        //[ForeignKey("DeptId")]
        //public virtual DepartmentTemp DepartmentTemp { get; set; }
    }
    public class DepartmentTemp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int  NumberOfStudents { get; set; }
        //public virtual List<Student> Students { get; set; } = new List<Student>();
    }
}
