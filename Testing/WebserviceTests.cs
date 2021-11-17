using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using Rawdata_Porfolio_2.Entity_Framework;
using Moq;
using Microsoft.AspNetCore.Routing;
using Webservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Test
{
    public class WebServiceTests
    {

        private readonly Mock<IDataService> _dataServiceMock;
        private readonly Mock<LinkGenerator> _linkGeneratorMock;

        public WebServiceTests()
        {
            _dataServiceMock = new Mock<IDataService>();
            _linkGeneratorMock = new Mock<LinkGenerator>();
        }


        ////////////////////////////////////////////////////////////
        //                          User                          //
        ////////////////////////////////////////////////////////////

        [Fact]
        public void GetUser_ValidUserId_ReturnsOkStatus()
        {
            _dataServiceMock.Setup(x => x.GetUser(It.IsAny<int>())).Returns(new User());
            var Usercontroller = CreateUserController();
            var user = Usercontroller.GetUser(123);
            Assert.IsType<OkObjectResult>(user);
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
