using EmployeeApi.Common.Dtos.Job;
using FluentValidation;

namespace EmployeeApi.Business.Validation;

public class JobUpdateValidator : AbstractValidator<JobUpdate>
{
    public JobUpdateValidator()
    {
        RuleFor(jobUpdate => jobUpdate.Name).NotEmpty().MaximumLength(50);
        RuleFor(jobUpdate => jobUpdate.Description).NotEmpty().MaximumLength(250);
    }
}
