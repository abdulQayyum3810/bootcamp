using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace Calculator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void calculate_Click(object sender, EventArgs e)
        {
            string xStr = Request.Form["xi"].ToString();
            var x = Convert.ToDouble(xStr);
            string yStr = Request.Form["yi"].ToString();
            var y = Convert.ToDouble(yStr);

            string oppStr = Request.Form["opperation"].ToString();
            double result=0;
            switch (oppStr)
            {

                case "Add":
                    result = (double)x + y;
                    break;

                case "Subtract":
                    result = (double) x - y;
                    break;

                case "Multiply":
                    result = (double)x *y;
                    break;

                case "Divide":
                    result = (double)x / y;
                    break;
            }
            output.Value = Convert.ToString(result);

        }
    }
}