using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;
using SchoolDetails.Repository;
using SchoolDetails.Models;
using System.Collections.Generic;

namespace SchoolDetails.XUnitTest
{
    public class CommonRepositoryUnitTest
    {
        [Fact]
        public async Task GetSchoolDetailsList()
        {
            // Arrange
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);

            // Act
            var response = await Task.FromResult(controller.GetSchoolDbSet());

            dbContext.Dispose();

            // Assert
            Assert.IsType<List<SchoolDetail>>(response);

        }

        [Fact]
        public async Task GetSchoolDetailsListNotNull()
        {
            // Arrange
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);

            // Act
            var response = await Task.FromResult(controller.GetSchoolDbSet());

            dbContext.Dispose();

            // Assert
            Assert.NotNull(response);

        }

        [Fact]
        public async void Task_GetSchoolDetailById_Return_SchoolObject()
        {
            //Arrange  
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);
            var postId = 3;

            //Act  
            var response = await Task.FromResult(controller.GetSchoolDetail(postId));

            //Assert  
            Assert.IsType<SchoolDetail>(response);
        }

        [Fact]
        public async void Task_GetSchoolDetailById_Return_SchoolObjectNotNull()
        {
            //Arrange  
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);
            var postId = 3;

            //Act  
            var response = await Task.FromResult(controller.GetSchoolDetail(postId));

            //Assert  
            Assert.NotNull(response);
        }

        [Fact]
        public async void Task_GetSchoolDetailById_Return_NullObject()
        {
            //Arrange  
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);
            var postId = 15;

            //Act  
            var response = await Task.FromResult(controller.GetSchoolDetail(postId));

            //Assert  
            Assert.Null(response);
        }

        [Fact]
        public async void Task_PostSchoolDetailById_Return_SchoolObject()
        {
            //Arrange  
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);
            var schoolDetails = new SchoolDetail
            {
                Address = "SixPune",
                Name = "SchoolSix",
                ContactEmail = "Six@m.com",
                PhoneNumber = 9096626711,
                Website = "SchoolSix.com",
                LogoUrl = "LogoUrlSix"
            };

            //Act  
            var response = await Task.FromResult(controller.PostSchoolDetail(schoolDetails));

            //Assert  
            Assert.IsType<SchoolDetail>(response);
        }

        [Fact]
        public async void Task_PutSchoolDetailById_Return_SchoolObject()
        {
            //Arrange  
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);
            var Id = 1;
            var schoolDetails = new SchoolDetail
            {
                Address = "SixPune",
                Name = "SchoolSix",
                ContactEmail = "Six@m.com",
                PhoneNumber = 9096626711,
                Website = "SchoolSix.com",
                LogoUrl = "LogoUrlSix",
                ID = 1
            };

            //Act  
            var response = await Task.FromResult(controller.PutSchoolDetail(Id, schoolDetails));

            //Assert  
            Assert.IsType<SchoolDetail>(response);
        }


        [Fact]
        public async void Task_DeleteSchoolDetailById_Return_True()
        {
            //Arrange  
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);
            var Id = 1;


            //Act  
            var response = await Task.FromResult(controller.DeleteSchoolDetail(Id));

            //Assert  
            Assert.True(response);
        }

        [Fact]
        public async void Task_DeleteSchoolDetailById_Return_False()
        {
            //Arrange  
            var dbContext = SchoolDbContextMocker.GetSchoolDbContext();
            var controller = new CommonRepository(dbContext);
            var Id = 15;


            //Act  
            var response = await Task.FromResult(controller.DeleteSchoolDetail(Id));

            //Assert  
            Assert.True(response);
        }

    }
}
