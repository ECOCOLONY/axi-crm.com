using Base.Application.Common.Interfaces;
using Base.Application.Common.Models;
using Base.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Base.Application.Features.Employees.Queries.GetEmployees;

public record GetEmployeesQuery : IRequest<Result<List<Employee>>>;

public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, Result<List<Employee>>>
{
    private readonly IApplicationDbContext _context;

    public GetEmployeesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<List<Employee>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _context.Personels.ToListAsync(cancellationToken);
        return Result<List<Employee>>.Success(employees);
    }
} 