using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MVT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVT
{
    public class AuthRepository:IDisposable
    {
        private MVTContext _ctx;
        private UserManager<ApplicationUser> _userManager;

        public AuthRepository()
        {
            _ctx = new MVTContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(SignupModel signupModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = signupModel.UserName,
                FirstName = signupModel.FirstName,
                LastName = signupModel.LastName,
                Email = signupModel.Email,
                PhoneNumber = signupModel.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, signupModel.Password);
            if (result.Succeeded)
            {
                _userManager.AddToRole(user.Id, "Contributor");
            }
            return result;
        }

        public async Task<ApplicationUser> FindUser(string username, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(username, password);
            return user;
        }

        public async Task<IList<string>> GetRoles(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user.Id);
        }

        public string GetName(string username)
        {
            string name = string.Empty;
            var user = _userManager.FindByName(username);
            if(user != null)
            {
                name = user.FirstName + " " + user.LastName;
            }
            return name;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }

    }
}