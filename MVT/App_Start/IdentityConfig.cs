using MVT;
using MVT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVT
{
    public class ApplicationDbInitializer
        : DropCreateDatabaseIfModelChanges<MVTContext>
    {
        protected override void Seed(MVTContext context)
        {
            InitializeIdentityForEF(context);
            base.Seed(context);
        }

        public static void InitializeIdentityForEF(MVTContext context)
        {
            InitilizeProjects( context);
        }

        public static void InitilizeProjects(MVTContext context)
        {
            Project p = new Project { isActive = true, Description = "First Prject For Mofak Welfare Trust", Name = "Project M" };
            context.Projects.Add(p);
            context.SaveChanges();
        }
    }
}