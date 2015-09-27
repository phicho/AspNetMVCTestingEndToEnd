using System.Net;
using BankingSite.Controllers;
using BankingSite.Models;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace BankingSite.ControllerTests
{
    [TestFixture]
    public class LoanApplicationSearchControllerTests
    {
        [Test]
        public void ShouldReturn4045StatusWhenLoanIdNotFound()
        {
            var fakeRepo = new Mock<IRepository>();
            var sut = new LoanApplicationSearchController(fakeRepo.Object);
            sut.WithCallTo(x => x.ApplicationStatus(99)).ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }

        [Test]
        public void ShouldRenderApplicationWhenIdExists()
        {
            const string fakeName = "Phill";
            var fakeRepo = new Mock<IRepository>();
            fakeRepo.Setup(f => f.Find(99)).Returns(new LoanApplication() {FirstName = fakeName }); 
            var sut = new LoanApplicationSearchController(fakeRepo.Object);
            sut.WithCallTo(x => x.ApplicationStatus(99))
                .ShouldRenderDefaultView()
                .WithModel<LoanApplication>(la => la.FirstName == fakeName);
        }
    }
}
