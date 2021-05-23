using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_A2
{
    class Boss
    {
        //The example shown here follows the pattern discussed in the Module 6 summary slides,
        //maintaining two collections, a master and a 'viewable' one (which is the 'view model'
        //in Microsoft's Model-View-ViewModel approach to Model-View-Controller)
        private List<Researcher> staff;
        public List<Researcher> Workers { get { return staff; } set { } }
       
        private ObservableCollection<Researcher> viewableStaff;
        public ObservableCollection<Researcher> VisibleWorkers { get { return viewableStaff; } set { } }

        public Boss()
        {
            staff = researcherDatabase.LoadAll();
            viewableStaff = new ObservableCollection<Researcher>(staff); //this list we will modify later

            //Part of step 2.3.2 from Week 8 tutorial
            foreach (Researcher e in staff)
            {
                e.Skills = researcherDatabase.LoadPublications(e.ID);
            }
        }

        public ObservableCollection<Researcher> GetViewableList()
        {
            return VisibleWorkers;
        }

        //The below method was in wk 8 but not wk 10 tutorial, which had the above method - is the one below still needed?
        /// <summary>
        /// Displays the list of employees on the console.
        /// </summary>
        public void Display()
        {
            staff.ForEach(Console.WriteLine);
        }

        /// <summary>
        /// Returns the Employee with the given ID, or null if no such employee exists.
        /// </summary>
        public Researcher Use(int id)
        {
            foreach (Researcher e in staff)
            {
                if (e.ID == id)
                {
                    return e;
                }
            }
            return null;
            //FYI, if you have an interest in lambda expressions the above could be achieved with:
            //return staff.First(e => e.ID == id);
        }
        
        //This version of Filter modifies the viewable list instead of returning a new list,
        //but the procedure is almost the same
        public void Filter(Gender gender)
        {
            var selected = from Researcher e in staff
                           where gender == Gender.Any || e.Gender == gender
                           select e;
            viewableStaff.Clear();            
            //Converts the result of the LINQ expression to a List and then calls viewableStaff.Add with each element of that list in turn
            selected.ToList().ForEach( viewableStaff.Add );
        }
   
    }
}
