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

        public override string ToString()
        {

            if (PercToMast == "MASTERED" || EstYrsToMast == "COMPLETED")
            {
                return $"Skill: {SkillName} - Total: {TotSkillHrs} Hrs - Current yearly: {CurrYrHrs} Hrs - MASTERY REACHED";
            }
            else
            {
                return $"Skill: {SkillName} - Total: {TotSkillHrs} Hrs - Current yearly: {CurrYrHrs} Hrs - Track to 10k: {PercToMast} - Estimate to 10k: {EstYrsToMast} Yrs";
            }
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


        public virtual Users User { get; set; }

        //public virtual SubSkill subSkill { get; set; }
        public virtual List<SubSkill> SubSkills { get; set; }



    }
}
