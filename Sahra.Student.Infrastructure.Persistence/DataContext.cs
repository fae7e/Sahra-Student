using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Sahra.Student.DomainModel;
using System.Linq;
using Sahra.Student.Infrastructure.Persistence.EntityTypeConfigurations;

namespace Sahra.Student.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) { }
     
        public DbSet<DomainModel.Student> Students { get; set; }
               

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentConfiguration).Assembly);
        }
    }
}
