using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Models
{
    public class PostDetail
    {
        public int PostId { get; set; }


        [Display(Name = "Posted By")]
        public string Creator { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset PostDate { get; set; }
    }
}
