using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        [ForeignKey("Profile")]
        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "May not exceed 200 characters.")]
        public string Message { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
