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
            // potential solve: put subskill new hashset like in EF_modelFirst
        }

        // create constructor that does not take subskill in consideration


        public int SkillToMasterId { get; set; }
        public int UsersID { get; set; }

        
        public int SubSkillID { get; set; }


        public string SkillName { get; set; }
        public string TotSkillHrs { get; set; }
        public string CurrYrHrs { get; set; }
        public string PercToMast { get; set; }
        public string EstYrsToMast { get; set; }

        public string SubSkillList { get; set; }


        public virtual Users User { get; set; }

        //public virtual SubSkill subSkill { get; set; }
        public virtual List<SubSkill> SubSkills { get; set; }



    }
}
