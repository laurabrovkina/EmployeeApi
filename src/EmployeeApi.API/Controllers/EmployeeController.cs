using EmployeeApi.Common.Dtos.Employee;
using EmployeeApi.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private IEmployeeService EmployeeService { get; }

    public EmployeeController(IEmployeeService employeeService)
    {
        EmployeeService = employeeService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateEmployee(EmployeeCreate employeeCreate)
    {
        var Id = await EmployeeService.CreateEmployeeAsync(employeeCreate);
        return Ok(Id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateEmployee(EmployeeUpdate employeeUpdate)
    {
        await EmployeeService.UpdateEmployeeAsync(employeeUpdate);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteEmployee(EmployeeDelete employeeDelete)
    {
        await EmployeeService.DeleteEmployeeAsync(employeeDelete);
        return Ok();
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employee = await EmployeeService.GetEmployeeAsync(id);
        return Ok(employee);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetEmployees([FromQuery]EmployeeFilter employeeFilter)
    {
        var employees = await EmployeeService.GetEmployeesAsync(employeeFilter);
        return Ok(employees);
    }
}
