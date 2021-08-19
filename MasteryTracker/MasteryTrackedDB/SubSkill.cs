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
        public int SkillID { get; set; }


        public string SubSkillList { get; set; }

        public List<SkillToMaster> skillToMasters { get; set; }
        
    }
}
