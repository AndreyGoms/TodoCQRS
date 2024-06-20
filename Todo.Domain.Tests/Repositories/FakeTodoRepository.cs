using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public void Create(TodoItem todo)
    {
       
    }

    public void Update(TodoItem todo)
    {
       
    }

    public TodoItem GetById(Guid id, string title)
    {
        return new TodoItem("titulo", "novo nome", DateTime.Now);
    }
}
