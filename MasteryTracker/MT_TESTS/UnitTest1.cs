using NUnit.Framework;
using MTBusiness;
using System.Collections.Generic;


namespace MT_TESTS
{
    public class Tests
    {

        MastTrackerLogic testChecker;
        UserManager _userManager;


        [SetUp]
        public void Setup()
        {
            testChecker = new MastTrackerLogic();
            _userManager = new UserManager();
            
        }

        // 6.1 
        [Test]
        public void InputtingDataGivesCorrectResult()
        {

            testChecker.SkillName = "testSkill";
            testChecker.PastYears = 1;
            testChecker.PastWeeklyHrs = 1;
            testChecker.CurrWeeklyHrs = 1;
            
            Assert.That(() =>  testChecker.CalculateMasteryProgress(), Is.EqualTo(new List<string> { "TESTSKILL", "52", "52", "0", "192"  }));

        }

        [Test]
        public void InputtingDataGivesCorrectResult2()
        {

            testChecker.SkillName = "testSkill2";
            testChecker.PastYears = 10;
            testChecker.PastWeeklyHrs = 12;
            testChecker.CurrWeeklyHrs = 11;

            Assert.That(() => testChecker.CalculateMasteryProgress(), Is.EqualTo(new List<string> { "TESTSKILL2", "6257", "574", "62", "7" }));

        }

        [Test]
        public void InputtingDataThatGoesOver10kReturnDifferentRes()
        {

            testChecker.SkillName = "testSkill3";
            testChecker.PastYears = 10;
            testChecker.PastWeeklyHrs = 111;
            testChecker.CurrWeeklyHrs = 111;

            Assert.That(() => testChecker.CalculateMasteryProgress(), Is.EqualTo(new List<string> { "TESTSKILL3", "57879", "5788", "578", "0" }));

        }


        // 7.1

        //[Test]
        //public void SavedSkillProgressIsAddedToDb()
        //{
        //    _userManager.AddUser()

        //    using (var db = new Skil)
        //}


    }
}