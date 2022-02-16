using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }

        [Display(Name = "Posted By")]
        public string Creator { get; set; }
        public string Message { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
