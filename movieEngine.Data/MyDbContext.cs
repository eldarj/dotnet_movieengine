using Microsoft.EntityFrameworkCore;
using movieEngine.Data.Models;
using System;

namespace movieEngine.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        #region DbSets
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<TitleType> TitleTypes { get; set; }
        public DbSet<TitleActor> TitlesActors { get; set; }
        public DbSet<Client> Clients { get; set; } // registered api clients
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TitleActor>()
                .HasKey(ta => new { ta.TitleId, ta.ActorId });

            modelBuilder.Entity<TitleActor>()
                .HasOne<Title>(ta => ta.Title)
                .WithMany(t => t.Actors)
                .HasForeignKey(ta => ta.TitleId);


            modelBuilder.Entity<TitleActor>()
                .HasOne<Actor>(ta => ta.Actor)
                .WithMany(a => a.Titles)
                .HasForeignKey(ta => ta.ActorId);
        }
    }
}
