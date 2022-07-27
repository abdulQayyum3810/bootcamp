using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace StaffRecord
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
        }
        public void Session_OnStart()
        {
            List<Employee> staffData = new Employee().staffData;
            Session["staffData"] = staffData;
        }
    }
}