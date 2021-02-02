using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDetails.Models
{
    public class SchoolDbContext:DbContext
    {
        public DbSet<SchoolDetail> SchoolDbSet { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolDetail>().ToTable("SchoolDetail");
        }
    }
}
