using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1054686___Individual_Assignment.Controllers
{
    [Route("Contact")]
    public class ContactController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
