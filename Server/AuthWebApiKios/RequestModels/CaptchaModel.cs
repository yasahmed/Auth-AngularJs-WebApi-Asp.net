using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthWebApiKios.RequestModels
{
    public class CaptchaModel
    {
        [Required]
        [Display(Name = "secret")]
        public string secret { get; set; }


        [Required]
        [Display(Name = "response")]
        public string response { get; set; }

    }
}