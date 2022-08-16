using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Runtime.Caching;
using System.Data;

namespace AssignmentAPI.Controllers
{
    public class Student{
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string Department { get; set; }

        public string GetStudents()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-89TMV54\SQLEXPRESS;Initial Catalog=AspNetProject1;Persist Security Info=True;User ID=sa;Password=abdul95@uet");
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM student", con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            return JsonConvert.SerializeObject(dt);
        }
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public string Get()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache["StudentList"] == null)
            {
                CacheItemPolicy cacheItemPolicy = new CacheItemPolicy();
                cacheItemPolicy.AbsoluteExpiration = DateTime.Now.AddHours(1.0);
                Student student = new Student();

                CacheItem cacheitem = new CacheItem("StudentList", student.GetStudents());
                cache.Add(cacheitem, cacheItemPolicy);
            }
            var data = cache.Get("StudentList") as string ;
            return data;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
