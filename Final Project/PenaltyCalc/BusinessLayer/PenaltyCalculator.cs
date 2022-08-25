using PenaltyCalc.DataLayer;
using PenaltyCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PenaltyCalc.BusinessLayer
{
    public class PenaltyCalculator:IPenaltyCalculator
    {
        ISqlDataHelper _sqlDataHelper;
        public PenaltyCalculator(ISqlDataHelper sqlDataHelper)
        {
            _sqlDataHelper = sqlDataHelper; 
        }

        public OutputData CalculatePalenty(string checkout, string checkin, string countryName)
        {
            // uses different method to calculate palenty amount
            Country country = _sqlDataHelper.GetCountryData(countryName);
            DateTime checkoutDate = DateTime.Parse(checkout);
            DateTime checkinDate = DateTime.Parse(checkin);

            // get list of weekend dayCodes (ints) from country weekend object
            List<int> weekend = country.Weekend.Select(wd => wd.DayCode).ToList();
            // get holidy dates list from country holidays object
            List<DateTime> holidays = country.Holidays.Select(h => h.HolidayDate).ToList();

            
            int businessDays = CalculateBusinessDays(checkoutDate, checkinDate, weekend, holidays);

            double palenty = PenaltyCalculatorAlgo(businessDays, country.SpecialTax, country.PalentyAmount);
            
            // create and set attributes of  object to be returned
            OutputData output = new OutputData();
            output.CalculatedPenalty = palenty;
            output.Currency = country.Currency;
            return output;
        }
        

        public double PenaltyCalculatorAlgo(int businessDays,double specialTax,double palentyPerDay)
        {
            // set initial value
            double palenty = 0;
            // if business day are less than 10 return 0
            if (businessDays < 10)
            {
                return palenty;
            }

            // if calcuate palenty
            palenty = businessDays * palentyPerDay;
            palenty += palenty * (specialTax / 100);
            return palenty;
        }
        public int CalculateBusinessDays(DateTime checkout, DateTime checkin, List<int> weekend, List<DateTime> holidays)
        {
            int businessDays = 0;
            // if currentdate is not in holidays or not weekend then increment business day by one
            for (DateTime currentDate = checkout; currentDate <= checkin; currentDate = currentDate.AddDays(1))
            {
                int currentDayOfWeek = Convert.ToInt32(currentDate.DayOfWeek);
                if (!(weekend.Contains(currentDayOfWeek) || holidays.Contains(currentDate)))
                {
                    businessDays++;
                }

            }


            return businessDays;
        }
        public List<string> CountriesList()
        {
            // get list of all countries
            return _sqlDataHelper.GetCountriesList();
        }
    }
}
