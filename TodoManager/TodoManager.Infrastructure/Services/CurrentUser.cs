using TodoManager.Application.Common.Interfaces;

namespace TodoManager.Infrastructure.Services
{
    public class CurrentUser : ICurrentUserService
    {
        public string UserId { get; set; }
    }
}
