using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TodoManager.Application.Common.Interfaces;
using TodoManager.Application.Common.Models;
using TodoManager.Domain.Entities;

namespace TodoManager.Infrastructure
{
    public class IdentityService : IIdentityService
    {
        private readonly IApplicationDbContext context;
        private readonly IHashService hashService;

        public IdentityService(IApplicationDbContext context, IHashService hashService)
        {
            this.context = context;
            this.hashService = hashService;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            User user = new User
            {
                Email = userName,
                PasswordHash = hashService.HashPassword(password)
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return (Result.Success(), user.Id);
        }

        public async Task<string> GetUserNameAsync(string userId) => 
            await context.Users
                .Where(u => u.Id == userId)
                .Select(u => u.Email)
                .FirstOrDefaultAsync();

        public async Task<bool> UserExistsByEmailAndPassword(string email, string password)
        {
            string hash = hashService.HashPassword(password);
            return await context.Users
                .AnyAsync(u => u.Email == email && u.PasswordHash == hash);
        }
    }
}
