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
        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new MVTContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);
            return result;
        }

        public async Task<IdentityUser> FindUser(string username, string password)
        {
            IdentityUser user = await _userManager.FindAsync(username, password);
            return user;
        }

        public List<UserModel> GetAllUsers()
        {
            List<UserModel> models = (from users in _userManager.Users select new MVT.Models.UserModel { UserName = users.UserName}).ToList();
            return models;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }

    }
}