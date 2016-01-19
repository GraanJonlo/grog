using System.Web.Mvc;
using NUnit.Framework;
using Ui.Controllers;

namespace SmokeTests
{
    [TestFixture]
    public class HomeControllerSmokeTests
    {
        [Test]
        public void CanReachIndex()
        {
            var sut = new HomeController();

            var result = sut.Index() as ViewResult;

            Assert.That(result.ViewBag.Message, Is.EqualTo("Modify this template to jump-start your ASP.NET MVC application."));
        }

        [Test]
        public void CanReachAbout()
        {
            var sut = new HomeController();

            var result = sut.About() as ViewResult;

            Assert.That(result.ViewBag.Message, Is.EqualTo("Your app description page."));
        }

        [Test]
        public void CanReachContact()
        {
            var sut = new HomeController();

            var result = sut.Contact() as ViewResult;

            Assert.That(result.ViewBag.Message, Is.EqualTo("Your contact page."));
        }
    }
}
