using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalc.Models
{
    public class InputData
    {
        // format to receive data from post request body
        public string Checkout { get; set; }
        public string Checkin { get; set; }
        public string CountryName { get; set; }
    }
}
