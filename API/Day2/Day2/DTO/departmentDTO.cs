namespace Day2.DTO
{
    public class departmentDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string location { get; set; }

        public List<string> studentsNames { get; set; } = new List<string>();
    }
}
