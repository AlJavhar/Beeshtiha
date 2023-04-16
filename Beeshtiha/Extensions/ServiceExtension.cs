using beeshtiha.DAL.IRepositories;
using beeshtiha.DAL.Repositories;
using Beeshtiha.Service.Interfaces;
using Beeshtiha.Service.Services;

namespace Beeshtiha.Extensions
{
    public static class ServiceExtension
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDishService, DishService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
