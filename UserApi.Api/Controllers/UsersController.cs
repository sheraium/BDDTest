using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserApi.Data.Interfaces;

namespace UserApi.Api.Controllers
{
    public class UsersController : ApiController
    {
        private IUsersRepository _usersRepository = null;

        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository; 
        }
    }
}
