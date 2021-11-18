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
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        private const string UserApi = "https://localhost:44352/api/user";

        [Fact]
        public void ApiUser_InvalidId_BadRequest()
        {
            var (_, statusCode) = GetObject($"{UserApi}/okokokok");

            Assert.Equal(HttpStatusCode.BadRequest, statusCode);
        }

        [Fact]
        public void ApiUser_validId()
        {
            var (_, statusCode) = GetObject($"{UserApi}/3");

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public void ApiUser_invalidId_NotFound()
        {
            var (_, statusCode) = GetObject($"{UserApi}/999");

            Assert.Equal(HttpStatusCode.NotFound, statusCode);
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
        /*
        ////////////////////////////////////////////////////////////
        //                      PERSONALITY                       //
        ////////////////////////////////////////////////////////////

        [Fact]
        public void GetPersonality_returntype_test()
        {
            _dataServiceMock.Setup(x => x.GetPersonalityById(It.IsAny<int>())).Returns(new Personality());
            var PersonalityController = CreatePersonalityController();
            var Personality = PersonalityController.GetPersonalityByID(123);
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
            var res = BookmarkController.GetBookmarkPersonalitiesForUser(3);
            Console.WriteLine(res);
            Assert.IsType<OkObjectResult>(res);
        }

        [Fact]
        public void GetTitleBMs_returntype_test()
        {
            _dataServiceMock.Setup(x => x.GetTitleBMsByUserID(It.IsAny<int>())).Returns(new List<Bookmarks_Title>());
            var BookmarkController = CreateBookmarkController();
            var res = BookmarkController.GetBookmarkTitlesForUser(3);
            Assert.IsType<OkObjectResult>(res);
        }


        private BookmarkController CreateBookmarkController()
        {
            var BookmarkController = new BookmarkController(_dataServiceMock.Object, _linkGeneratorMock.Object);
            BookmarkController.ControllerContext = new ControllerContext();
            BookmarkController.ControllerContext.HttpContext = new DefaultHttpContext();
            return BookmarkController;
        }
        */

        // Helpers

        (JArray, HttpStatusCode) GetArray(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JArray)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) GetObject(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) PostData(string url, object content)
        {
            var client = new HttpClient();
            var requestContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");
            var response = client.PostAsync(url, requestContent).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        HttpStatusCode PutData(string url, object content)
        {
            var client = new HttpClient();
            var response = client.PutAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(content),
                    Encoding.UTF8,
                    "application/json")).Result;
            return response.StatusCode;
        }

        HttpStatusCode DeleteData(string url)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync(url).Result;
            return response.StatusCode;
        }
    }
}
