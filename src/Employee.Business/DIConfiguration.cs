using Employee.Business.Services;
using Employee.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Business;

public class DIConfiguration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IJobService, JobService>();
    }
}
