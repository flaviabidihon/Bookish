using Bookish.Application.Interfaces;
using Bookish.DataAccess;
using Bookish.DataAccess.Entities;
using Bookish.DataAccess.Interfaces;

namespace Bookish.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(string id)
        {
            return _userRepository.GetById(id);
        }
    }
}
