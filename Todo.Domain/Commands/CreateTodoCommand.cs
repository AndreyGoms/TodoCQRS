//lembrando que o command representa uma acao e nesta estamos representando o ato de criar 
using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class CreateTodoCommand : Notifiable, ICommand 
{
    public CreateTodoCommand() { }

    public CreateTodoCommand(string title, DateTime date, string user)
    {
        Title = title;
        Date = date;
        User = user;
    }

    public string Title { get; set; }        
    public DateTime Date { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        //requer, com o requires, que tenha no minimo de caracteres, com HasMinLen, de pelo menos 3 pro Title e 6 pro user
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLen(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                .HasMinLen(User, 6, "User", "Usuario invalido!")
        );
    }
}


    /*
    Estamos na acao de criar um todo item logo para o objeto precisamos como parametro os mesmos campos title, date e user
    esse command vai ser usado tambem na api para receber os dados, ou seja, como as DTOs.
    **nao havera nenhuma regra de negocio aqui, apenas algumas validacoes**
    */

    /* obs:
    oque acontece ao usar o throw new Exception() no servidor IIS ? Ele salva isso no event view do windows
    podendo inflar o disco alem das acoes de IO, input e output */