using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuthWebApiKios.Controllers;
using System.Web;
using System.Web.Http;
using AuthWebApiKios.Services;
using AuthWebApiKios.Models;
using System.Web.Http.Results;
using AuthWebApiKios.Context;
using System.Data.Entity;

namespace AuthWebApiTest
{
    [TestClass]
    public class userUniTest
    {
        private UserService _UserService = null;
       public userUniTest()
        {
            System.Data.Entity.Database.SetInitializer<MyDbContext>(new DropCreateDatabaseIfModelChanges<MyDbContext>());
            _UserService = new UserService();
        }

        [TestMethod]
        public void checkUserCase1()
        {
           

            //Test Successful Login
            AuthWebApiKios.RequestModels.UserAuthModel user = new AuthWebApiKios.RequestModels.UserAuthModel
            {
                Password = "eessaouira",
                UserName = "eessaouira"
            };
            var result_user = _UserService.CheckUser(user);
            Assert.IsNotNull(result_user);
        }

        [TestMethod]
        public void checkUserCase2()
        {
           

            //Test Successful Login
           AuthWebApiKios.RequestModels.UserAuthModel user = new AuthWebApiKios.RequestModels.UserAuthModel
            {
                Password = "error",
                UserName = "error"
            };
            var result_user = _UserService.CheckUser(user);
            Assert.IsNull(result_user);
        }

        [TestMethod]
        public void getUserByEmail()
        {
            //Test Get User By Id

            var result_user = _UserService.getByEmail("jnah.ahmed@gmail.com");
            Assert.IsNotNull(result_user);
        }

        [TestMethod]
        public void RecoverPassword()
        {
            //Test Get User By Id

            var result_user = _UserService.RecoverMyPassword("jnah.ahmed@gmail.com");
            Assert.IsTrue(result_user);
        }


        




    }
}
