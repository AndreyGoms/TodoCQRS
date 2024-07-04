using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;


[TestClass]
public class TodoQueriesTest 
{    
    private List<TodoItem> _items;

    public TodoQueriesTest()
    {
        _items = new();
        _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "Joao", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "Joao", DateTime.Now));
    }

    [TestMethod]
    public void Dada_a_consulta_deve_retornar_tarefas_apenas_do_user_Joao() 
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("Joao"));
        Assert.AreEqual(2, result.Count());       
    }
}