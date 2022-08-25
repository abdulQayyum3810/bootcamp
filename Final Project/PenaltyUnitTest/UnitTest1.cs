using NUnit.Framework;
using PenaltyCalc.BusinessLayer;
using System;
using System.Collections.Generic;
namespace PenaltyUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            DateTime checkout = DateTime.Parse("2022-08-08");
            DateTime checkin = DateTime.Parse("2022-08-15");
            List<DateTime>  holidays=new List<DateTime>() { DateTime.Parse("2022-08-14") };
            List<int> weekend = new List<int>() { 0, 6 };
            PenaltyCalculator penaltyCalc = new PenaltyCalculator();
            int businessDays=penaltyCalc.CalculateBusinessDays(checkout, checkin, weekend, holidays);

            Assert.AreEqual(6, businessDays);
        }
        [Test]
        public void Test2()
        {
            DateTime checkout = DateTime.Parse("2022-08-08");
            DateTime checkin = DateTime.Parse("2022-08-31");
            List<DateTime>  holidays=new List<DateTime>() { DateTime.Parse("2022-08-08"), DateTime.Parse("2022-08-14"), DateTime.Parse("2022-08-09") };
            List<int> weekend = new List<int>() { 0, 6 };
            PenaltyCalculator penaltyCalc = new PenaltyCalculator();
            int businessDays=penaltyCalc.CalculateBusinessDays(checkout, checkin, weekend, holidays);
           double penaltyAmount= penaltyCalc.PenaltyCalculatorAlgo(businessDays, 0, 50);
            Assert.AreEqual(800, penaltyAmount);
        }
    }
}