﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Models
{
    public class PostListItem
    {
        public int PostId { get; set; }

        public string Creator { get; set; }
        public string Subject { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
