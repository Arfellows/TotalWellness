using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalWellness.Data
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

    }
}
