using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Models
{
    public class CommentCreate
    {
        public int? ProfileId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "May not exceed 200 characters.")]
        public string Message { get; set; }
    }
}
