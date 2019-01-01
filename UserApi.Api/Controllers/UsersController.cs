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

        public IHttpActionResult GetUser(int id)
        {
            var user = _usersRepository.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
    }
}