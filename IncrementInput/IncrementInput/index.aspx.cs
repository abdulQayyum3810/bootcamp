using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IncrementInput
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if page is loading first time set value to 0
            if (!Page.IsPostBack)
            {
                
                ViewState["input"] = 0;
                input.Text = ViewState["input"].ToString();
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                // get value from viewstate
                int val =Convert.ToInt32(ViewState["input"]);
                // icrement value and set it update viewstate value
                val++;
                ViewState["input"] = val;
                // set text field value to update view state value
                input.Text = Convert.ToString(val);
            }
            catch
            {
                input.Text = "Unexpected error occured";
            }
        }
    }
}