using Base.Application.Common.Models;
using MediatR;

namespace Base.Application.Features.Todos.Commands.CreateTodo;

public record CreateTodoCommand : IRequest<Result<int>>
{
    public string Title { get; init; }
    public string Description { get; init; }
}

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implement actual database persistence
        var todo = new Domain.Entities.Todo
        {
            Title = request.Title,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow,
            IsCompleted = false
        };

        // Simulating saving to database
        return Result<int>.Success(1);
    }
} 