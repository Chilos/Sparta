using Microsoft.EntityFrameworkCore;
using Sparta.Web.Model;
using System.Linq;

namespace Sparta.Web.Data
{
    public class SpartaContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SpartaContext(DbContextOptions<SpartaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            ConfigureModelBuilderForUser(modelBuilder);
        }

        void ConfigureModelBuilderForUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .HasMaxLength(60)
                .IsRequired();

        }
    }
}
