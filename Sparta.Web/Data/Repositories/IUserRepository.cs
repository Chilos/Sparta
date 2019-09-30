using Sparta.Web.Data.Abstract;
using Sparta.Web.Model;

namespace Sparta.Web.Data.Repositories
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsPhoneNumberUniq(int phoneNumber);
        bool IsUsernameUniq(string username);
    }
}