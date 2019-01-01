using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Data.Interfaces;
using UserApi.Entities;

namespace UserApi.Data.Repositories
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        private List<User> _users;
        public InMemoryUsersRepository()
        {
            _users = new List<User>();
        }
        public void DeleteById(int id)
        {
            _users.RemoveAll(u => u.Id == id);
        }

        public User GetById(int id)
        {
            return _users.Where(u => u.Id == id).FirstOrDefault();
        }

        public void UpdateById(int id, User user)
        {
            _users.RemoveAll(u => u.Id == id);
            _users.Add(user);
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
    }
}
