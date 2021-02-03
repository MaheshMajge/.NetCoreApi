﻿using Microsoft.EntityFrameworkCore;
using NetCoreApi.Models;

namespace NetCoreApi.Data
{
    public class SchoolDbContext : DbContext
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
