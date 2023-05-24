using EmployeeApi.Common.Dtos.Employee;

namespace EmployeeApi.Common.Dtos.Teams;

public record TeamGet(int Id, string Name, List<EmployeeList> Employees);