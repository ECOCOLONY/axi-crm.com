using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Employee> Personels { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
} 