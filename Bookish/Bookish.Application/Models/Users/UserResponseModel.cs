//using Bookish.Application.Models.Products;
//using Bookish.DataAccess.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bookish.Application.Models.Users
//{
//    public class UserResponseModel
//    {
//        public Guid Id { get; set; }
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public string Email { get; set; }
//        public string PhoneNumber { get; set; }
//        public Guid AddressId { get; set; }
//        public List<Address> Addresses { get; set; }

//        public static UserResponseModel FromUser(User user)
//        {
//            return new UserResponseModel
//            {
//                Id = user.Id,
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Email = user.Email,
//                PhoneNumber = user.PhoneNumber
//            };
//        }
//    }
//}
