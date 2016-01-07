using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVT.Models
{
    public class Donation
    {
        public Donation()
        {
            this.IsActive = true;
            this.Date = DateTime.Now;
        }


        [Key]
        public long DonationId { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [Required]
        public long NeedyId { get; set; }

        [Required]
        public int Ammount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("NeedyId")]
        public virtual Needy Needy { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }

    public class DonationModel
    {
        [Key]
        public long DonationId { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [Required]
        public long NeedyId { get; set; }

        [Required]
        public int Ammount { get; set; }

        public string ProjectName { get; set; }

        public string NeedyName { get; set; }

        public DateTime Date { get; set; }


    }
}