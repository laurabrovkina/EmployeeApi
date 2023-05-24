using EmployeeApi.Common.Dtos.Address;
using EmployeeApi.Common.Dtos.Job;
using EmployeeApi.Common.Dtos.Teams;

namespace EmployeeApi.Common.Dtos.Employee;

//todo: add teams
public record EmployeeDetails(int Id, string FirstName, string LastName, AddressGet Address, JobGet Job/*, List<TeamGet> Teams*/);