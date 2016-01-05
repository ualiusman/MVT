using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVT.Models
{
    public class Needy
    {
        public Needy()
        {
            this.IsActive = true;
        }
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<Donation> Donations { get; set; }
    }

    public class NeedyModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}