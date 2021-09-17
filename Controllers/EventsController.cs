using _1054686___Individual_Assignment.Models;
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
        //events/index page
        public IActionResult Index()
        {
            return View();
        }
        //events/create page
        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("create")]
        public IActionResult Create(Event @event)
        {
            if (!ModelState.IsValid)
                return View();
            @event.Author = User.Identity.Name;
            return View();
        }
    }
}
