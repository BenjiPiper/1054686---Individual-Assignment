using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1054686___Individual_Assignment.Models
{
    public class Post
    {
        //for use with Posting news to DB
        public long Id { get; set; }
        //key not doing anything, getting null value? workaround using ID to call back on for individual post viewings??
        private string _key;
        public string Key { get; set; }

//        {
//            get
//            {
//                if (_key == null)
//                {
//                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
//                }
//                return _key;
//            }
//              set
//                  { _key = value; }
       // }
        //title
        [Display(Name ="Title")]
        [Required]
        [StringLength(100, MinimumLength =5, ErrorMessage ="Title must be between 5 and 100 characters long")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        //author
        public string Author { get; set; }
        //body
        [Required]
        [MinLength(20,ErrorMessage ="Body must be atleast 20 characters long")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        //date
        public DateTime Posted { get; set; }
    }
}
