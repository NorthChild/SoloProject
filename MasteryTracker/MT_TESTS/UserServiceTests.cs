using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using MasteryTrackedDB;
using MasteryTrackedDB.Services;

namespace MT_TESTS
{
    public class UserServiceTests
    {

        private UserService _sut;
        private SkillMasteryContext _context;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            var options = new DbContextOptionsBuilder<SkillMasteryContext>().UseInMemoryDatabase(databaseName: "Example_DB").Options;

            _context = new SkillMasteryContext(options);

            // fake
            _sut = new UserService(_context);

            // seed the DB
            _sut.CreateUser(new Users { UserName = "BOON", Password = "123_Test" });
            _sut.CreateUser(new Users { UserName = "BOON123", Password = "123_Test_123" });
        }


        [Test]
        public void GivenAValidId_CorrectCustomerIsReturned()
        {
            var result = _sut.GetUserById("BOON");

            Assert.That(result, Is.TypeOf<Users>());
            Assert.That(result.UserName, Is.EqualTo("BOON"));
            Assert.That(result.Password, Is.EqualTo("123_Test"));
            
        }

        [Test]
        public void GivenACustomerList_ReturnTheCustomerListCount()
        {

            var customerListTypeCheck = _sut.GetUserList();

            Assert.That(customerListTypeCheck, Is.TypeOf<List<Users>>());
        }

    }
}
