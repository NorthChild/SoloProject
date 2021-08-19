using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteryTrackedDB
{
    public class SkillToMaster
    {


        public SkillToMaster()
        {

        }


        public int SkillToMasterId { get; set; }
        public int UsersID { get; set; }
        public int SubSkillID { get; set; }

        public string SkillName { get; set; }
        public string TotSkillHrs { get; set; }
        public string CurrYrHrs { get; set; }
        public string PercToMast { get; set; }
        public string EstYrsToMast { get; set; }

        public string SubSkillList { get; set; }


        public virtual Users user { get; set; }

        public virtual SubSkill subSkill { get; set; }


    }
}
