//using Bookish.Application.Interfaces;
//using Bookish.DataAccess.Entities;
//using Bookish.DataAccess;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Bookish.Application.Models.Users;
//using Bookish.Application.Exceptions;

//namespace Bookish.Application.Services
//{
//    public class UserService : IUserService
//    {
//        private readonly DatabaseContext databaseContext;

//        public UserService(DatabaseContext databaseContext)
//        {
//            this.databaseContext = databaseContext;
//        }

//        public UserResponseModel CreateUser(CreateUserRequestModel model)
//        {
//            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName))
//            {
//                throw new ValidationException("Name cannot be empty.");
//            }

//            var user = new User
//            {
//                Id = Guid.NewGuid(),
//                FirstName = model.FirstName,
//                LastName = model.LastName,
//            };

//            this.databaseContext.Users.Add(user);

//            this.databaseContext.SaveChanges();

//            return UserResponseModel.FromUser(user);
//        }

//        public UserResponseModel UpdateUser(Guid id, UpdateUserRequestModel model)
//        {
//            if (string.IsNullOrEmpty(model.FirstName) || string.IsNullOrEmpty(model.LastName))
//            {
//                throw new ValidationException("Name cannot be empty.");
//            }

//            var user = this.databaseContext.Users.FirstOrDefault(x => x.Id == id);

//            user.FirstName = model.FirstName;
//            user.LastName = user.LastName;

//            return UserResponseModel.FromUser(user);
//        }

//        public void DeleteUser(Guid id)
//        {

//        }
//    }
//}

