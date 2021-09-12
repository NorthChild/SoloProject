using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteryTrackedDB.Services
{
    public class UserService : IUserService
    {

        private readonly SkillMasteryContext _context;

        public UserService(SkillMasteryContext context)
        {
            _context = context;
        }

        public UserService()
        {
            _context = new SkillMasteryContext();
        }

        public void CreateUser(Users u)
        {
            _context.Users.Add(u);
            _context.SaveChanges();
        }

        public void AddUserSkill(string id)
        {
            throw new NotImplementedException();
        }

        public void DeleteSkill(string id)
        {
            throw new NotImplementedException();

        }

        public Users GetUserById(string id)
        {
            return _context.Users.Where(u => u.UserName == id).FirstOrDefault();
        }

        public List<Users> GetUserList()
        {
            return _context.Users.ToList();
        }
    }
}
