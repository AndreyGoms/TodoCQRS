

using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
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

    public ICommandResult Handle(CreateTodoCommand command)
    {
        //Fail fast validation
        command.Validate();

        if(command.Invalid)
          return new GenericCommandResult(false, "Oops, parece ue sua tarefa esta errada", command.Notifications);    
        
        // Gera o todo Item
        var todo = new TodoItem(command.Title, command.User, command.Date);

        // Salvar no banco
        _repository.Create(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa Salva!", todo);       
                
    }
}