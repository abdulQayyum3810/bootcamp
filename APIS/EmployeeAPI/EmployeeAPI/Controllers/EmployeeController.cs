using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeAPI.Controllers
{
    
        public class EmployeeController : Controller
        {


            // GET: Employee
            //
            public List<Employee> Get()
            {
                return new Employee().GetEmployees();
            }

        }
    
}