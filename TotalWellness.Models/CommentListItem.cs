using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Models
{
    public class CommentListItem
    {
        public int CommentId { get; set; }

        public int? ProfileId { get; set; }

        public string Message { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
