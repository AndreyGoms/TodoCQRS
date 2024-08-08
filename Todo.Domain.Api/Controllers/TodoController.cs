using System;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers;


[ApiController]
[Route("v1/todos")]
public class TodoController : ControllerBase  
{

    [Route("")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAll(ITodoRepository repository) 
    {
        return repository.GetAll("Andrey");
    }

    [Route("Done")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllDone(ITodoRepository repository) 
    {        
        return repository.GetAllDone("Andrey");
    }

    [Route("Undone")]
    [HttpGet]
    public IEnumerable<TodoItem> GetAllUnDone(ITodoRepository repository) 
    {        
        return repository.GetAllUndone("Andrey");
    }

    [Route("done/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForToday(ITodoRepository repository) 
    {        
        return repository.GetByPeriod (
            "Andrey",
            DateTime.Now.Date,
            true
        );
    }
    
    [Route("undone/today")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUnDoneForToday(ITodoRepository repository) 
    {        
        return repository.GetByPeriod (
            "Andrey",
            DateTime.Now.Date,
            false
        );
    }

    [Route("done/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetDoneForTomorrow(ITodoRepository repository) 
    {        
        return repository.GetByPeriod (
            "Andrey",
            DateTime.Now.Date.AddDays(1),
            true
        );
    }

    [Route("undone/tomorrow")]
    [HttpGet]
    public IEnumerable<TodoItem> GetUnDoneForTomorrow(ITodoRepository repository) 
    {        
        return repository.GetByPeriod (
            "Andrey",
            DateTime.Now.Date.AddDays(1),
            false
        );
    }    

    [Route("")]
    [HttpPost]
    public GenericCommandResult Create(CreateTodoCommand command, TodoHandler handler) 
    {
        command.User = "Andrey";
        return (GenericCommandResult) handler.Handle(command);
    }
    
    [Route("")]
    [HttpPut]
    public GenericCommandResult Update(CreateTodoCommand command, TodoHandler handler) 
    {
        command.User = "Andrey";
        return (GenericCommandResult) handler.Handle(command);
    }

    //[Route("mark-as-done")]
    [HttpPut("mark-as-done")]
    public GenericCommandResult MarkAsDone(MarkTodoAsDoneCommand command, TodoHandler handler) 
    {
        command.User = "Andrey";
        return (GenericCommandResult) handler.Handle(command);
    }
}