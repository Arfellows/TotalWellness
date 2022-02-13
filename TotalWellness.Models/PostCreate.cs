using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Models
{
    public class PostCreate
    {
        //public int? ProfileId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "May not exceed 25 characters.")]
        public string Subject { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "May not exceed 500 characters.")]
        public string Message { get; set; }

    }
}
