using AuthWebApiKios.Context;
using AuthWebApiKios.Helpers;
using AuthWebApiKios.Models;
using AuthWebApiKios.Repository;
using AuthWebApiKios.RequestModels;
using AuthWebApiKios.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AuthWebApiKios.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private UserService _UserService = null;

        public AccountController()
        {
            _UserService = new UserService();
        }


        [Authorize]
        [Route("home")]
        public async Task<IHttpActionResult> home()
        {
            
            return Ok();
        }


        [AllowAnonymous]
        [Route("test")]
        public IHttpActionResult test()
        {
            AuthWebApiKios.RequestModels.UserAuthModel user = new AuthWebApiKios.RequestModels.UserAuthModel
            {
                Password = "eessaouira",
                UserName = "eessaouira"
            };
            var result_user = _UserService.CheckUser(user);

            return Ok(result_user);
        }
        // POST api/Account/Authentification

        [AllowAnonymous]
        [Route("Fotgetpassword")]
        public async Task<IHttpActionResult> Fotgetpassword(ForgetPassword emailReq)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool recover = _UserService.RecoverMyPassword(emailReq.Email);
            if (!recover) return BadRequest("Email address not found or a technical problem, please contact the technical service !!");

            return Ok();
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserInscModel userInsc)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(userInsc.response == null)
                return BadRequest("Captcha invalide !!");



            string EncodedResponse = userInsc.response;
            bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "True" ? true : false);
            if (!IsCaptchaValid)
            {
                return BadRequest("Captcha invalide !!");
            }
            User user = _UserService.getByEmailOrUsername(userInsc.Email, userInsc.UserName);
            if (user != null) return BadRequest("Email Adresse /Username existe already !!");

            _UserService.AddUser(userInsc);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
              //  _repo.Dispose();
            }

            base.Dispose(disposing);
        }

       
    }
}