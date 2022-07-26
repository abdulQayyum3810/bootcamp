using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check whether user is already logged in or not if yes land him on greeting page
            if (Session["user"]!=null && Session["password"]!=null)
            {
                if(Session["user"].ToString() == "polar" && Session["password"].ToString() == "vezli")
                {
                    Response.Redirect("Greeting.aspx");
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                
               
                // check if user filled correct information
                if (username.Text == "polar" && password.Text == "vezli")
                {
                    // store user infomation in session 
                    Session["user"] = username.Text;
                    Session["password"] = password.Text;
                    // redirect user to greeting page
                    Response.Redirect("Greeting.aspx");
                }
                else
                {
                    errorCatch.InnerText = "Please enter valid username and password";
                }
            }
            catch
            {
                errorCatch.InnerText = "Please enter valid Input";
            }
        }
    }
}