using System.Web.Mvc;
using SimpleInjector;
using Ui;
using Ui.Controllers;
using Xunit;

namespace SmokeTests
{
    public class HomeControllerSmokeTests
    {
        private readonly Container _container;

        public HomeControllerSmokeTests()
        {
            _container = new Container();
            SimpleInjectorConfig.InitialiseContainerForTest(_container);
        }

        [Fact]
        public void CanReachIndex()
        {
            var sut = _container.GetInstance<HomeController>();

            var result = sut.Index().Result as ViewResult;

            Assert.Equal("Hello World!", result.ViewBag.Posts[0].Title);
        }

        [Fact]
        public void CanReachAbout()
        {
            var sut = _container.GetInstance<HomeController>();

            var result = sut.About() as ViewResult;

            Assert.Equal("Your app description page.", result.ViewBag.Message);
        }

        [Fact]
        public void CanReachContact()
        {
            var sut = _container.GetInstance<HomeController>();

            var result = sut.Contact() as ViewResult;

            Assert.Equal("Your contact page.", result.ViewBag.Message);
        }
    }
}
