using AlbertosMarket.Controllers;
using AlbertosMarket.DAL;
using AlbertosMarket.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace AlbertosMarket.Tests.Controllers
{
    [TestClass]
    public class MarketControllerTest
    {

        [TestMethod]
        public void Create()
        {
            // Arrange
            MarketController controller = new MarketController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        private MarketController setup_repo()
        {
            IMarketRepository market_repo = new MarketRepository(new MarketContext());
            IAuthorRepository author_repo = new AuthorRepository(new MarketContext());

            author_repo.InsertAuthor(new Author { ID = "1234", Name = "Alberto", JoinDate = DateTime.Parse("2002-07-06"), location = "USA" });
            market_repo.InsertMarket(new Market
            {
                ID = 123456,
                AuthorID = "1234",
                Title = "Used Honda Civic 2017",
                Option = TradeOption.Selling,
                PostDate = DateTime.Parse("2005-09-01"),
                Price = 5000,
                Post = "New beautiful car that I recently crashed."
            });

            MarketController controller = new MarketController(market_repo, author_repo);

            return controller;
        }
    }


}
