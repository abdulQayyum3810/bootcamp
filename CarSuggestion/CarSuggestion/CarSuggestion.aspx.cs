using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace CarSuggestion
{
    public partial class CarSuggestion : System.Web.UI.Page
    {
        public static List<string> carList = new List<string>() { "Aston Martin", "Audi", "BMW", 
            "Cadillac", "Chevrolet","Datsun","Ferrari","Ford","Honda","Mercedes","Nissan","Porsche","Rolls Royce","Toyota","Volkswagen" };
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        [WebMethod]
        public static List<string> CarSuggestionList(string name)
        {
            var suggestedList = new List<string>();
            foreach (var car in carList)
            {
                if (car.ToLower().Contains(name))
                {
                    suggestedList.Add(car);

                }
            }
            
            return suggestedList;
        }
    }
}