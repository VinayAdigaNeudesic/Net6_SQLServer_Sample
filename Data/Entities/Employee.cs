namespace Sample_API.Data.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public DateTime CreateDate { get; set; }

        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
