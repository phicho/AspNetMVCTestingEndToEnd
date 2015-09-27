using System;
using System.Data.Entity;
using NUnit.Framework;

namespace BankingSite.IntegrationTests
{
    [SetUpFixture]
    public class TestFixtureLifeCycle
    {
        public TestFixtureLifeCycle()
        {
            EnsureDataDirectoryConnectionStringPlaceHolderIsSet();

            EnsoureNoExistingDatabaseFiles();

        }

        private void EnsoureNoExistingDatabaseFiles()
        {
            const string connString = "name=DefaultConnection";

            if (Database.Exists(connString))
            {
                Database.Delete(connString);
            }
        }

        private static void EnsureDataDirectoryConnectionStringPlaceHolderIsSet()
        {
           AppDomain.CurrentDomain.SetData("DataDirectory", TestContext.CurrentContext.TestDirectory);
        }
    }
}
