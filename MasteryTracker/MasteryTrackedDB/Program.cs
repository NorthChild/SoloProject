using System;


namespace MasteryTrackedDB
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");



            // USER
            // - many to many -
            // SKILL
            // - one to many - 
            // SUBSKILL 

            using (var db = new SkillMasteryContext())
            {

                Users user = new Users() { UserName = "bob" };

                db.Users.Add(user);



                db.SaveChanges();

                Console.WriteLine("DONE");

            }

        }
    }
}
