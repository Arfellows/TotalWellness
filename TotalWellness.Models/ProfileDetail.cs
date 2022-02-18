﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Models
{
    public class ProfileDetail
    {
        public int ProfileId { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public byte[] FileContent { get; set; }
    }
}
