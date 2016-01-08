using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVT.Models
{
    public static class  App
    {
        public static UserModel Convert(ApplicationUser user)
        {
            return new UserModel
            {
                Email = user.Email,
                Id = user.Id,
                UserId = user.UserID,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
        }

        public static ProjectModel Convert(Project project)
        {
            return new ProjectModel
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        public static Project Convert(ProjectModel model)
        {
            return new Project
            {
                 Name = model.Name,
                 Description = model.Description
            };
        }

        public static NeedyModel Convert(Needy needy)
        {
            return new NeedyModel
            {
                 Id = needy.Id,
                 Name= needy.Name,
                 PhoneNumber = needy.PhoneNumber,
                 Location = needy.Location
            };
        }

        public static Needy Convert(NeedyModel model)
        {
            return new Needy
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Location = model.Location
            };
        }

        public static ContributionModel Convert(Contribution contribution)
        {
            return new ContributionModel
            {
                 Ammount = contribution.Ammount,
                 ContributionId = contribution.ContributionId,
                 ProjectId = contribution.ProjectId,
                 Date = contribution.Date,
                 Contributor = contribution.Contributor
            };
        }

        public static Contribution Convert(ContributionModel model)
        {
            return new Contribution
            {
                Ammount = model.Ammount,
                Contributor = model.Contributor,
                ProjectId = model.ProjectId
            };
        }

        public static DonationModel Convert(Donation donation)
        {
            return new DonationModel
            {
                 Ammount = donation.Ammount,
                 Date = donation.Date,
                 DonationId = donation.DonationId,
                 NeedyId = donation.NeedyId,
                 ProjectId = donation.ProjectId,
                  NeedyName=donation.Needy.Name,
                  ProjectName=donation.Project.Name

            };
        }

        public static Donation Convert(DonationModel model)
        {
            return new Donation
            {
                 Ammount = model.Ammount,
                 ProjectId = model.ProjectId,
                 NeedyId = model.NeedyId
            };
        }
    }
}