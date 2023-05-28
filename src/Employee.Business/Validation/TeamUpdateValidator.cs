using EmployeeApi.Common.Dtos.Teams;
using FluentValidation;

namespace EmployeeApi.Business.Validation;

public class TeamUpdateValidator : AbstractValidator<TeamUpdate>
{
    public TeamUpdateValidator()
    {
        RuleFor(jobUpdate => jobUpdate.Name).NotEmpty().MaximumLength(50);
    }
}
