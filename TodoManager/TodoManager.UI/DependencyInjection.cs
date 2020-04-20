using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using TodoManager.Common;
using TodoManager.Data;
using TodoManager.Services;
using TodoManager.UI.ViewModels;

namespace TodoManager.UI
{
    public static class DependencyInjection
    {
        private static IServiceProvider container;

        public static T Resolve<T>() => container.GetService<T>();

        public static void Initialize()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(GlobalConstants.ConnectionStrings.Default));

            services.AddTransient<ITodoItemsService, TodoItemsService>();

            container = services.BuildServiceProvider();
        }

        private static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<TodoItemsViewModel>();

            return services;
        }
    }
}
