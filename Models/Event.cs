using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1054686___Individual_Assignment.Models
{
    public class Event
    {
        //table reference
         public long Id { get; set; }
        //unique key for events
        private string _key;
            public string Key
        {
            get
            {
                if(_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set
            {
                _key = value;
            }
        }


        //form data
        [Display(Name = "Event Name")]
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 100 characters long")]
        [DataType(DataType.Text)]
        public string Title { get; set; }
        //author
        public string Author { get; set; }
        //date
        [Display(Name ="Event Date/Time")]
        [Required]
        public DateTime Time { get; set; }
        //competition location
        [Required]
        [MaxLength(50, ErrorMessage = "Location must be less than 50 characters")]
        [DataType(DataType.Text)]
        public string Location { get; set; }
        //body
        [Required]
        [MinLength(20, ErrorMessage = "Body must be atleast 20 characters long")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

    }
}
