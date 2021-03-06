using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_A2      //used to be KIT206_Week9
{

    //As an example, this includes an additional 'gender' called Any that could be used in a GUI drop-down list.
    //The filtering could then be modified that if Gender.Any is selected that the full list is returned with no filtering performed.
    public enum Gender { Any, M, F, X };

    /// <summary>
    /// Researchers employed by the university
    /// </summary>
    public class Researcher
    {
        public int ID { get; set; } //need to update these too, looking at the Research Assessment Program document
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public List<Publication> Skills { get; set; } //change variable name (skills --> ?)
        public string ResearcherType { get; set; }  //can either be staff or student

        public int SkillCount   //change variable name here too
        {
            get { return Skills == null ? 0 : Skills.Count(); }
        }

        //The SkillCount out of 10, expressed as a percentage
        public double SkillPercent      //is this one needed? might be skill count average over three years?
        {
            //This is equivalent to SkillCount / 10.0 * 100
            get { return SkillCount * 10.0; }
        }

        //This is likely the solution you will have devised
        public DateTime MostRecentTraining      //need to change name
        {
            get     //could change skillDates too?
            {
                var skillDates = from Publication s in Skills
                                 orderby s.AvailabilityDate descending
                                 select s.AvailabilityDate;
                return skillDates.First();
            }
        }

        //This is a more robust implementation, but requires the the return type be made 'nullable'
        //        public DateTime? MostRecentTraining
        //        {
        //            get
        //            {
        //                if (SkillCount > 0)
        //                {
        //                    var skillDates = from TrainingSession s in Skills
        //                                     orderby s.Certified descending
        //                                     select s.Certified;
        //                    return skillDates.First();
        //                }
        //                return null;
        //            }
        //        }

        //May or may not be useful, but adding it here just in case (DELETE IF OBSOLETE)
        public int RecentPublication()
        {
            if (Skills != null)
            {
                int endYear = DateTime.Today.Year;
                int startYear = endYear - 1; //window is up to 2 years in length
                var allRecent = from Publication skill in Skills
                                where skill.PublicationYear >= startYear && skill.PublicationYear <= endYear
                                select skill;
                return allRecent.Count();

                //which could be rewritten as a single expression:
                //return (from Publication skill in Skills
                //        where skill.Year >= startYear && skill.Year <= endYear
                //        select skill).Count();
            }
            return 0;
        }

        public override string ToString()
        {
            //For the purposes of this week's demonstration this returns only the name
            return Name;
        }
    }
}
