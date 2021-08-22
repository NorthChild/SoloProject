using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasteryTrackedDB;
using MTBusiness;

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

                //
                var userSkillsQuery =
                from i in db.SkillToMasters
                where i.UsersID == userIDFinal
                select i;

                //var userSkillsQuery =

                if (userId is null || userId == " " || userId == "")
                {
                    return db.SkillToMasters.OrderBy(c => c.SkillName).ToList();
                }
                else
                {
                    return db.SkillToMasters.Where(c => c.UsersID == userIDFinal).OrderBy(c => c.SkillName).ToList();
                }

                
            }
        }


        public void AddSKill(int userId, string skillName, string totSkillHrs, string currYrHrs, string percToMast, string estYrsToMast)
        {

            using (var db = new SkillMasteryContext())
            {

                var newSkill = new SkillToMaster() { UsersID = userId, SkillName = skillName, TotSkillHrs = totSkillHrs, CurrYrHrs = currYrHrs, PercToMast = percToMast, EstYrsToMast = estYrsToMast };

                db.SkillToMasters.Add(newSkill);
                db.SaveChanges();
            }

        }

        public void AddSubSkill(int skillId, List<SubSkill> subskill)
        {



            using (var db = new SkillMasteryContext())
            {

                var newSubskill = new SubSkill() { SkillToMasterId = skillId, SubSkills = subskill };

                db.SubSkill.Add(newSubskill);
                db.SaveChanges();


            }

        }


        // update skill
        public bool UpdateSkill(int userId, string skillName, string newSkillName, string totSkillHrs, string currYrHrs, string percToMast, string estYrsToMast)
        {

            using (var db = new SkillMasteryContext())
            {

                var selectedUser = db.SkillToMasters.Where(s => s.UsersID == userId).Where(w => w.SkillName == skillName).FirstOrDefault();

                selectedUser.SkillName = newSkillName;
                selectedUser.TotSkillHrs = totSkillHrs;
                selectedUser.CurrYrHrs = currYrHrs;
                selectedUser.PercToMast = percToMast;
                selectedUser.EstYrsToMast = estYrsToMast;

                if (selectedUser == null)
                {
                    return false;
                }

                //db.SkillToMasters.Add(newSkill);
                db.SaveChanges();
            }
            return true;
        }

        // delete skill 

        public bool DeleteSkill(int skillId)
        {

            using (var db = new SkillMasteryContext())
            {

                var selectedSkill = db.SkillToMasters.Where(s => s.SkillToMasterId == skillId);

                if (selectedSkill == null)
                {
                    return false;
                }


                db.SkillToMasters.RemoveRange(selectedSkill);
                db.SaveChanges();

            }
            return true;
        }

    }
}
