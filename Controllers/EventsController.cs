using _1054686___Individual_Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1054686___Individual_Assignment.Controllers
{
    [Route("events")]
    public class EventsController : Controller
    {
        private readonly EventsDataContext _db;
        public EventsController(EventsDataContext db)
        {
            _db = db;
        }
        //events/index page
        public IActionResult Index()
        {

            var events = _db.Events.OrderByDescending(x => x.Time).Where(x=>x.Time>DateTime.Now).Take(5).ToArray();
            return View(events);
        }
        //events/create page
        //[Authorize]
        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        //[Authorize]
        [HttpPost, Route("create")]
        public IActionResult Create(Event @event) //personal note: dont use 'event' in future
        {
            if (!ModelState.IsValid)
                return View();
            @event.Author = User.Identity.Name;
            _db.Events.Add(@event);
            _db.SaveChanges(true);


            return this.RedirectToAction("Index", "Events");
        }
    }
}
