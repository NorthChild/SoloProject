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


        // copy paste so u dont have to constantly write this

        //using (var db = new SkillMasteryContext())
        //    {

        //    }


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


        // test new skill created in db


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



        // 7.2
        [Test]
        public void TestingThatWhenUserSavesSkillReportDBSavesTheData()
        {

            using (var db = new SkillMasteryContext())
            {
                _userManager.AddSKill(64, "TESTSKILL", "12", "12", "12", "12");

                var query =
                    db.SkillToMasters.Where(x => x.SkillName == "TESTSKILL").Count();

                Assert.That(query, Is.EqualTo(1));
            }

        }


        [Test]
        public void TestingThatWhenUserSavesSkillReportDBHasOneMoreItem()
        {

            using (var db = new SkillMasteryContext())
            {
                var query =
                    db.SkillToMasters.Count();

                _userManager.AddSKill(64, "TESTSKILL", "12", "12", "12", "12");

                var query2 =
                    db.SkillToMasters.Count();

                Assert.That(query2, Is.EqualTo(query + 1));
            }

        }


        // 8.2
        [Test]
        public void TestThatSkillsAreViewedFromDB()
        {
            
            using (var db = new SkillMasteryContext())
            {

                _userManager.RetreiveUserSkills("USERNAME");
                var queryBefore = db.SkillToMasters.Where(c => c.UsersID == 64).Count();

                Assert.That(queryBefore, Is.EqualTo(29));

            }


        }


        // delete 
        [Test]
        public void TestThatWhenUserChoosesToDeleteSkillItIsRemovedFromDB()
        {

            using (var db = new SkillMasteryContext())
            {

                _userManager.AddSKill(88, "test123", "23", "23", "23", "23");

                var queryCountOfSkillsWithUSerId = db.SkillToMasters.Where(c => c.UsersID == 88).Count();

                var querySkillId = db.SkillToMasters.Where(c => c.UsersID == 88).Where(w => w.SkillName == "test123").Select(c => c.SkillToMasterId);

                int skillIdToLink = 0;

                foreach (var i in querySkillId)
                {
                    skillIdToLink += i;
                }

                _userManager.DeleteSkill(skillIdToLink);

                var queryCountOfSkillsWithUSerId2 = db.SkillToMasters.Where(c => c.UsersID == 88).Count();

                Assert.That(queryCountOfSkillsWithUSerId == queryCountOfSkillsWithUSerId2);
            }
        }


        // update
        [Test]
        public void TestThatWhenUserUpdatesSkillsItIsUpdatedInTheDB()
        {
            using (var db = new SkillMasteryContext())
            {

                _userManager.AddSKill(88, "testTestington", "23", "23", "23", "23");

                var queryCountOfSkillsWithUSerId = db.SkillToMasters.Where(c => c.SkillName == "testTestington").Count();

                _userManager.UpdateSkill(88, "testTestington", "Badmin", "23", "23", "23", "23");

                var queryCountOfSkillsWithUSerId2 = db.SkillToMasters.Where(c => c.SkillName == "testTestington").Count();

                Assert.That(queryCountOfSkillsWithUSerId2 < queryCountOfSkillsWithUSerId);
            }
        }

        // 8.3 

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