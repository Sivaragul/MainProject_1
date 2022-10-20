using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MainProject1.Models
{
    public class LapModel
    {

        [Required()]
        public int lapid
        {
            get;
            set;
        }
        [MaxLength(20, ErrorMessage = "Maximum 20 characters")]
        public string lapname
        {
            get;
            set;
        }
    }
}