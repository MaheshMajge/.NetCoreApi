using Microsoft.EntityFrameworkCore;
using SchoolDetails.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDetails.XUnitTest
{
    public static class SchoolDbContextMocker
    {
        public static SchoolDbContext GetSchoolDbContext()
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            // Create instance of DbContext
            var dbContext = new SchoolDbContext(options);

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}

