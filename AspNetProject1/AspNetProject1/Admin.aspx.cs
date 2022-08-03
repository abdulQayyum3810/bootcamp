using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Data;
namespace AspNetProject1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (!Page.IsPostBack)
            //{
            //    if (Session["user"] != null && Session["type"] != null)
            //    {
            //        if (Session["type"].ToString() == "admin")
            //        {
                        
            //        }
            //        else if (Session["type"].ToString() == "accountant")
            //        {
            //            Response.Redirect("Accountant.aspx");
            //        }
            //        else
            //        {
            //            Response.Redirect("Login.aspx");
            //        }
            //    }
            //    else
            //    {
            //        Response.Redirect("Login.aspx");
            //    }
            //}
        }
        
        [WebMethod]
        public static string GetAllAccounts()
        {
            var accounts = new Opperations();
            var data = accounts.GetAccounts();
            return accounts.JsonConverter(data) ;
            

        }
        [WebMethod]
        public static string GetAllCustomers()
        {
            var customers = new Opperations();
            var data = customers.GetCustomers();
            return customers.JsonConverter(data);


        }
        [WebMethod]
        public static string GetAllProducts()
        {
            var products = new Opperations();
            var data = products.GetProducts();
            return products.JsonConverter(data);

        } 
        [WebMethod]
        public static string AddCustomerWeb(string fname,string lname, string email)
        {
            var customer = new Opperations();
            customer.AddCustomer(fname,lname,email);
            var data = customer.GetCustomers();
            return customer.JsonConverter(data);

        }
        [WebMethod]
        public static string DeleteCustomerWeb(int id)
        {
            var customer = new Opperations();
            customer.DeleteCustomer(id);
            var data = customer.GetCustomers();
            return customer.JsonConverter(data);

        }
        [WebMethod]
        public static string UpdateCustomerWeb(int id, string fname, string lname, string email)
        {
            var customer = new Opperations();
            customer.UpdateCustomer(id, fname, lname, email);
            var data = customer.GetCustomers();
            return customer.JsonConverter(data);

        }



        [WebMethod]
        public static string AddProductWeb(string name, string price)
        {
            var product = new Opperations();
            product.AddProduct(name, Convert.ToInt32(price));
            var data = product.GetProducts();
            return product.JsonConverter(data);

        }
        [WebMethod]
        public static string DeleteProductWeb(int id)
        {
            var product = new Opperations();
            product.DeleteProduct(id);
            var data = product.GetProducts();
            return product.JsonConverter(data);

        }

        [WebMethod]
        public static string UpdateProductWeb(int id,string name, string price)
        {
            var product = new Opperations();
            product.UpdateProduct(id,name,Convert.ToDouble( price));
            var data = product.GetProducts();
            return product.JsonConverter(data);

        }

        


    }
}