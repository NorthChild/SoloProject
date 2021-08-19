using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteryTrackedDB
{
    
    public class SkillMasteryContext : DbContext
    {

        

        public DbSet<Users> Users { get; set; }
        public DbSet<SkillToMaster> SkillToMasters { get; set; }
        public DbSet<SubSkill> SubSkill { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SkillMasteryTrackerDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
