using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Web.Script.Serialization;
namespace AspNetProject1
{


    class Opperations
    {
        static string conString = @"Data Source=CMDLHRDB01;Initial Catalog=4087-AspNetProject1;Persist Security Info=True;User ID=sa;Password=CureMD2022";
        SqlConnection connection = new SqlConnection(conString);

        //////////////////////   ACCOUNT OPPERATIONS  /////////////////////////////
        public DataTable Authentication(string username, string password)
        {
            connection.Open();
            string query = "SELECT * FROM account WHERE username='" + username + "' and password='" + password + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            connection.Close();
            return dt;
        }
        public void AddAccount(string username , string fname, string lname, string email, string type)
        {
            connection.Open();
            string query = "INSERT INTO account(username,fname,lname,email,type) VALUES('" + username + "','" + fname + "','" + lname + "','" + email + "','" + type + "');";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateAccount(string username, string fname, string lname, string email, string type)
        {
            connection.Open();
 
            string query = "UPDATE product SET fname='" + fname + "',lname='" + lname + "', email='" + email + "', type='" + type + "' WHERE username='" + username + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void DeleteAccount(string username)
        {
            connection.Open();
            string query = "DELETE account WHERE username='" + username + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable GetAccounts()
        {
            connection.Open();
            string query = "SELECT * FROM account";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            connection.Close();
             return dt;
        }


        //////////////////////   PRODUCT OPPERATIONS  /////////////////////////////



        public void AddProduct(string name, double price)

        {
            
            connection.Open();
            string query = "INSERT INTO product(name,price) VALUES('" + name + "','" + price + "');";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdateProduct(int id, string name, double price)
        {
            connection.Open();
            string query = "UPDATE product SET name='" + name + "', price='" + price + "' WHERE id='" + id + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteProduct(int id)
        {
            connection.Open();
            string query = "DELETE product WHERE id='" + id + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();

        }
        public DataTable GetProducts()
        {
            connection.Open();
            string query = "SELECT * FROM product;";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            connection.Close();
           return  dt;
        }


        //////////////////////   CUSTOMER OPPERATIONS  /////////////////////////////
        public void AddCustomer(string fname, string lname, string email)
        {
            connection.Open();
            string query = "INSERT INTO customer(fname,lname,email) VALUES('" + fname + "','" + lname + "','" + email + "');";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }
        public  void UpdateCustomer(int id, string fname,string lname, string email)
        {
            connection.Open();
            string query = "UPDATE customer SET fname='" + fname + "',lname='" + lname + "', email='" + email + "' WHERE id='" + id + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();

        }
        public  void DeleteCustomer(int id)
        {
            connection.Open();
            string query = "DELETE customer WHERE id='" + id + "';";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            SDA.SelectCommand.ExecuteNonQuery();
            connection.Close();
        }
        
        public DataTable GetCustomers()
        {
            connection.Open();
            string query = "SELECT * FROM customer";
            SqlDataAdapter SDA = new SqlDataAdapter(query, connection);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            connection.Close();
            return dt;
        }

        public string JsonConverter(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }

    }
}