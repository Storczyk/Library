using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Library.Infrastructure.Models;
using Library.Infrastructure.Extensions.Email;
using Microsoft.AspNetCore.Mvc.Razor;
using Library.Web.Extensions;
using Library.Infrastructure.Identity;

namespace Library.Web
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
            services.AddDbContext<LibraryDbContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LibraryDbContext>()
                .AddDefaultTokenProviders()
                .AddUserStore<LibraryUserStore>();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<RazorViewEngineOptions>(opt =>
            {
                opt.ViewLocationExpanders.Add(new ViewLocationExpander());
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            //var serviceProvider = app.ApplicationServices.GetService<IServiceProvider>();
            RolesData.SeedRoles(app.ApplicationServices).Wait();
            RolesData.SeedUsers(app.ApplicationServices).Wait();

            //CreateRolesAndUsers(serviceProvider);
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area=Default}/{controller=Home}/{action=Index}"
                    );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

            });
        }

        //private async void CreateRolesAndUsers(IServiceProvider serviceProvider)
        //{
            
        //    var options = new DbContextOptionsBuilder<LibraryDbContext>()
        //        .UseSqlServer("Server=PSROCZYK-RZE\\SQLEXPRESS;Database=libraryDB;User Id=test;Password=test;MultipleActiveResultSets=True");

        //    LibraryDbContext context = new LibraryDbContext(options.Options);

        //    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
        //    // In Startup iam creating first Admin Role and creating a default Admin User    
        //    if (!await roleManager.RoleExistsAsync("Admin"))
        //    {

        //        // first we create Admin rool   
        //        var role = new IdentityRole();
        //        role.Name = "Admin";
        //        await roleManager.CreateAsync(role);


        //        //Here we create a Admin super user who will maintain the website                  

        //        var user = new ApplicationUser();
        //        user.UserName = "PGS";
        //        user.Email = "testingpgsapp@gmail.com";

        //        string userPWD = "Test90()";

        //        var createPowerUser = await userManager.CreateAsync(user, userPWD);

        //        //Add default User to Role Admin   
        //        if (createPowerUser.Succeeded)
        //        {
        //            var result1 = await userManager.AddToRoleAsync(user, "Admin");

        //        }
        //    }
        //}
    }
}
