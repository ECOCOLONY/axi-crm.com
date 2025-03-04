using Base.Application.Common.Interfaces;
using Base.Application.Common.Models;
using Base.Domain.Entities;
using MediatR;

namespace Base.Application.Features.Employees.Commands.CreateEmployee;

public record CreateEmployeeCommand : IRequest<Result<int>>
{
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public string PhoneNumber { get; init; }
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<int>>
{
    private readonly IApplicationDbContext _context;

    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<int>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Employee
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
            PhoneNumber = request.PhoneNumber
        };

        await _context.Personels.AddAsync(employee, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<int>.Success(employee.Id);
    }
} 