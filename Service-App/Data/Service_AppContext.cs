using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.EntityFrameworkCore;
using Service_App.Models;


namespace Service_App.Data
{
    public class Service_AppContext : DbContext
    {
        public Service_AppContext (DbContextOptions<Service_AppContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointments>()
                .HasIndex(a => a.AppointmentDate)
                .IsUnique();
            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.Service)
                .WithMany()
                .HasForeignKey(a => a.ServiceId);

            modelBuilder.Entity<Appointments>()
                .HasOne(a => a.AppointmentStatus)
                .WithOne(s => s.Appointments)
                .HasForeignKey<AppointmentStatus>(s => s.AppointmentId);

            modelBuilder.Entity<AppointmentStatus>()
                .HasOne(s => s.Appointments)
                .WithOne(a => a.AppointmentStatus)
                .HasForeignKey<Appointments>(a => a.StatusId);

        }


        public DbSet<Appointments> Appointments { get; set; } = default!;
        public DbSet<Services> Services { get; set; }
        public DbSet<AppointmentStatus> AppointmentStatus { get; set; }
        public DbSet<Member>? Members { get; set; }

    }
}
