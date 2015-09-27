using BankingSite.Controllers;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void ShouldRedirectToMyLinkedInPage()
        {
            var sut = new HomeController();
            sut.WithCallTo(x => x.Contact()).ShouldRedirectTo("https://mk.linkedin.com/in/filipmitkovski");
        }

    }
}
