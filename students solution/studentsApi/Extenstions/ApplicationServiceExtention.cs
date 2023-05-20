using students_Api.Helpers;

namespace students_Api.Extenstions
{
    public static class ApplicationServiceExtention
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(option => option.
                    UseSqlServer(config.GetConnectionString("DefaultConnection")));

            //UnitOfWork Sericve
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            //AutoMapperProfiles Service
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            return services;
        }
    }
}
