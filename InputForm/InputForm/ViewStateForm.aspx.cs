using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InputForm
{
    public partial class ViewStateForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                // on submit set viewstate values of username and password
                ViewState["user"] = username.Text;
                ViewState["password"] = password.Text;
               
                username.Text = password.Text = string.Empty;
            }
            catch
            {
                errorCatch.InnerText = "Please Enter valid username and password";
            }
        }

        protected void restorFromViewState_Click(object sender, EventArgs e)
        {
            // check if viewstate has data if yes display it in relevent fields
            if (ViewState["user"]!=null)
            {
                username.Text = ViewState["user"].ToString();
            }
            
            if (ViewState["password"]!=null)
            {
                password.Text = ViewState["password"].ToString();
            }
        }

        protected void restorFromHiddenfields_Click(object sender, EventArgs e)
        {
            // get data from hidden fields and display it in relevent fields
            string userHiddenValue = userHidden.Value;
           string passHiddenValue = passwordHidden.Value;
            if (userHiddenValue !=null)
            {
                username.Text = userHiddenValue;

            }
            
            if (passHiddenValue != null)
            {
                password.Text = passHiddenValue;

            }
        }
    }
}