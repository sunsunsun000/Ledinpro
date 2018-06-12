using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ledinpro.Data;
using Ledinpro.Models;
using Ledinpro.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ledinpro
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
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("LedinproAccountConnection")));
            // services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source=ApplicationDb.db"));
            // 使用内存数据库
            // services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services.AddDbContext<LedinproContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("LedinproConnection")));
            // 使用Sqlite
            // services.AddDbContext<LedinproContext>(options => options.UseSqlite("Data Source=Ledinpro.db"));

            // 验证服务
            services.AddIdentity<ApplicationUser, ApplicationRole>(config => {
                // 配置用户登录需要邮件验证
                // config.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            // 配置验证信息
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Account/Login";  // If the LoginPath is not set in here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set in here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDenied is not set in here, ASP.NET Core will default to /Account/AccessDenied
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc(mvcConfig =>
            {
                // 配置所有页面都需要登录才能访问，所有的Controller
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();

                mvcConfig.Filters.Add(new AuthorizeFilter(policy));
            });

            services.Configure<AuthMessageSenderOptions>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
