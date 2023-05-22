using AutoMapper;
using Employee.Common.Dtos.Employee;
using Employee.Common.Interfaces;
using System.Linq.Expressions;

namespace Employee.Business.Services;

public class EmployeeService : IEmployeeService
{
    private IGenericRepository<Common.Model.Employee> EmployeeRepository { get; }
    public IMapper Mapper { get; }

    public EmployeeService(IGenericRepository<Common.Model.Employee> employeeRepository, IMapper mapper)
    {
        EmployeeRepository = employeeRepository;
        Mapper = mapper;
    }

    public async Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate)
    {
        var entity = Mapper.Map<Common.Model.Employee>(employeeCreate);
        await EmployeeRepository.InsertAsync(entity);
        await EmployeeRepository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteEmployeeAsync(EmployeeDelete employeeDelete)
    {
        var entity = await EmployeeRepository.GetByIdAsync(employeeDelete.Id);
        EmployeeRepository.Delete(entity);
        await EmployeeRepository.SaveChangesAsync();
    }

    public async Task<EmployeeDetails> GetEmployeeAsync(int id)
    {
        var entity = await EmployeeRepository.GetByIdAsync(id, (employee) => employee.Address, (employee) => employee.Job, (employee) => employee.Teams);
        return Mapper.Map<EmployeeDetails>(entity);
    }

    public async Task<List<EmployeeList>> GetEmployeesAsync(EmployeeFilter employeeFilter)
    {
        Expression<Func<Common.Model.Employee, bool>> firstNameFilter = (employee) => employeeFilter.FirstName == null ? true :
        employee.FirstName.StartsWith(employeeFilter.FirstName);
        Expression<Func<Common.Model.Employee, bool>> lastNameFilter = (employee) => employeeFilter.LastName == null ? true :
        employee.LastName.StartsWith(employeeFilter.LastName);
        Expression<Func<Common.Model.Employee, bool>> jobFilter = (employee) => employeeFilter.Job == null ? true :
        employee.Job.Name.StartsWith(employeeFilter.Job);
        Expression<Func<Common.Model.Employee, bool>> teamFilter = (employee) => employeeFilter.Team == null ? true :
        employee.Teams.Any(team => team.Name.StartsWith(employeeFilter.Team));

        var entities = await EmployeeRepository.GetFilteredAsync(new Expression<Func<Common.Model.Employee, bool>>[]
        {
            firstNameFilter, lastNameFilter, jobFilter, teamFilter
        }, employeeFilter.Skip, employeeFilter.Take, 
        (employee) => employee.Address, (employee) => employee.Job, (employee) => employee.Teams);

        return Mapper.Map<List<EmployeeList>>(entities);
    }

    public async Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdate)
    {
        var entity = Mapper.Map<Common.Model.Employee>(employeeUpdate);
        EmployeeRepository.Update(entity);
        await EmployeeRepository.SaveChangesAsync();
    }
}
