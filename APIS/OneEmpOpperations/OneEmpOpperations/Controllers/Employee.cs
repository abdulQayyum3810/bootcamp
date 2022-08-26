
using System;
using System.Data.SqlClient;
using System.Data;

namespace OneEmpOpperations.Controllers
{
    public class Employee

    {
        SqlConnection con = new SqlConnection(@"Data Source=CMDLHRDB01;Initial Catalog=4087-AspNetProject1;User ID=sa;Password=CureMD2022");
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public Employee GetEmployeeDetails(int id)
        {
            con.Open();
            //string query = "[dbo].[GetEmployee];";
            //SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            //SDA.SelectCommand.CommandType = CommandType.StoredProcedure;
            //SDA.SelectCommand.Parameters.Add(new SqlParameter("@id", id));
            //SDA.SelectCommand.ExecuteNonQuery();
            Employee employee = new Employee();
          
                string query = " exec GetEmployee @id;";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.Parameters.AddWithValue("@id", id);
                SDA.SelectCommand.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SDA.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    employee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    employee.Name = dt.Rows[0]["Name"].ToString();
                    employee.Department = dt.Rows[0]["Department"].ToString();
                }
            con.Close();
            return employee;
        }
        public void DeleteEmployee(int id)
        {
            con.Open();
            //string query = "DeleteEmployee;";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@id", id));
            //cmd.ExecuteNonQuery();
           
            
                string query = " exec DeleteEmployee @id;";
                SqlDataAdapter SDA = new SqlDataAdapter(query, con);
                SDA.SelectCommand.Parameters.AddWithValue("@id", id);
                SDA.SelectCommand.ExecuteNonQuery();
            
            con.Close();
        }
        public void CreateEmployee(string name, string department)
        {
            con.Open();
            //string query = "CreateEmployee;";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@name", name));
            //cmd.Parameters.Add(new SqlParameter("@department", department));
            //cmd.ExecuteNonQuery();

            string query = " exec CreateEmployee @name, @department;";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.Parameters.AddWithValue("@name", name);
            SDA.SelectCommand.Parameters.AddWithValue("@department", department);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateEmployee(int id, string name, string department)
        {
            con.Open();
            //string query = "UpdateEmployee;";
            //SqlCommand cmd = new SqlCommand(query, con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("@id", id));
            //cmd.Parameters.Add(new SqlParameter("@name", name));
            //cmd.Parameters.Add(new SqlParameter("@department", department));
            //cmd.ExecuteNonQuery();
            
            string query = " exec UpdateEmployee @id, @name, @department;";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.Parameters.AddWithValue("@id", id);
            SDA.SelectCommand.Parameters.AddWithValue("@name", name);
            SDA.SelectCommand.Parameters.AddWithValue("@department", department);
            SDA.SelectCommand.ExecuteNonQuery();
            con.Close();
        }

    }
}
