using EmployeeApi.Common.Dtos.Employee;

namespace EmployeeApi.Common.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate);
        Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdater);
        Task<List<EmployeeList>> GetEmployeesAsync(EmployeeFilter employeeFilter);
        Task<EmployeeDetails> GetEmployeeAsync(int id);
        Task DeleteEmployeeAsync(EmployeeDelete employeeDelete);
    }
}
