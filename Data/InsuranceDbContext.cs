using Microsoft.EntityFrameworkCore; 
using Microsoft.EntityFrameworkCore.Design; 
using InsuranceApp.Models; 
 
namespace InsuranceApp.Data 
{ 
    public class InsuranceDbContext : DbContext 
    { 
        public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options) : base(options) { } 
 
        public DbSet<Insuree> Insurees { get; set; } 
 
        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<InsuranceDbContext> 
        { 
            public InsuranceDbContext CreateDbContext(string[] args) 
            { 
                var optionsBuilder = new DbContextOptionsBuilder<InsuranceDbContext>(); 
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=InsuranceDatabase;Trusted_Connection=True;MultipleActiveResultSets=true;AttachDbFilename=C:\\Users\\HP\\Desktop\\InsuranceApp\\App_Data\\InsuranceDatabase.mdf"); 
                return new InsuranceDbContext(optionsBuilder.Options); 
            } 
        } 
    } 
} 
