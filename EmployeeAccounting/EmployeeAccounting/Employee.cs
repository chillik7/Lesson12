namespace EmployeeAccounting
{
    public class Employee
    {
        public string FullName { get; set; }
        public string Position { get; set; }

        public Employee(string fullName, string position)
        {
            FullName = fullName;
            Position = position;
        }
    }
}