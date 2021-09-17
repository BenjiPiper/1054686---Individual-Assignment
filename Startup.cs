using _1054686___Individual_Assignment.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1054686___Individual_Assignment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Enabale DB for news posts
            services.AddDbContext<NewsDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("NewsDataContext");
                options.UseSqlServer(connectionString);
            });
            //DB for Events
            services.AddDbContext<EventsDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("EventsDataContext");
                options.UseSqlServer(connectionString);
            });

            //enable MVC
            services.AddRazorPages();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //addMVC - Personal Note: now known as endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Defualt", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseFileServer();
        }
    }
}
