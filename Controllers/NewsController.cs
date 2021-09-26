using _1054686___Individual_Assignment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1054686___Individual_Assignment.Controllers
{

    [Route("news")]
    public class NewsController : Controller
    {
        private readonly NewsDataContext _db;
        public NewsController(NewsDataContext db)
        {
            _db = db;
        }
        [Route("index")]
        public IActionResult Index()
        {
            var posts = _db.Posts.OrderByDescending(x => x.Posted).Take(5).ToArray();
            return View(posts);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = _db.Posts.FirstOrDefault(x => x.Key == key);

            //var post = new Post
            //{
            //    Title="My 1st Test Blog",
            //    Posted=DateTime.Now,
            //    Author="BB",
            //    Body="a bit of lorum ipsum",
            //};


            return View(post);
        }
        //creat post page
        //[Authorize]
        [HttpGet, Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Route("create")]
            public IActionResult Create(Post post)
        {
            //validation check -- currently not taking data if invalid but not giving feedback to user
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;

            //add post to DB
            _db.Posts.Add(post);
            _db.SaveChanges(true);

            return this.RedirectToAction("Index","News");
        }
        
    }
}
