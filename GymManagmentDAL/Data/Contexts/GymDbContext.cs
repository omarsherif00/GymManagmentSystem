using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Contexts
{
    public class GymDbContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=GymDB;Trusted_Connection=true;TrustServerCertificate=true");
        //}

        public GymDbContext(DbContextOptions<GymDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainer { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<session> Sessions { get; set; }
        public DbSet<HealthRecord> HealthRecords { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<MemberSession> MemberSessions { get; set; }
    }
}
