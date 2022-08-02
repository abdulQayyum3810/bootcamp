using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AspNetProject1
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grid.DataSource = new Opperations().GetCustomers();
            grid.DataBind();

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            var a = new Opperations();
            a.AddCustomer("Awais", "Baig", "awaisbaig@gmail.com");
           
        }
    }
}