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


        //public virtual SkillToMaster SkillToMast { get; set; }
        public virtual List<SkillToMaster> SkillToMaster { get; set; }

        // parent has virtual list child has virtual prop

        

    }
}
