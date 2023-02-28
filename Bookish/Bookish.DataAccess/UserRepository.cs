using Bookish.DataAccess.Entities;
using Bookish.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users;

        public UserRepository()
        {
            _users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "flavia.bidihon@gmail.com",
                    Password = "parola",
                    DisplayName= "FlaviaB",
                }
            };
        }

        public List<User> GetAll()
        {
            return _users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetById(string id)
        {
            return _users.FirstOrDefault(u => u.Id.ToString().ToLower() == id);
        }
    }
}
