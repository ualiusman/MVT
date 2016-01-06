using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
            InitilizeRolesAndUsers(context);
            InitilizeData( context);
        }

        #region Roles and Users
        public static void InitilizeRolesAndUsers(MVTContext context)
        {
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            CreateRole(RoleManager, "Admin");
            CreateRole(RoleManager, "Contributor");

            var user = new ApplicationUser();
            user.UserName = "admin";
            user.FirstName = "Admin";
            user.LastName = "Admin";
            user.Email = "admin@mwt.com";
            user.PhoneNumber = "83738373837";
            var result = UserManager.Create(user, "moftak");
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Admin");
            }

            user = new ApplicationUser();
            user.UserName = "Usman";
            user.FirstName = "Usman";
            user.LastName = "Ali";
            user.Email = "usman@mwt.com";
            user.PhoneNumber = "83738373837";
            result = UserManager.Create(user, "moftak");
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Contributor");
            }

            user = new ApplicationUser();
            user.UserName = "Usman";
            user.FirstName = "Usman";
            user.LastName = "Ali";
            user.Email = "usman@mwt.com";
            user.PhoneNumber = "83738373837";
            result = UserManager.Create(user, "moftak");
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Contributor");
            }

            user = new ApplicationUser();
            user.UserName = "nouman";
            user.FirstName = "Nouman";
            user.LastName = "Nouman";
            user.Email = "nouman@mwt.com";
            user.PhoneNumber = "83738373837";
            result = UserManager.Create(user, "moftak");
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Admin");
            }

            user = new ApplicationUser();
            user.UserName = "farrukh";
            user.FirstName = "Farrukh";
            user.LastName = "Farrukh";
            user.Email = "farrukh@mwt.com";
            user.PhoneNumber = "83738373837";
            result = UserManager.Create(user, "moftak");
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Admin");
            }

            user = new ApplicationUser();
            user.UserName = "contriutor";
            user.FirstName = "Contributor";
            user.LastName = "Contributor";
            user.Email = "contribtor@mwt.com";
            user.PhoneNumber = "83738373837";
            result = UserManager.Create(user, "moftak");
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, "Contributor");
            }
        }

        public static void CreateRole(RoleManager<IdentityRole> RoleManager, string role)
        {
            if (!RoleManager.RoleExists(role))
            {
                RoleManager.Create(new IdentityRole(role));
            }
        }
        #endregion
        public static void InitilizeData(MVTContext context)
        {
            Project p = new Project { isActive = true, Description = "Give it to Poors", Name = "Give It" };
            context.Projects.Add(p);

            Needy n = new Needy() { IsActive = true, Location = "XYZ", Name = "Needy Name", PhoneNumber = "37363736" };
            context.Needy.Add(n);

            Contribution contribution = new Contribution { Ammount = 100, Contributor = "contriutor", ProjectId = p.Id };
            context.Contributions.Add(contribution);

            Donation donation = new Donation { NeedyId = n.Id, ProjectId = p.Id, Ammount = 50 };
            context.Donations.Add(donation);
            
            context.SaveChanges();
        }

    }
}