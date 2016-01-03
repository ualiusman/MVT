using Microsoft.AspNet.Identity.EntityFramework;
using MVT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVT
{

    public class ApplicationUser: IdentityUser
    {
        public ApplicationUser()
        {
            this.IsActive = true;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }
        
        [Required]
        [StringLength(250)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(250)]
        public string LastName { get; set; }
        
        public bool IsActive { get; set; }

    }
    public class MVTContext : IdentityDbContext<ApplicationUser>
    {
        public MVTContext()
            :base("MVTDb")
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Needy> Needy { get; set; }


        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}