using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalc.Models
{
    public class OutputData
    {
        // data format in which data will be returned to a post request
        public double CalculatedPenalty { get; set; }
        public string Currency { get; set; }
    }
}
