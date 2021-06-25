using Application.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Application.DAL
{
    public partial class QuizContext : DbContext
    {
        public QuizContext()
            : base("name=QuizConnection")
        {
        }

        public virtual DbSet<Odgovor> Odgovor { get; set; }
        public virtual DbSet<Pitanje> Pitanje { get; set; }
        public virtual DbSet<PlayedQuiz> PlayedQuiz { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pitanje>()
                .HasMany(e => e.Odgovor)
                .WithRequired(e => e.Pitanje)
                .HasForeignKey(e => e.PitanjeID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlayedQuiz>()
                .HasMany(e => e.Player)
                .WithRequired(e => e.PlayedQuiz)
                .HasForeignKey(e => e.PlayedQuizID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quiz>()
                .HasMany(e => e.Pitanje)
                .WithRequired(e => e.Quiz)
                .HasForeignKey(e => e.QuizID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Quiz>()
                .HasMany(e => e.PlayedQuiz)
                .WithRequired(e => e.Quiz)
                .HasForeignKey(e => e.QuizID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Quiz)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
