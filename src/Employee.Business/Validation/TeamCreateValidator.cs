using EmployeeApi.Common.Dtos.Teams;
using FluentValidation;

namespace EmployeeApi.Business.Validation;

public class TeamCreateValidator : AbstractValidator<TeamCreate>
{
    public TeamCreateValidator()
    {
        RuleFor(jobCreate => jobCreate.Name).NotEmpty().MaximumLength(50);
    }
}
