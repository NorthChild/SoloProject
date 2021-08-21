using System;
using MasteryTrackedDB;
using System.Collections.Generic;
using System.Linq;


namespace MasteryTrackedDB
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            SkillToMaster newSkill = new SkillToMaster() { UsersID = 12, SkillName = "blah", TotSkillHrs = "34", CurrYrHrs = "23", PercToMast = "23", EstYrsToMast = "34" };

            Console.WriteLine(newSkill.ToString());
            

            // USER
            // - many to many -
            // SKILL
            // - one to many - 
            // SUBSKILL 

            using (var db = new SkillMasteryContext())
            {

                //Users user = new Users() { UserName = "bob" };

                //db.Users.Add(user);

                //db.SaveChanges();

                //Console.WriteLine("DONE");

                var userId = "1";

                var userIdQuery =
                from i in db.Users
                where i.UserName == userId
                select i.UsersID;

                int userIDFinal = 0;

                foreach (var i in userIdQuery)
                {
                    userIDFinal += i;
                }

                var userSkillsQuery =
                from i in db.SkillToMasters
                where i.UsersID == userIDFinal
                select i;

                foreach (var i in userSkillsQuery) Console.WriteLine(i);

            }




        }
    }
}
