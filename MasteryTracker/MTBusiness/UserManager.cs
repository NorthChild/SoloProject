using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasteryTrackedDB;

namespace MTBusiness
{
    public class UserManager
    {

        public void AddUser(string userName, string passWord)
        {
            var newUser = new Users() { UserName = userName, Password = passWord };


            using (var db = new SkillMasteryContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }


        public void AddSKill(string skillName, string totSkillHrs, string currYrHrs, string percToMast, string estYrsToMast)
        {
            using (var db = new SkillMasteryContext())
            {

                var newSkill = new SkillToMaster() { SkillName = skillName, TotSkillHrs = totSkillHrs, CurrYrHrs = currYrHrs, PercToMast = percToMast, EstYrsToMast = estYrsToMast };

                db.SkillToMasters.Add(newSkill);
                db.SaveChanges();
            }

        }

    }
}
