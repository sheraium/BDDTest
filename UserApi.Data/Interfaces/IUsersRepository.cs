using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Entities;

namespace UserApi.Data.Interfaces
{
    public interface IUsersRepository
    {
        User GetById(int id);
        void UpdateById(int id, User user);
        void DeleteById(int id);
        void Add(User user);
    }
}
