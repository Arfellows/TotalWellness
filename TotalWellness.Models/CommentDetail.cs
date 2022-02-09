using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Models
{
    public class CommentDetail
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int ProfileId { get; set; }
        public string Message { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
