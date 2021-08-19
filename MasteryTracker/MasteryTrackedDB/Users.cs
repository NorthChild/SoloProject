using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteryTrackedDB
{
    public class Users
    {


        public Users()
        {

        }

        public Users(int userId)
        {
            userId = UsersID;
        }

        public int UsersID { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

        public List<SkillToMaster> SkillToMaster { get; set; }

    }
}
