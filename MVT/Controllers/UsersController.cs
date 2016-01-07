using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVT.Controllers
{
    [RoutePrefix("api/Users")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ApiController
    {
       

        [Route("")]
        public IHttpActionResult Get()
        {
            MVTContext ctx = new MVTContext();
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));

            List<UserModel> userList = (from users in UserManager.Users select new MVT.Models.UserModel 
            {   UserName = users.UserName,
                Id = users.Id,
                UserId = users.UserID,
                Email = users.Email,
                PhoneNumber = users.PhoneNumber,
                FirstName = users.FirstName,
                LastName = users.LastName,
            }).ToList();
            return Ok(userList);
        }
    }
}
