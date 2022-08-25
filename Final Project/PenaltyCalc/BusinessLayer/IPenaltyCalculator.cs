using PenaltyCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalc.BusinessLayer
{
    public interface IPenaltyCalculator
    {
        int CalculateBusinessDays(DateTime checkout, DateTime checkin, List<int> weekend, List<DateTime> holidays);
        double PenaltyCalculatorAlgo(int businessDays, double specialTax, double palentyPerDay);
        OutputData CalculatePalenty(string checkout, string checkin, string countryName);
        List<string> CountriesList();
    }
}
