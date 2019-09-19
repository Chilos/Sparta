using Sparta.Web.Data.Abstract;
using Sparta.Web.Model;

namespace Sparta.Web.Data.Repositories
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsEmailUniq(string email);
        bool IsUsernameUniq(string username);
    }
}