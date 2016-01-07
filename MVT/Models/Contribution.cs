using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVT.Models
{
    public class Contribution
    {
        public Contribution()
        {
            this.IsActive = true;
            this.Date = DateTime.Now;
        }

        [Key]
        public long ContributionId{get;set;}

        [Required]
        public string Contributor { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [Required]
        public int Ammount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
    }

    public class ContributionModel
    {
        [Key]
        public long ContributionId { get; set; }

        [Required]
        public string Contributor { get; set; }

        [Required]
        public long ProjectId { get; set; }

        [Required]
        public int Ammount { get; set; }

        public string ProjectName { get; set; }

        public string ContributorName { get; set; }

        public DateTime Date { get; set; }

    }
}