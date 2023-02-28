using Bookish.DataAccess.Entities;

namespace Bookish.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetById(string id);
        public void Add(User user);
    }
}
