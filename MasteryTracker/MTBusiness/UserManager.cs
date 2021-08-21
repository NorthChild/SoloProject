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

                // if user already present throw exception
                if (db.Users.Contains(newUser))
                {
                    throw new ArgumentException("USER ALREADY PRESENT");
                }

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public List<SkillToMaster> RetreiveUserSkills(string userId)
        {
            using (var db = new SkillMasteryContext())
            {

                // find obj associated with userID
                var userIdQuery =
                from i in db.Users
                where i.UserName == userId
                select i.UsersID;

                int userIDFinal = 0;

                foreach (var i in userIdQuery)
                {
                    userIDFinal += i;
                }

                return db.SkillToMasters.ToList();

                //return from i in db.SkillToMasters.Where(c => c.UsersID == userIDFinal).Select(skillList => new { Skill = skillList.SkillName, Total_Hours = skillList.TotSkillHrs, Current_Yearly_Hours = skillList.CurrYrHrs, Percentage = skillList.PercToMast, Years_To_Mastery = skillList.EstYrsToMast }).OrderByDescending(c => c.Current_Yearly_Hours).GroupBy(c => c.Current_Yearly_Hours);





            }
        }


        public void AddSKill(int userId, string skillName, string totSkillHrs, string currYrHrs, string percToMast, string estYrsToMast)
        {

            using (var db = new SkillMasteryContext())
            {

                // if null exception ?

                var newSkill = new SkillToMaster() { UsersID = userId, SkillName = skillName, TotSkillHrs = totSkillHrs, CurrYrHrs = currYrHrs, PercToMast = percToMast, EstYrsToMast = estYrsToMast };

                db.SkillToMasters.Add(newSkill);
                db.SaveChanges();
            }

        }


        // update skill

        // delete skill 
       
    }
}
