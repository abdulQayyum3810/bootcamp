using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using PenaltyCalc.BusinessLayer;
using PenaltyCalc.Models;

namespace PenaltyCalc.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyController : ControllerBase
    {
        IPenaltyCalculator _penaltyCalculator;
        public PenaltyController(IPenaltyCalculator penaltyCalculator)
        {
            _penaltyCalculator = penaltyCalculator;
        }
        [Route("CalculatePenalty")]
        [HttpPost]
        public OutputData CalculatePenalty([FromBody] InputData data)
        {
            return _penaltyCalculator.CalculatePalenty(data.Checkout, data.Checkin, data.CountryName);
           
        }
        [Route("test")]
        [HttpPost]
        public List<string> test([FromBody] InputData data)
        {
            return new List<string>() { data.Checkin, data.Checkout, data.CountryName };
        }


        [Route("CountriesList")]
        [HttpGet]
        public List<string> CountriesList()
        {
            return _penaltyCalculator.CountriesList();
        }

    }
}