using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DZ_12_17_TSK03.Models;
using Microsoft.EntityFrameworkCore;

namespace DZ_12_17_TSK03
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<SupportSpecialist> SupportSpecialists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SupportRequest>()
                .HasKey(sr => sr.Id);
            modelBuilder.Entity<SupportRequest>()
                .Property(sr => sr.RequestTheme)
                .HasMaxLength(20)
                .IsRequired();
            modelBuilder.Entity<SupportRequest>()
                .Property(sr => sr.RequestDescription)
                .HasMaxLength(200);
            modelBuilder.Entity<SupportRequest>()
                .Property(sr => sr.Status)
                .HasMaxLength(20)
                .IsRequired();


            modelBuilder.Entity<Department>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Department>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<SupportSpecialist>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<SupportSpecialist>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<SupportRequest>()
                .HasOne(sr => sr.Specialist)
                .WithMany(s => s.SupportRequests)
                .HasForeignKey(sr => sr.SpecialistId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SupportSpecialist>()
                .HasOne(ss => ss.Department)
                .WithMany(d => d.SupportSpecialists)
                .HasForeignKey(ss => ss.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private static void SeedingData(ModelBuilder modelBuilder)
        {
            var random = new Random();
            var departmentNames = new string[] { "AmogusDepartment", "ImposterDepartment", "NormalDepartment" };
            var departments = departmentNames.Select(x => new Department()
            {
                Id = Guid.NewGuid(),
                Name = x
            });

            var supportSpecialistsNames = new string[]
                { "Ales", "Martin", "Arseniy", "Amogus", "Abobus", "Autobus", "Ivan", "Dima", "OLeg" };
            var supportSpecialists = supportSpecialistsNames.Select(x => new SupportSpecialist()
            {
                Id = Guid.NewGuid(),
                Name = x,
                DepartmentId = departments.ToArray()[random.Next(0, 3)].Id
            });

            modelBuilder.Entity<Department>().HasData(departments);
            modelBuilder.Entity<SupportSpecialist>().HasData(supportSpecialists);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=HelpDesk;Integrated Security=true;");
        }
    }
}