using NUnit.Framework;
using MTBusiness;
using System.Collections.Generic;
using MasteryTrackedDB;
using System.Linq;
using System;


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


            // remove test entry in DB if present
            using (var db = new SkillMasteryContext())
            {
                var selectedCustomers =
                from c in db.Users
                where c.UserName == "Test1234"
                select c;

                var selectedCustomers2 =
                from c in db.Users
                where c.UserName == "Test123"
                select c;


                var selectedSkill =
                    from i in db.SkillToMasters
                    where i.SkillName == "TESTSKILL"
                    select i;

                db.Users.RemoveRange(selectedCustomers);
                db.Users.RemoveRange(selectedCustomers2);
                db.SkillToMasters.RemoveRange(selectedSkill);
                db.SaveChanges();
            }

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


        // 1
        [Test]
        public void SavedSkillProgressIsAddedToDb()
        {
            

            using (var db = new SkillMasteryContext())
            {
                var numberOfUsersBefore = db.Users.Count();
                _userManager.AddUser("TEST123", "test1");
                var numberOfUsersAfter = db.Users.Count();

                Assert.That(numberOfUsersBefore + 1, Is.EqualTo(numberOfUsersAfter));

            }
        }


        // 7.1
        [Test]
        public void TestThatDBFindsANewUserWhenANewUserRegistersInComparisonToDBBeforeNewRegistration()
        {

            using (var db = new SkillMasteryContext())
            {

                var userNameBefore = "TEST1234";

                var counterBefore = 0;
                var counterAfter = 0;

                var query1 =
                    from i in db.Users
                    where i.UserName == userNameBefore
                    select i;

                foreach (var i in query1)
                {
                    counterBefore++;
                }

                _userManager.AddUser("TEST1234", "test123");

                var query2 =
                    from i in db.Users
                    where i.UserName == userNameBefore
                    select i;

                foreach (var i in query2)
                {
                    counterAfter++;
                }

                Assert.That(counterBefore, Is.Not.EqualTo(counterAfter));
            }

        }


        [Test]
        public void TestThatWhenANewUserRegistersTheirUserNameIsPresentInDB()
        {
            using (var db = new SkillMasteryContext())
            {

                var userNameBefore = "TEST1234";

                _userManager.AddUser("TEST1234", "test123");

                var queryUserName =
                    from i in db.Users
                    where i.UserName == userNameBefore
                    select i.UserName;

                var userName = "";

                foreach (var i in queryUserName) userName = i;

                Assert.That(userNameBefore, Is.EqualTo(userName));
            }

        }




        [TearDown]
        public void TearDown()
        {
            using (var db = new SkillMasteryContext())
            {
                var selectedCustomers =
                from c in db.Users
                where c.UserName == "TEST1234"
                select c;

                var selectedCustomers2 =
                from c in db.Users
                where c.UserName == "Test123"
                select c;

                var selectedSkill =
                    from i in db.SkillToMasters
                    where i.SkillName == "TESTSKILL"
                    select i;

                db.Users.RemoveRange(selectedCustomers);
                db.Users.RemoveRange(selectedCustomers2);
                db.SkillToMasters.RemoveRange(selectedSkill);
                db.SaveChanges();
            }
        }


    }
}