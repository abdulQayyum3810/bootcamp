using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace AspNetProject1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    if (Session["user"] != null && Session["type"] != null)
            //    {
            //        if (Session["type"].ToString() == "admin")
            //        {
            //            Response.Redirect("Admin.aspx");
            //        }
            //        else if (Session["type"].ToString() == "accountant")
            //        {

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
    }
}