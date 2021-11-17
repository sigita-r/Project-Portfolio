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
{
    public class EF_Test
    {
        private readonly Mock<IDataService> _dataServiceMock;
        private readonly Mock<LinkGenerator> _linkGeneratorMock;

        private readonly OurMDB_Context ctx;
        private readonly DataService dataservice;
        string password = "password";

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
            User user = dataservice.CreateUser("testuser", pwBytes, "testemail@test.com", DateTime.Now);
            Assert.Equal(1, user.Id);
            Assert.Equal("testuser", user.Username);
            Assert.Equal("testemail@test.com", user.Email);

        }
        [Fact]
        public void Login_Test()
        {
            string response = dataservice.Login("testuser", Encoding.Unicode.GetBytes(password));
            Assert.Equal("Login accepted", response);
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

            List<Search_results> result = dataservice.SS_Search(2, "Batman", "Gotham", "", "");
            Assert.Equal(11, result.Count);
        }

        

    }
}
