using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AXIS.App.Core.Entities;

namespace AXIS.App.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<TaskPlan> TaskPlans { get; set; } = null!;
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TaskPlan>()
                .HasOne(tp => tp.User)
                .WithMany(u => u.TaskPlans)
                .HasForeignKey(tp => tp.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TaskPlan>()
                .Property(tp => tp.Subject)
                .HasMaxLength(256)
                .IsRequired();

            builder.Entity<TaskPlan>()
                .Property(tp => tp.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Entity<TaskPlan>()
                .HasOne(tp => tp.CreatedBy)
                .WithMany()
                .HasForeignKey(tp => tp.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
