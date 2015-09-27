using BankingSite.Models;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void ShouldPopulateIdOnCreateLoanApplication()
        {
            var sut = new Repository();

            var appToSave = new LoanApplication()
            {
                LastName = "Mit",
                FirstName = "Philip",
                Age = 29,
                AnnualIncome = 1232312.22m
            };

            sut.Create(appToSave);

            Assert.That(appToSave.ID, Is.Not.EqualTo(0));
        }
    }
}
