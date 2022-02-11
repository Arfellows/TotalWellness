using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        
    }
}
