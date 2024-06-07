

using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : 
        Notifiable,
        IHandler<CreateTodoCommand>
{

    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;        
    }

    public ICommandResult Handle(CreateTodoCommand Command)
    {
        
        throw new NotImplementedException();
    }
}