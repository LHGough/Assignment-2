using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_A2
{
	//Types of publication
	public enum Type { Conference, Journal, Other };

    /// <summary>
    /// A publication created by a researcher on their topic of research.
    /// </summary>
    public class Publication //change everything to publication
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
	    public Type Type { get; set; }
        public DateTime AvailabilityDate { get; set; } //previously Certified
        public string CiteAs { get; set; }
        public int Age { get; set; }
        public int DOI { get; set; }


        public int Freshness
        {
            //DateTime.Today returns today's date. As DateTime objects overload the
            //addition and subtraction operators we can use them to determine the
            //elapsed time between today's date and the Completed date. However, 
            //the result is not a number but a TimeSpan object, whose Days
            //property gives the number of whole days represented by the TimeSpan.
            get { return (DateTime.Today - availabilityDate).Days; }
        }

        public override string ToString()
        {
            //This is a straightforward way of constructing the string using DateTime's
            //ToShortDateString method to remove the time component of the complted date
            return Title + " completed by " + Type + " on " + availabilityDate.ToShortDateString();
            
            //This alternative approach uses the Format method of string, with the
            //short date format requested via the :d in the format string
            //return string.Format("{0} completed by {1} on {2:d}", Title, Mode, Certified);
        }
    }
}

