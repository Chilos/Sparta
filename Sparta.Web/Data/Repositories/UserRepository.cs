﻿using Sparta.Web.Data.Abstract;
using Sparta.Web.Model;

namespace Sparta.Web.Data.Repositories
{


    public class UserRepository : EntityBaseRepository<User>, IUserRepository
    {
        public UserRepository(SpartaContext context) : base(context) { }

        public bool IsPhoneNumberUniq(string phoneNumber)
        {
            var user = this.GetSingle(u => u.PhoneNumber == phoneNumber);
            return user == null;
        }

        public bool IsUsernameUniq(string username)
        {
            var user = this.GetSingle(u => u.Username == username);
            return user == null;
        }
    }
}
