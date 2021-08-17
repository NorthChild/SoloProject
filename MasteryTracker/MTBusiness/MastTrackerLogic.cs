using System;
using System.Collections.Generic;
using System.Linq;

namespace MTBusiness
{

    
    public class MastTrackerLogic
    {

        public string SkillName { get; set; }
        //
        public double PastYears { get; set; }
        public double PastWeeklyHrs { get; set; }
        //
        public double CurrWeeklyHrs { get; set; }


        // calculate hours from the past 
        public List<string> CalculateMasteryProgress() 
        {

            // hours devolved in the past (years * past weekly hours)
            var pastAccumulatedHours = Convert.ToInt32(PastWeeklyHrs * 52.1429 * PastYears);

            
            // hours currently devolved towards mastery (current hours * total weeks in a year)
            var currentYearlyHours = Convert.ToInt32(CurrWeeklyHrs * 52.1429);
            var currentYearlyHrsPerc = ((currentYearlyHours * 100) / 10000);


            // left towards mastery - 10k
            var percentageToCompletion = ((pastAccumulatedHours * 100) / 10000);
            var percentageLeftToMastery = 100 - percentageToCompletion;

            var totalHoursAccumulatedPastPlusCurrent = Convert.ToInt32(currentYearlyHours + pastAccumulatedHours);

            // reaching 10k 
            var totalHoursToMastery = 10000;
            var counter = 0;

            while (totalHoursToMastery >= 0)
            {
                counter++;
                totalHoursToMastery -= currentYearlyHours;
            }

            // if skill already mastered

            if (totalHoursAccumulatedPastPlusCurrent > 10000)
            {
                // make a different list to display when user has already reached 10k 
            }

            var currentTotal = totalHoursToMastery - totalHoursAccumulatedPastPlusCurrent;

            var progressResults = new List<string>() { pastAccumulatedHours.ToString(), currentYearlyHours.ToString(), percentageLeftToMastery.ToString(), $"{counter.ToString()}"};


            return progressResults;
        }







    }
}
