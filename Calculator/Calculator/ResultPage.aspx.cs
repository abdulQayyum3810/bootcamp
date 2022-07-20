using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class ResultPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string x = Request["x"];
            string y = Request["y"];
            string result = Request["result"];
            string op = Request["opperation"];
            output.Text = $"{op}( {x} , {y} ) = {result}";
           

        }
    }
}