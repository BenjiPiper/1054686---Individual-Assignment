using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1054686___Individual_Assignment.Models
{
    public class EventsDataContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public EventsDataContext(DbContextOptions<EventsDataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
