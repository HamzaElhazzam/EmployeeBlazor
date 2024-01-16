using EmployeeCrudBlazor.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudBlazor.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Commande> Commandes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Employee)
                .WithMany()
                .HasForeignKey(c => c.Id_Employee)
                    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Commande>()
                .HasOne(c => c.Article)
                .WithMany()
                .HasForeignKey(c => c.Id_Article)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
