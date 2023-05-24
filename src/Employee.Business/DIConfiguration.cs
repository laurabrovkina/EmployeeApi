using EmployeeApi.Business.Services;
using EmployeeApi.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeApi.Business;

public class DIConfiguration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IJobService, JobService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
    }
}
