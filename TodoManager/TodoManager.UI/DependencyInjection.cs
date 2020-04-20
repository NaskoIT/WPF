using Microsoft.Extensions.DependencyInjection;
using System;
using TodoManager.Application;
using TodoManager.Infrastructure;
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

            services.AddApplication();
            services.AddInfrastructure();
            services.AddViewModels();

            container = services.BuildServiceProvider();
        }

        private static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<CreateTodoListViewModel>();

            return services;
        }
    }
}
