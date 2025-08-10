using System;
using TaskManager.TaskManager.Application.Interfaces;

namespace TaskManager.TaskManager.Application.UseCases;

public class DeleteTodo
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodo(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async void ExecuteAsync(int id)
    {
        var todo = await _todoRepository.GetByIdAsync(id);
        if (todo == null)
        {
            throw new KeyNotFoundException("Tarefa não encontrada");
        }
        _todoRepository.DeleteTodoAsync(id);
    }
}
