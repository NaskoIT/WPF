using System.Threading.Tasks;
using TodoManager.Application.Common.Models;

namespace TodoManager.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<bool> UserExistsByEmailAndPassword(string email, string password);
    }
}
