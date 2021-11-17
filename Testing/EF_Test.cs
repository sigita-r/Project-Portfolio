using System;
using Xunit;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using Rawdata_Porfolio_2.Entity_Framework;
using Webservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.AspNetCore.Routing;

namespace Test
{
    public class EF_Test
    {
        private readonly Mock<IDataService> _dataServiceMock;
        private readonly Mock<LinkGenerator> _linkGeneratorMock;

        private readonly OurMDB_Context ctx;
        private readonly DataService dataservice;

        public EF_Test()
        {
            _dataServiceMock = new Mock<IDataService>();
            _linkGeneratorMock = new Mock<LinkGenerator>();

            dataservice = new DataService();
            ctx = new OurMDB_Context();
        }


        ////////////////////////////////////////////////////////////
        //                          User                          //
        ////////////////////////////////////////////////////////////

        // This test is abit scuffed, as we just get a user we could manually have put into the database
        // but we dont have a deleteUser method, to be able to create a new user and then delete it after
        [Fact]
        public void GetUser_information_test()
        {
            User user = dataservice.GetUser(4);
            Assert.IsType<User>(user);
            Assert.Equal(4, user.Id);
            Assert.Equal("test", user.Username);
            Assert.Equal("testemail@test.com", user.Email);
        }

        private UserController CreateUserController()
        {
            var ctrl = new UserController(_dataServiceMock.Object, _linkGeneratorMock.Object);
            ctrl.ControllerContext = new ControllerContext();
            ctrl.ControllerContext.HttpContext = new DefaultHttpContext();
            return ctrl;
        }
    }
}
