using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sparta.Web.API.ViewModel
{
    public class UserInfo
    {
        public  string Id { get; set; }
        public  string Username { get; set; }
        public string RealName { get; set; }
        public  string PhoneNumber { get; set; }
        public  string Role { get; set; }

        public static UserInfo Factory(string id, string userName, string realName, string phoneNumber, string role)
        {
            return new UserInfo
            {
                Id = id,
                Username = userName,
                RealName = realName,
                PhoneNumber = phoneNumber,
                Role = role
            };
        }
    }
}
