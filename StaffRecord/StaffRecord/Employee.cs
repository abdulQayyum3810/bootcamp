using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.UI;
using System.Web.UI.WebControls;
namespace StaffRecord
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public List<Employee> staffData;
        public Employee()
        {
            staffData = this.GetEmployeeData();
        }
        public Employee(int id, string name, string role, double salary, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Role = role;
            this.Salary = salary;
            this.Address = address;
        }

        public List<Employee> GetEmployeeData()
        {
            Random randInt = new Random();
            var EmployeeData = new List<Employee>();

            for(int i = 1; i <= 100; i++)
            {
                string idStr = $"{i}{randInt.Next(10, 50)}";
                int id = Convert.ToInt32(idStr);
                EmployeeData.Add(new Employee(id, "Haji Abdul Shakoor", "Business Analyst", 100, "Basti Malook"));
            }

            return EmployeeData; 
        }
        

    }
}
