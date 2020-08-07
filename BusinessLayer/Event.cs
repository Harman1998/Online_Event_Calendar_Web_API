using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Event_Calendar_Web_API.BusinessLayer
{
    //A calendar event.
    public class Event
    {
        //Calendar event id.
        public int Id { get; set; }

        //Calendar event name.
        public string EventName { get; set; }

        //Calendar event start date.
        public DateTime StartDate { get; set; }

        //Calendar evebt end date.
        public DateTime EndDate { get; set; }

        //Calendar event number of days calculated difference of start and end dates.
        [NotMapped]
        public int NumberOfDays {
            get {

                return (this.EndDate - this.StartDate).Days;
            
            }
                
        }



    }
}
