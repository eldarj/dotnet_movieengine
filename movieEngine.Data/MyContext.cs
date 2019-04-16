using Microsoft.EntityFrameworkCore;
using movieEngine.Data.Models;
using System;

namespace movieEngine.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        #region DbSets
        DbSet<Actor> Actors { get; set; }
        DbSet<Title> Titles { get; set; }
        DbSet<TitleType> TitleTypes { get; set; }
        DbSet<Client> Clients { get; set; } // registered api clients
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
