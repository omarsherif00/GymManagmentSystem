using GymManagmentDAL.Data.Contexts;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repositries.abstractions;
using GymManagmentDAL.Repositries.Implementation;
using GymManagmentDAL.UnitOfWorkPattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GymManagmentPL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<GymDbContext>(
                Options => //Options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings")["DefualtConnection"])
                           // Options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"])
                            Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

                );


         //   builder.Services.AddScoped(typeof(IGenericRepositry<>), typeof(GenericRepositry<>));
            builder.Services.AddScoped(typeof(IUnitOfWork),typeof(UnitOfWork));
           // builder.Services.AddScoped(typeof(IPlanRepositries), typeof(PlanRepositry));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
