using Microsoft.AspNet.Identity.EntityFramework;
using MVT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVT
{
    public class MVTContext:IdentityDbContext<IdentityUser>
    {
        public MVTContext()
            :base("MVTDb")
        {

        }

        public DbSet<Project> Projects { get; set; }


        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}