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
    }
}