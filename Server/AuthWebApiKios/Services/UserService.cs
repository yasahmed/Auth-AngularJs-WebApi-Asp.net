using AuthWebApiKios.Helpers;
using AuthWebApiKios.Models;
using AuthWebApiKios.Repository;
using AuthWebApiKios.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthWebApiKios.Services
{
    public class UserService 
    {

        private GenericRepository<User> _UserRepository = null;

        public UserService()
        {
            _UserRepository = new GenericRepository<User>();
        }

        public User CheckUser(UserAuthModel user)
        {
            return _UserRepository.Find(x => x.Username == user.UserName && x.Password == user.Password).FirstOrDefault();
        }

        public void AddUser(UserInscModel userIns)
        {
            _UserRepository.Insert(new User { Email = userIns.Email, Username = userIns.UserName, Password = userIns.Password, DateAdd = DateTime.Now });
            _UserRepository.Save();
        }

        public User getByEmail(string email)
        {
           return _UserRepository.Find(x => x.Email == email).FirstOrDefault();
        }

        public User getByEmailOrUsername(string email, string username)
        {
            return _UserRepository.Find(x => x.Email == email || x.Username == username).FirstOrDefault();
        }


        public List<User> getUserList()
        {
            return _UserRepository.SelectAll().ToList();
        }


        public bool RecoverMyPassword(string email){

            User user = getByEmail(email);
         
          string message = "<head><meta name='viewport' content='width=device-width'><style>*{font-family:'Helvetica Neue',Helvetica,Helvetica,Arial,sans-serif;font-size:100%;line-height:1.6em;margin:0;padding:0}.btn-primary td,h1,h2,h3{font-family:'Helvetica Neue',Helvetica,Arial,'Lucida Grande',sans-serif}img{max-width:600px;width:100%}body{-webkit-font-smoothing:antialiased;height:100%;-webkit-text-size-adjust:none;width:100%!important}a{color:#348eda}.btn-primary{Margin-bottom:10px;width:auto!important}.btn-primary td{background-color:#348eda;border-radius:25px;font-size:14px;text-align:center;vertical-align:top}.btn-primary td a{background-color:#348eda;border:1px solid #348eda;border-radius:25px;border-width:10px 20px;display:inline-block;color:#fff;cursor:pointer;font-weight:700;line-height:2;text-decoration:none}.last{margin-bottom:0}.first{margin-top:0}.padding{padding:10px 0}table.body-wrap{padding:20px;width:100%}table.body-wrap .container{border:1px solid #f0f0f0}table.footer-wrap{clear:both!important;width:100%}.footer-wrap .container p{color:#666;font-size:12px}table.footer-wrap a{color:#999}h1,h2,h3{color:#111;font-weight:200;line-height:1.2em;margin:40px 0 10px}h1{font-size:36px}h2{font-size:28px}h3{font-size:22px}ol,p,ul{font-size:14px;font-weight:400;margin-bottom:10px}ol li,ul li{margin-left:5px;list-style-position:inside}.container{clear:both!important;display:block!important;Margin:0 auto!important;max-width:600px!important}.body-wrap .container{padding:20px}.content{display:block;margin:0 auto;max-width:600px}.content table{width:100%}</style></head><body bgcolor='#f6f6f6'><table class='body-wrap' bgcolor='#f6f6f6'> <tbody><tr> <td></td><td class='container' bgcolor='#FFFFFF'> <div class='content'> <table> <tbody><tr> <td> <p>Hi $$1</p><p>Your currentlu password is</p><table class='btn-primary' cellpadding='0' cellspacing='0' border='0'> <tbody><tr> <td> <a>$$2</a> </td></tr></tbody></table> <p>Thanks, have a lovely day.</p><p><a href=''>Go to Web site</a></p></td></tr></tbody></table> </div></td><td></td></tr></tbody></table><table class='footer-wrap'> <tbody><tr> <td></td><td class='container'> <div class='content'> <table> <tbody><tr> <td align='center'> <p>Do not like these annoying emails? <a href='#'><unsubscribe>Unsubscribe</unsubscribe></a>. </p></td></tr></tbody></table> </div></td><td></td></tr></tbody></table></body>";

            if (user == null) return false;
            message = message.Replace("$$1",user.Username);
            message = message.Replace("$$2", user.Password);


            return SendMail.Send(email, "Recover my password", message);
        }
    }
}