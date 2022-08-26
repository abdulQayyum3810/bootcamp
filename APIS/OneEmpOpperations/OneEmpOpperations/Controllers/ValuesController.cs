using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OneEmpOpperations.Controllers
{
    public class ValuesController : ApiController
    {
       

       [Route("EmployeeDetails/{id}")]
        public Employee GetEmployee(int id)
        {

            return new Employee().GetEmployeeDetails(id);
        }
        [Route("AddEmployee")]
        [HttpPost]
        public string AddEmployee(Employee employee) 
        {
            new Employee().CreateEmployee(employee.Name,employee.Department);
            return "Employee Added";
        }
        [Route("UpdateEmployee")]
        [HttpPost]
        public string UpdateEmployee(Employee employee)
        {
            new Employee().UpdateEmployee(employee.Id, employee.Name, employee.Department);
            return "updated employee";
        }


        [Route("DelEmp/{id}")]
        public string DelEmployee(int id)
        {

            new Employee().DeleteEmployee(id);
            return "Deleted";
        }



        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
