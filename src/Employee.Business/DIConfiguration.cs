using EmployeeApi.Business.Services;
using EmployeeApi.Business.Validation;
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
        services.AddScoped<ITeamService, TeamService>();

        services.AddScoped<AddressCreateValidator>();
        services.AddScoped<AddressUpdateValidator>();
        services.AddScoped<EmployeeCreateValidator>();
        services.AddScoped<EmployeeUpdateValidator>();
        services.AddScoped<JobCreateValidator>();
        services.AddScoped<JobUpdateValidator>();
        services.AddScoped<TeamCreateValidator>();
        services.AddScoped<TeamUpdateValidator>();
    }
}
