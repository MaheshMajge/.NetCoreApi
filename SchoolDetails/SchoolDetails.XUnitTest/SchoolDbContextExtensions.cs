using System;
using System.Collections.Generic;
using System.Text;
using SchoolDetails.Data;
using SchoolDetails.Models;

namespace SchoolDetails.XUnitTest
{
    public static class SchoolDbContextExtensions
    {
        public static void Seed(this SchoolDbContext dbContext)
        {
            dbContext.SchoolDbSet.Add(new SchoolDetail
            {
                Address = "Pune",
                Name = "SchoolFirst",
                ContactEmail = "m@m.com",
                PhoneNumber = 9096626711,
                Website = "SchoolFirst.com",
                LogoUrl = "LogoUrl"
            });
            dbContext.SchoolDbSet.Add(new SchoolDetail
            {
                Address = "Pune",
                Name = "SchoolSecond",
                ContactEmail = "m@m.com",
                PhoneNumber = 9096626711,
                Website = "SchoolSecond.com",
                LogoUrl = "LogoUrl"
            });
            dbContext.SchoolDbSet.Add(new SchoolDetail
            {
                Address = "Pune",
                Name = "SchoolThird",
                ContactEmail = "m@m.com",
                PhoneNumber = 9096626711,
                Website = "SchoolThird.com",
                LogoUrl = "LogoUrl"
            });
            dbContext.SchoolDbSet.Add(new SchoolDetail
            {
                Address = "Pune",
                Name = "SchoolFourth",
                ContactEmail = "m@m.com",
                PhoneNumber = 9096626711,
                Website = "SchoolFourth.com",
                LogoUrl = "LogoUrl"
            });
            dbContext.SaveChanges();
        }
    }
}
