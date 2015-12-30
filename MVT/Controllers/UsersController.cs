using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVT.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        
        [Route("")]
        public IHttpActionResult Get()
        {
            AuthRepository rep = new AuthRepository();
            return Ok(rep.GetAllUsers());
            
        }
    }

    public class User
    {
        public long UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Boolean IsActive { get; set; }

        public static List<User> GetUsers()
        {
            List<User> userList = new List<User> 
            {
                new User {UserID = 10248, FirstName = "Ali", LastName = "Raza", Email = "mail@mail.com", IsActive = true },
                new User {UserID = 10249, FirstName = "Ali1",LastName = "Raza1", Email = "mail@mail.com", IsActive = false},
                new User {UserID = 10250,FirstName = "Ali2", LastName = "Raza2", Email = "mail@mail.com", IsActive = false },
                new User {UserID = 10251,FirstName = "ALi3", LastName = "Raza3", Email = "mail@mail.com", IsActive = false},
                new User {UserID = 10252,FirstName = "ali5", LastName = "Raza5", Email = "mail@mail.com", IsActive = true}
            };

            return userList;
        }
    }
}
