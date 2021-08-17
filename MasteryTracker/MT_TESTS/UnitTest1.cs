using NUnit.Framework;
using MTBusiness;
using System.Collections.Generic;


namespace MT_TESTS
{
    public class Tests
    {

        MastTrackerLogic testChecker;

        [SetUp]
        public void Setup()
        {
            testChecker = new MastTrackerLogic();
        }
                    // TO CONTINUE
        // 6.1 
        [TestCase(12, 33, 44, new List<string> {"23", "21" })]
        public void InputtingWrongDataWhileMeasuringGivesErrorMessage(int num1, int num2, int num3, List<string> expected)
        {

            testChecker.PastYears = num1;
            testChecker.PastWeeklyHrs = num2;
            testChecker.CurrWeeklyHrs = num3;

            Assert.That(() => testChecker.CalculateMasteryProgressPastYears(), expected);

        }
    }
}