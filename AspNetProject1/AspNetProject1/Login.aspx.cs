using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Data;

namespace AspNetProject1
{


    public partial class WebForm1 : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (Session["user"] != null && Session["type"] != null)
            //    {
            //        if (Session["type"].ToString() == "admin")
            //        {
            //            Response.Redirect("Admin.aspx");
            //        }
            //        else if (Session["type"].ToString() == "accountant")
            //        {
            //            Response.Redirect("Accountant.aspx");
            //        }
                   
            //    }
            //}
        }
        [WebMethod(EnableSession=true)] 

        public static string AuthenticateUSer(string username, string password)
        {
            var dt = new Opperations().Authentication(username, password);
            if (dt.Rows.Count == 1)
            {
                string user = (string)dt.Rows[0][0];
                HttpContext.Current.Session["user"] = user;
                string type = (string)dt.Rows[0][5];
                try {
                    if (type == "admin")
                    {
                        HttpContext.Current.Session["type"] = "admin";
                        return "admin";
                    }
                    if (type == "accountant")
                    {
                        HttpContext.Current.Session["type"] = "accountant";
                        return "accountant";
                    }
                }
                catch { }
                }

            return "not authenticated";
        }
    }
}