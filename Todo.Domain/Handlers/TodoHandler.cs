

using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : 
        Notifiable,
        IHandler<CreateTodoCommand>,
        IHandler<UpdateTodoCommand>,
        IHandler<MarkTodoAsDoneCommand>,
        IHandler<MarkTodoAsUndone>
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

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        //Fail fast validation
        command.Validate();

        if(command.Invalid)
          return new GenericCommandResult(false, "Oops, parece ue sua tarefa esta errada", command.Notifications);    
        
        // Recupera o todo Item (rehidratacao, nunca confia nas infos que estao em tela, sempre pegar o valor mais att)
        var todo = _repository.GetById(command.Id, command.User);

        //Altera titulo
        todo.UpdateTitle(command.Title);

        // Salvar no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa Salva!", todo);       
                
    }
    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        //Fail fast validation
        command.Validate();

        if(command.Invalid)
          return new GenericCommandResult(false, "Oops, parece ue sua tarefa esta errada", command.Notifications);    
        
        // Recupera o todo Item (rehidratacao, nunca confia nas infos que estao em tela, sempre pegar o valor mais att)
        var todo = _repository.GetById(command.Id, command.User);

        //Mark is done
        todo.MarkAsDone();

        // Salvar no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa Salva!", todo);       
                
    }
    public ICommandResult Handle(MarkTodoAsUndone command)
    {
        //Fail fast validation
        command.Validate();

        if(command.Invalid)
          return new GenericCommandResult(false, "Oops, parece ue sua tarefa esta errada", command.Notifications);    
        
        // Recupera o todo Item (rehidratacao, nunca confia nas infos que estao em tela, sempre pegar o valor mais att)
        var todo = _repository.GetById(command.Id, command.User);

        //Mark is Undone 
        todo.MarkAsUndone();

        // Salvar no banco
        _repository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa Salva!", todo);       
                
    }

    
}