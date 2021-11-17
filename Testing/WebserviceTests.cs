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
        public void GetUser_returntype_test()
        {
            _dataServiceMock.Setup(x => x.GetUser(It.IsAny<int>())).Returns(new User());
            var Usercontroller = CreateUserController();
            var user = Usercontroller.GetUser(123);
            Assert.IsType<OkObjectResult>(user);
        }

        [Fact]
        public void CreateUser_returntype_test()
        {
            _dataServiceMock.Setup(x => x.CreateUser(It.IsAny<string>(), It.IsAny<byte[]>(), It.IsAny<string>(), It.IsAny<DateTime>())).Returns(new User());
            var Usercontroller = CreateUserController();
            var user = Usercontroller.CreateUser("Test", "testpassword", "testmail.com", DateTime.Now);
            Assert.IsType<CreatedResult>(user);
        }

        private UserController CreateUserController()
        {
            var userController = new UserController(_dataServiceMock.Object, _linkGeneratorMock.Object);
            userController.ControllerContext = new ControllerContext();
            userController.ControllerContext.HttpContext = new DefaultHttpContext();
            return userController;
        }

        ////////////////////////////////////////////////////////////
        //                      PERSONALITY                       //
        ////////////////////////////////////////////////////////////

        [Fact]
        public void GetPersonality_returntype_test()
        {
            _dataServiceMock.Setup(x => x.GetPersonalityById(It.IsAny<int>())).Returns(new Personality());
            var PersonalityController = CreatePersonalityController();
            var Personality = PersonalityController.GetPersonalityByID(1);
            Assert.IsType<OkObjectResult>(Personality);
        }



        private PersonalityController CreatePersonalityController()
        {
            var PersonalityController = new PersonalityController(_dataServiceMock.Object, _linkGeneratorMock.Object);
            PersonalityController.ControllerContext = new ControllerContext();
            PersonalityController.ControllerContext.HttpContext = new DefaultHttpContext();
            return PersonalityController;
        }

        ////////////////////////////////////////////////////////////
        //                       BOOKMARKS                        //
        ////////////////////////////////////////////////////////////
      
        [Fact]
        public void GetPersonalityBMs_returntype_test()
        {
            _dataServiceMock.Setup(x => x.GetPersonalityBMsByUserID(It.IsAny<int>())).Returns(new List<Bookmarks_Personality>());
            var BookmarkController = CreateBookmarkController();
            var BMs = BookmarkController.GetBookmarkPersonalitiesForUser(1);
            Assert.IsType<OkObjectResult>(BMs);
        }

        private BookmarkController CreateBookmarkController()
        {
            var BookmarkController = new BookmarkController(_dataServiceMock.Object, _linkGeneratorMock.Object);
            BookmarkController.ControllerContext = new ControllerContext();
            BookmarkController.ControllerContext.HttpContext = new DefaultHttpContext();
            return BookmarkController;
        }


    }
}
