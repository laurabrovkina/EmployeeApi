using Employee.Common.Dtos.Address;
using Employee.Common.Dtos.Job;
using Employee.Common.Dtos.Teams;

namespace Employee.Common.Dtos.Employee;

//todo: add teams
public record EmployeeDetails(int Id, string FirstName, string LastName, AddressGet AddressGet, JobGet Job/*, List<TeamGet> Teams*/);