using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DB.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using DB.Seeder;
using DatabaseContext.UoW;
using Services;
using Services.DataManager;
using Services.Password;
using MongoDB.MongoUOW;
using Services.Text.AITraining;
using Services.FormatDate;

namespace App
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
            services.AddDbContext<AnnotationToolContext>(options =>
                           options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

/*            services.AddDbContext<AnnotationToolContext>(options =>
                           options.UseSqlServer("server=.\\SQLEXPRESS;database= AnnotationTool;Trusted_Connection=True;Encrypt=False;"));
*/
            services.AddDefaultIdentity <ApplicationUser>(configs =>
            {
                configs.SignIn.RequireConfirmedPhoneNumber = false;
                configs.SignIn.RequireConfirmedEmail = false;
            }).AddRoles<IdentityRole>().AddEntityFrameworkStores<AnnotationToolContext>();

            services.ConfigureApplicationCookie(configs =>
            {
                configs.LoginPath = "/Accountant/Login";
                configs.LogoutPath = "/Accountant/Logout";
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMongoUOW, MongoUOW>();
            services.AddScoped<IDataDecompresser, RarDecompressor>();
            services.AddScoped<IDataManagerUOW, DataManagerUOW>();
            services.AddScoped<IPasswordGenerator, RandomPassword>();
            services.AddHostedService<TasksChecker>();
            services.AddScoped<FormatDate>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IUnitOfWork _uow)
        {
            RoleSeeder.SeedRoleAsync(roleManager).Wait();
            InputTypeSeeder.SeedInputType(_uow);
            AnnotationClassMappingSeeder.SeedAnnotationClassMapping(_uow);
            DistributionPolicySeeder.SeedDistributionPolicy(_uow);
            TaskTypeSeeder.SeedTaskType(_uow);
            AdminUserSeeder.SeedAdminAsync(userManager).Wait();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
