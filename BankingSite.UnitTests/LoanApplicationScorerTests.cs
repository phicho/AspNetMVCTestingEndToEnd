using BankingSite.Models;
using Moq;
using NUnit.Framework;

namespace BankingSite.UnitTests
{
    [TestFixture]
    public class LoanApplicationScorerTests
    {
        public void ShouldDeclineWhenNotTooYoungAndWWealthyButPoorCredit_Classic()
        {
            var sut = new LoanApplicationScorer(new CreditHistoryChecker());

            var application = new LoanApplication()
            {
                FirstName = "Sarah",
                LastName = "Smith",
                Age = 22,
                AnnualIncome = 1000000.01m
            };

            sut.ScoreApplication(application);

            Assert.That(application.IsAccepted, Is.False);
        }

        public void ShouldDeclineWhenNotTooYoungAndWWealthyButPoorCredit()
        {
            var fakeCreditCartChacker = new Mock<ICreditHistoryChecker>();
            fakeCreditCartChacker.Setup(x => x.CheckCreditHistory(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            var sut = new LoanApplicationScorer(fakeCreditCartChacker.Object);

            var application = new LoanApplication()
            {
                Age = 22,
                AnnualIncome = 1000000.01m
            };

            sut.ScoreApplication(application);

            Assert.That(application.IsAccepted, Is.False);
        }
    }
}
