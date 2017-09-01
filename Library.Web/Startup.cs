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
using Autofac;
using Library.Application.GeneralConcrete;
using Library.Application.General;
using System.Reflection;
using System;

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
                .AddUserStore<LibraryUserStore>()
                .AddDefaultTokenProviders();

            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(1000);
                options.CookieHttpOnly = true;
            });

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<RazorViewEngineOptions>(opt =>
            {
                opt.ViewLocationExpanders.Add(new ViewLocationExpander());
            });
            services.AddMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CommandBus>().As<ICommandBus>();
            builder.RegisterType<QueryDispatcher>().As<IQueryDispatcher>();
            builder.RegisterAssemblyTypes(Assembly.Load("Library"))
                .AsClosedTypesOf(typeof(ICommandHandler<>));
            builder.RegisterAssemblyTypes(Assembly.Load("Library"))
                .AsClosedTypesOf(typeof(IQueryHandler<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.UseStaticFiles();
            app.UseAuthentication();

            app.UseSession();
            RolesData.SeedRoles(app.ApplicationServices).Wait();
            RolesData.SeedUsers(app.ApplicationServices).Wait();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area=Default}/{controller=Books}/{action=Index}"
                    );
            });
        }
    }
}
