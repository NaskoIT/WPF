using System;
using TodoManager.Application.Common.Interfaces;

namespace TodoManager.Infrastructure.Services
{
    public class ApplicationDateTime : IDateTime
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
