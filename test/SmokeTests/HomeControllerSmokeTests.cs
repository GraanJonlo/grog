using System.Web.Mvc;
using NUnit.Framework;
using SimpleInjector;
using Ui;
using Ui.Controllers;

namespace SmokeTests
{
    [TestFixture]
    public class HomeControllerSmokeTests
    {
        private Container _container;

        [SetUp]
        public void SetUp()
        {
            _container = new Container();
            SimpleInjectorConfig.InitialiseContainerForTest(_container);
        }

        [Test]
        public void CanReachIndex()
        {
            var sut = _container.GetInstance<HomeController>();

            var result = sut.Index().Result as ViewResult;

            Assert.That(result.ViewBag.Message, Is.EqualTo("Hello world!"));
        }

        [Test]
        public void CanReachAbout()
        {
            var sut = _container.GetInstance<HomeController>();

            var result = sut.About() as ViewResult;

            Assert.That(result.ViewBag.Message, Is.EqualTo("Your app description page."));
        }

        [Test]
        public void CanReachContact()
        {
            var sut = _container.GetInstance<HomeController>();

            var result = sut.Contact() as ViewResult;

            Assert.That(result.ViewBag.Message, Is.EqualTo("Your contact page."));
        }
    }
}
