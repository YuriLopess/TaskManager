using src.Services.Task;
using src.Services.User;
using src.Validators.Response;
using src.Validators.Task;
using src.Validators.User;

namespace src.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomValidators(this IServiceCollection services)
        {
            services.AddScoped<IUserValidator, UserValidator>();
            services.AddScoped<ITaskValidator, TaskValidator>();
            services.AddScoped<IResponseValidator, ResponseValidator>();
            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITaskService, TaskService>();
            return services;
        }
    }

}
