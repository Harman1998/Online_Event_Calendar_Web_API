using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Event_Calendar_Web_API.BusinessLayer;

namespace Online_Event_Calendar_Web_API.Models
{
    //Connects the business model objects to the database.
    public class Online_Event_Calendar_Web_APIDataContext : DbContext
    {
        public Online_Event_Calendar_Web_APIDataContext (DbContextOptions<Online_Event_Calendar_Web_APIDataContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Event_Calendar_Web_API.BusinessLayer.Event> Event { get; set; }
    }
}
