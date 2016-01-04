using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVT;
using System.Threading.Tasks;
using MVT.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVT.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;
        
        [AllowAnonymous]
        [Route("Register")]
        [HttpPost]
        public async Task<IHttpActionResult> Register(SignupModel signupModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo = new AuthRepository();
            IdentityResult result = await _repo.RegisterUser(signupModel);
            IHttpActionResult errorResult = GetErrorResult(result);
            if(errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        [Authorize]
        [Route("Profile/{userName}")]
        [HttpGet]
        public IHttpActionResult Profile(string userName)
        {
             MVTContext ctx = new MVTContext();
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));


            ApplicationUser profile = UserManager.FindByName(userName);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(App.Convert(profile));
        }



        [Authorize]
        [Route("Profile")]
        [HttpPost]
        public IHttpActionResult Profile(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MVTContext ctx = new MVTContext();
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ctx));
            ApplicationUser u = UserManager.FindById(user.Id);
            if (u == null)
                return NotFound();
            u.LastName = user.LastName;
            u.FirstName = user.FirstName;
            u.Email = user.Email;
            u.PhoneNumber = user.PhoneNumber;
            var results = UserManager.Update(u);

            
            if (!results.Succeeded)
                return GetErrorResult(results);
            
            return Ok();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if(_repo != null)
        //    {
        //        _repo.Dispose();
        //    }
        //    base.Dispose();
        //}


        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if(result == null)
            {
                return InternalServerError();
            }

            if(!result.Succeeded)
            {
                if(result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                if(ModelState.IsValid)
                {
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
