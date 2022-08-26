using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace EmployeeAPI.Controllers
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public List<Employee> GetEmployees()
        {
            List<Employee> EmployeeList = new List<Employee>();
            SqlConnection con = new SqlConnection(@"Data Source=CMDLHRDB01;Initial Catalog=4087-AspNetProject1;User ID=sa;Password=CureMD2022");

            con.Open();
            SqlDataAdapter SDA = new SqlDataAdapter("select * from Employee ORDER BY id", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                employee.Name = dt.Rows[i]["Name"].ToString();
                employee.Department = dt.Rows[i]["Department"].ToString();
                EmployeeList.Add(employee);
            }
            con.Close();
            return (EmployeeList);
        }


    }

    public class ValuesController : ApiController
    {
       // [Route("employee")]
        public List<Employee> Get()
        {
            return new Employee().GetEmployees();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
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
