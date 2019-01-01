using System.Web.Http;
using UserApi.Data.Interfaces;
using UserApi.Entities;

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

        public IHttpActionResult UpdateUser(int id, string name, string surname, string email)
        {
            var user = new User() { Id = id, Name = name, Surname = surname, Email = email };
            _usersRepository.UpdateById(id, user);
            return Ok();
        }
    }

}