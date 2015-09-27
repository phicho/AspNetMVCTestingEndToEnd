using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace BankingSite.IntegrationTests
{
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
           AppDomain.CurrentDomain.SetData("DataDirectory", NUnit.Framework.TestContext.CurrentContext.TestDirectory);
        }
    }
}
