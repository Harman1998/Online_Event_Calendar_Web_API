using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Event_Calendar_Web_API.BusinessLayer;
using Online_Event_Calendar_Web_API.Models;

namespace Online_Event_Calendar_Web_API.Controllers
{
    //API controller for Events calendar 
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly Online_Event_Calendar_Web_APIDataContext _context;

        public EventsController(Online_Event_Calendar_Web_APIDataContext context)
        {
            _context = context;
        }

        // GET: api/Events
        //Gets all calendar events using a linq query
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvent()
        {
            return (from events in _context.Event select events).ToList();
        }

        // GET: api/Events/5
        //Gets an event using a linq query
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = (from events in _context.Event
                          where events.Id == id
                          select events).FirstOrDefault();

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Upates an event 
        [HttpPut("{id}")]
        public IActionResult PutEvent(int id, Event @event)
        {
            if (id != @event.Id)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds an event to database.
        [HttpPost]
        public ActionResult<Event> PostEvent(Event @event)
        {
            _context.Event.Add(@event);
            _context.SaveChanges();

            return CreatedAtAction("GetEvent", new { id = @event.Id }, @event);
        }

        // DELETE: api/Events/5
        //Removes an event from database. uses  a linq query to get the record.
        [HttpDelete("{id}")]
        public ActionResult<Event> DeleteEvent(int id)
        {
            var @event = (from events in _context.Event
                          where events.Id == id
                          select events).FirstOrDefault();
            if (@event == null)
            {
                return NotFound();
            }

            _context.Event.Remove(@event);
             _context.SaveChanges();

            return @event;
        }

        //Checks the event using a lamda query.
        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    }
}
