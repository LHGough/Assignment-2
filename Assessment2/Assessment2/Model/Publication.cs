using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_Week9
{
	//Types of publication
	public enum Mode { Conference, Journal, Other }; //not actualy sure if these need to be changed

    /// <summary>
    /// A publication created by a researcher on their topic of research.
    /// </summary>
    public class Publication //change everything to publication
    {
        public string Title { get; set; }
        public int Year { get; set; }
		public Mode Mode { get; set; }
        public DateTime Certified { get; set; } //this is something different

        public int Freshness
        {
            //DateTime.Today returns today's date. As DateTime objects overload the
            //addition and subtraction operators we can use them to determine the
            //elapsed time between today's date and the Completed date. However, 
            //the result is not a number but a TimeSpan object, whose Days
            //property gives the number of whole days represented by the TimeSpan.
            get { return (DateTime.Today - Certified).Days; }
        }

        public override string ToString()
        {
            //This is a straightforward way of constructing the string using DateTime's
            //ToShortDateString method to remove the time component of the complted date
            return Title + " completed by " + Mode + " on " + Certified.ToShortDateString();
            
            //This alternative approach uses the Format method of string, with the
            //short date format requested via the :d in the format string
            //return string.Format("{0} completed by {1} on {2:d}", Title, Mode, Certified);
        }
    }
}

