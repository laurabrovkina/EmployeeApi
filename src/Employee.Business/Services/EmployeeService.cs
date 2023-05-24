using AutoMapper;
using EmployeeApi.Common.Dtos.Employee;
using EmployeeApi.Common.Interfaces;
using EmployeeApi.Common.Model;
using System.Linq.Expressions;

namespace EmployeeApi.Business.Services;

public class EmployeeService : IEmployeeService
{
    private IGenericRepository<Employee> EmployeeRepository { get; }
    public IGenericRepository<Job> JobRepository { get; }
    public IGenericRepository<Address> AddressRepository { get; }
    public IMapper Mapper { get; }

    public EmployeeService(IGenericRepository<Employee> employeeRepository,
        IGenericRepository<Job> jobRepository,
        IGenericRepository<Address> addressRepository,
        IMapper mapper)
    {
        EmployeeRepository = employeeRepository;
        JobRepository = jobRepository;
        AddressRepository = addressRepository;
        Mapper = mapper;
    }

    public async Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate)
    {
        var address = await AddressRepository.GetByIdAsync(employeeCreate.AddressId);
        var job = await JobRepository.GetByIdAsync(employeeCreate.JobId);
        var entity = Mapper.Map<Employee>(employeeCreate);
        entity.Address = address;
        entity.Job = job;
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
        Expression<Func<Employee, bool>> firstNameFilter = (employee) => employeeFilter.FirstName == null ? true :
        employee.FirstName.StartsWith(employeeFilter.FirstName);
        Expression<Func<Employee, bool>> lastNameFilter = (employee) => employeeFilter.LastName == null ? true :
        employee.LastName.StartsWith(employeeFilter.LastName);
        Expression<Func<Employee, bool>> jobFilter = (employee) => employeeFilter.Job == null ? true :
        employee.Job.Name.StartsWith(employeeFilter.Job);
        Expression<Func<Employee, bool>> teamFilter = (employee) => employeeFilter.Team == null ? true :
        employee.Teams.Any(team => team.Name.StartsWith(employeeFilter.Team));

        var entities = await EmployeeRepository.GetFilteredAsync(new Expression<Func<Employee, bool>>[]
        {
            firstNameFilter, lastNameFilter, jobFilter, teamFilter
        }, employeeFilter.Skip, employeeFilter.Take, 
        (employee) => employee.Address, (employee) => employee.Job, (employee) => employee.Teams);

        return Mapper.Map<List<EmployeeList>>(entities);
    }

    public async Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdate)
    {
        var address = await AddressRepository.GetByIdAsync(employeeUpdate.AddressId);
        var job = await JobRepository.GetByIdAsync(employeeUpdate.JobId);
        var entity = Mapper.Map<Employee>(employeeUpdate);
        entity.Address = address;
        entity.Job = job;
        EmployeeRepository.Update(entity);
        await EmployeeRepository.SaveChangesAsync();
    }
}
