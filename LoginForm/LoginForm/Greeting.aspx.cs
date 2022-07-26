using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm
{
    public partial class Greeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if user is already  logged in if not redirect him to login page
            if (Session["user"] == null && Session["password"] == null)
            {
                    Response.Redirect("Login.aspx");
            }
            // keep him on greeting page
            else 
            {
                greet.InnerText = $"Welcome {Session["user"]}";
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            // on logout destroy user session information
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}