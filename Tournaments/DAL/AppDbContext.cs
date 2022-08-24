using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tournaments.Models;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Tournaments.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tournament> Tournament { get; set; }

        public DbSet<Event> Event { get; set; }

        public DbSet<EventDetailStatus> EventDetailStatus { get; set; }

        public DbSet<EventDetail> EventDetail { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventDetail>().Property(x => x.EventDetailOdd).HasPrecision(18, 7);
            modelBuilder.Entity<EventDetail>().Property(x => x.EventDetailName).HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<Event>().Property(x => x.EventName).HasMaxLength(100).IsUnicode(false);
            modelBuilder.Entity<EventDetailStatus>().Property(x => x.EventDetailStatusName).HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<Tournament>().Property(x => x.TournamentName).HasMaxLength(200).IsUnicode(false);
            modelBuilder.Entity<Users>().Property(x => x.Username).HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<Users>().Property(x => x.Password).HasMaxLength(50).IsUnicode(false);

            modelBuilder.Entity<Tournament>().ToTable("Tournament");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<EventDetail>().ToTable("EventDetail");
            modelBuilder.Entity<EventDetailStatus>().ToTable("EventDetailStatus");
            modelBuilder.Entity<Users>().ToTable("User");






            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Users> User { get; set; }
        public DbSet<UserRoleMapping> UserRoleMappings { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Role> Roles { get; set; }
    }
}