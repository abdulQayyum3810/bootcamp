using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using PenaltyCalc.Models;

namespace PenaltyCalc.DataLayer
{
    public class SqlDataHelper:ISqlDataHelper
    {
        string conStr;
        SqlConnection con;
        public SqlDataHelper(IConfiguration config)
        {
            conStr = config.GetConnectionString("PenaltyDB");
            con = new SqlConnection(conStr);
        }
        // this method uses other methods to get all country data like name,weekends holidays
        public Country GetCountryData(string countryName)
        {

            Country country = GetCountryBasicInfo(countryName);
            country.Holidays = GetHolidays(countryName);
            country.Weekend = GetCountryWeekend(countryName);
            return country;
        }
        private Country GetCountryBasicInfo(string countryName)
        {
            //execute country data sp which gives name, tax, palenty amount per day and currency 
            //of the country then it stores in the coutry object and returns it
            con.Open();
            string query = "exec sp_GetCountryData @countryName;";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);

            SDA.SelectCommand.Parameters.AddWithValue("@countryName", countryName);
            SDA.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SDA.Fill(dt);

            Country country = new Country();
            if (dt.Rows.Count > 0)
            {
                country.Name = Convert.ToString(dt.Rows[0]["countryName"]);
                country.SpecialTax = Convert.ToDouble(dt.Rows[0]["specialTax"]);
                country.PalentyAmount = Convert.ToDouble(dt.Rows[0]["paneltyAmount"]);
                country.Currency = Convert.ToString(dt.Rows[0]["currency"]);
            }
            con.Close();


            return country;
        }

        //execute sp_Getcountyholidays and store in holidays object and return it

        private List<Holiday> GetHolidays(string countryName)
        {
            List<Holiday> holidays = new List<Holiday>();

            con.Open();

            string query = " exec sp_GetCountryHolidays @countryName;";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);

            SDA.SelectCommand.Parameters.AddWithValue("@countryName", countryName);
            SDA.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SDA.Fill(dt);

            
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Holiday holiday = new Holiday();
                holiday.Name = Convert.ToString(dt.Rows[i]["holidayName"]);

                string holidayDateStr = Convert.ToString(dt.Rows[i]["holidayDate"]);
                DateTime holidayDate = DateTime.Parse(holidayDateStr);
                holiday.HolidayDate = holidayDate;

                holiday.Country = Convert.ToString(dt.Rows[i]["country"]);


                holidays.Add(holiday);
            }
            con.Close();
            return holidays;

        }
        // Execute sp_getcountryweekends and returns weekend object which contains weekend details of 
        // a specific country
        private List<Weekend> GetCountryWeekend(string countryName)
        {
            List<Weekend> weekends = new List<Weekend>();
          
            con.Open();
            string query = " exec sp_GetCountryWeekends @countryName;";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);

            SDA.SelectCommand.Parameters.AddWithValue("@countryName", countryName);
            SDA.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SDA.Fill(dt);


            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Weekend weekend = new Weekend();
                weekend.DayCode = Convert.ToInt32(dt.Rows[i]["dayCode"]);
                weekend.DayName= Convert.ToString(dt.Rows[i]["WeekendDay"]);
                weekend.Country= Convert.ToString(dt.Rows[i]["country"]);

                weekends.Add(weekend);
            }
            con.Close();
            return weekends;

        }
        // returns the list of all countries available in database
        public List<string> GetCountriesList()
        {
            con.Open();
            string query = "select countryName from country";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            List<string> countries = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
                
            {
      
               string countryName = Convert.ToString(dt.Rows[i]["countryName"]);
                countries.Add(countryName);
            }
            con.Close();
            return countries;
        }
    }
}
