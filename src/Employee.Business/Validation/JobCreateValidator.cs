using EmployeeApi.Common.Dtos.Job;
using FluentValidation;

namespace EmployeeApi.Business.Validation;

public class JobCreateValidator : AbstractValidator<JobCreate>
{
    public JobCreateValidator()
    {
        RuleFor(jobCreate => jobCreate.Name).NotEmpty().MaximumLength(50);
        RuleFor(jobCreate => jobCreate.Description).NotEmpty().MaximumLength(250);
    }
}
