using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthWebApiKios.Context;
using AuthWebApiKios.Services;
using System.Data.Entity;
using AuthWebApiKios.Controllers;

namespace AuthWebApiTest
{
    [TestClass]
    public class accountUniTest
    {
        private UserService _UserService = null;

        
        public accountUniTest()
        {
            System.Data.Entity.Database.SetInitializer<MyDbContext>(new DropCreateDatabaseIfModelChanges<MyDbContext>());
            _UserService = new UserService();
        }

        [TestMethod]
        public void Register()
        {
            
        }
    }
}
