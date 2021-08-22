using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteryTrackedDB
{
    public class SubSkill
    {

        public SubSkill()
        {
            
        }


        public int SubSkillID { get; set; }
        public int SkillToMasterId { get; set; }

        public List<SubSkill> SubSkills { get; set; }


        public virtual SkillToMaster SkillToMaster { get; set; }

        //public List<SubSkill> SubSkillList { get; set; }

        //public virtual SkillToMaster SkillToMast { get; set; }

        //public List<SkillToMaster> SkillToMaster { get; set; }

    }
}
