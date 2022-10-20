using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainProject1.Models
{
    public class LoginModel
    {
        [Required()]
        public int custid
        {
            get;
            set;
        }
        [MaxLength(20, ErrorMessage = "Max words should be 20")]
        public string custname
        {
            get;
            set;
        }

    }
}