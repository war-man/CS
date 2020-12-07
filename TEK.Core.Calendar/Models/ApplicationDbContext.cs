using Microsoft.EntityFrameworkCore;
using CS.EF.Models;

namespace TEK.Core.Calendar.Models
{
    public class ApplicationDbContext : DbContext
    {
        #region  Model 

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<Room> Rooms { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        //public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<Schedule> Schedules { get; set; }

        public virtual DbSet<Shift> Shifts { get; set; }

        public virtual DbSet<Time> Times { get; set; }

        #endregion


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<DeviceConfig>().HasKey(k => new { k.DeviceId, k.ApplicationId });
        //    builder.Entity<DeviceConfig>().UseXminAsConcurrencyToken();
        //    builder.Entity<Device>().UseXminAsConcurrencyToken();
        //}
    }
}
