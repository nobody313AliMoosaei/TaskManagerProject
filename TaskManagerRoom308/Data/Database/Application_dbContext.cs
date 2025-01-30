using Microsoft.EntityFrameworkCore;
using TaskManagerRoom308.Data.Entities;

namespace TaskManagerRoom308.Data.Database
{
    public class Application_dbContext : DbContext
    {
        public Application_dbContext(DbContextOptions<Application_dbContext>option)
            :base(option)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Entities.Task> Tasks { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }


        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).HasMaxLength(220).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(320).IsRequired();
                entity.Property(e => e.PhoneNumber).HasMaxLength(13).IsRequired();
                entity.Property(e => e.NationalCode).HasMaxLength(10).IsRequired();
            });
            modelBuilder.Entity<Entities.Task>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).HasMaxLength(200).IsRequired();
                entity.Property(e => e.Tag).HasMaxLength(150);
            });
            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.UserRefNavigation)
                .WithMany(e => e.UserTasks)
                .HasForeignKey(e => e.UserRef)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(e => e.TaskRefNavigation)
                .WithMany(e => e.UserTasks)
                .HasForeignKey(e => e.TaskRef)
                .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
