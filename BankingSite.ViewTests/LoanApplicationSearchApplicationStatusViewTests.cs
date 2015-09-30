using BankingSite.Models;
using BankingSite.Views.LoanApplicationSearch;
using HtmlAgilityPack;
using NUnit.Framework;
using RazorGenerator.Testing;

namespace BankingSite.ViewTests
{
    [TestFixture]
    public class LoanApplicationSearchApplicationStatusViewTests
    {
        [Test]
        public void ShouldRenderAcceptedMessage()
        {
            var sut = new ApplicationStatus();
            var model = new LoanApplication()
            {
                IsAccepted = true,
            };
            HtmlDocument html = sut.RenderAsHtml(model);
            var isAcceptedMsgRenderd = html.GetElementbyId("acceptedMessage") != null;
            var isDeclinedMsgRenderd = html.GetElementbyId("declinedMessage") != null;
            Assert.That(isAcceptedMsgRenderd, Is.True);
            Assert.That(isDeclinedMsgRenderd, Is.False);
        }
    }
}
