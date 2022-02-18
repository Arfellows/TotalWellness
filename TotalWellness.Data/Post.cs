using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [ForeignKey("Profile")]
        public int? ProfileId { get; set; }            //required in post create model
        public virtual Profile Profile { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "May not exceed 25 characters.")]
        public string Subject { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "May not exceed 500 characters.")]
        public string Message { get; set; }

        
        public DateTimeOffset Date { get; set; }
    }
}
