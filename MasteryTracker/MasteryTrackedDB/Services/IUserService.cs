using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteryTrackedDB.Services
{
    public interface IUserService
    {

        List<Users> GetUserList();
        public Users GetUserById(string id);
        public void CreateUser(Users u);
        public void AddUserSkill(string id);
        public void DeleteSkill(string id);

    }
}
