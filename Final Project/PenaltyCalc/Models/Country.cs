﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalc.Models
{
    //object to store country data to be returned to business layer
    public class Country
    {
        public string Name { get; set; }
        public double PalentyAmount { get; set; }
        public double SpecialTax { get; set; }
        public string Currency { get; set; }
        public List<Weekend> Weekend { get; set; }
        public List<Holiday> Holidays { get; set; }

    }
}
