using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GlebLab3
{
    public partial class TrainingContext : DbContext
    {
        public TrainingContext()
        {
        }

        public TrainingContext(DbContextOptions<TrainingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameDate> GameDates { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Training;Username=postgres;Password=qwerty");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Team1Id).HasColumnName("team1_id");

                entity.Property(e => e.Team2Id).HasColumnName("team2_id");

                entity.HasOne(d => d.Team1)
                    .WithMany(p => p.GameTeam1s)
                    .HasForeignKey(d => d.Team1Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("team1_id");

                entity.HasOne(d => d.Team2)
                    .WithMany(p => p.GameTeam2s)
                    .HasForeignKey(d => d.Team2Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("team2_id");
            });

            modelBuilder.Entity<GameDate>(entity =>
            {
                entity.ToTable("game_date");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DateId).HasColumnName("date_id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.HasOne(d => d.Date)
                    .WithMany(p => p.GameDates)
                    .HasForeignKey(d => d.DateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("date_id");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameDates)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_id");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.HasIndex(e => e.Date, "date")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Date)
                    .HasColumnType("date")
                    .HasColumnName("date");

                entity.Property(e => e.WorkingDay).HasColumnName("working_day");
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.ToTable("score");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.Score1).HasColumnName("score1");

                entity.Property(e => e.Score2).HasColumnName("score2");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("game_id");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
