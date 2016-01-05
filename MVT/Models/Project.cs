using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVT.Models
{
    public class Project
    {
        public Project() 
        { 
            this.isActive = true; 
        }


        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public bool isActive { get; set; }

        public virtual ICollection<Contribution> Contributions { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
    }


    public class ProjectModel
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}