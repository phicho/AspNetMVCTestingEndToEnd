using System.Web.Mvc;
using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
    [TestFixture]
    public class LoanApplicationControllerTests
    {
        [Test]
        public void ShouldRenderDefaultView()
        {
            var fakeRepo = new Mock<IRepository>();
            var fakeAppScorer = new Mock<ILoanApplicationScorer>();

            var sut = new LoanApplicationController(fakeRepo.Object, fakeAppScorer.Object);

            sut.WithCallTo(x => x.Apply()).ShouldRenderDefaultView();

        }
    }
}
