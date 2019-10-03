using Sparta.Web.Model;

namespace Sparta.Web.Data.Abstract
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsPhoneNumberUniq(int phoneNumber);
        bool IsUsernameUniq(string username);
    }
}