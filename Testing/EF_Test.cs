using System;
using Xunit;
using Rawdata_Porfolio_2.Pages.Entity_Framework.Domain;
using Rawdata_Porfolio_2.Entity_Framework;
using Webservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Moq;
using Microsoft.AspNetCore.Routing;
using System.Text;
using Rawdata_Porfolio_2.Entity_Framework.Domain;
using System.Collections.Generic;

namespace Test
{/*
    public class EF_Test
    {
        private readonly Mock<IDataService> _dataServiceMock;
        private readonly Mock<LinkGenerator> _linkGeneratorMock;

        private readonly OurMDB_Context ctx;
        private readonly DataService dataservice;
        private string password = "password";

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

        [Fact]
        public void Create_User_test()
        {
            byte[] pwBytes = Encoding.Unicode.GetBytes(password);
            User user = dataservice.CreateUser("1234testuser", pwBytes, "1234testemail@test.com", DateTime.Now);
            Assert.Equal("1234testuser", user.Username);
            Assert.Equal("1234testemail@test.com", user.Email);
            dataservice.DeleteUser(user.Id);
        }

        [Fact]
        public void Login_Test()
        {
            byte[] pwBytes = Encoding.Unicode.GetBytes(password);
            User user = dataservice.CreateUser("1234testuser", pwBytes, "1234testemail@test.com", DateTime.Now);
            string response = dataservice.Login("1234testuser", Encoding.Unicode.GetBytes(password));
            Assert.Equal("Login accepted", response);
            dataservice.DeleteUser(user.Id);
        }

        [Fact]
        public void GetTitleById_Test()
        {
            Title title = dataservice.GetTitleById(1);
            Assert.Equal(1, title.Id);
            Assert.Equal("tvSeries", title.Type);
            //Assert.Equal(false, title.IsAdult);
            Assert.Equal(2019, title.Year_Start);
            Assert.Equal(2020, title.Year_End);
            Assert.Equal(120, title.Runtime);
            //Assert.Equal(null, title.AvgRating);
            Assert.Equal("https://m.media-amazon.com/images/M/MV5BZjdhYzM0OWQtYTgxNi00NThhLThmNzgtNWE0NjU5NDNiNjNhXkEyXkFqcGdeQXVyNDg4MjkzNDk@._V1_SX300.jpg", title.Poster);
            Assert.Equal("Being the daughter of a prostitute mother, Akca gives up her motherhood in order to give her child a better future. The bride of a wealthy family, Sule promises to be a mother to Akca's ...", title.Plot);
        }

        [Fact]
        public void SS_Search_Test()
        {
            byte[] pwBytes = Encoding.Unicode.GetBytes(password);
            User user = dataservice.CreateUser("1234testuser", pwBytes, "1234testemail@test.com", DateTime.Now);
            List<Search_results> result = dataservice.SS_Search(user.Id, "Batman", "Gotham", "", "");
            Assert.Equal(11, result.Count);
            dataservice.DeleteUser(user.Id);
        }
    }
    */
}

