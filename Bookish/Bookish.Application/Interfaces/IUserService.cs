using Bookish.DataAccess.Entities;

namespace Bookish.Application.Interfaces
{
    public interface IUserService
    {
        List<User> GetAll();

        User GetById(string id);
    }
}
