using System;
using TaskManager.TaskManager.Application.DTOs;
using TaskManager.TaskManager.Application.Interfaces;
using TaskManager.TaskManager.Domain.Entities;

namespace TaskManager.TaskManager.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{

    private readonly List<Todo> _todos = new();
    public Task AddTodoAsync(Todo todo)
    {
        _todos.Add(todo);
        return Task.CompletedTask;
    }

    public void DeleteTodoAsync(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            _todos.Remove(todo);
        }
    }

    public Task<IEnumerable<Todo>> GetAllTodosAsync()
    {
        IEnumerable<Todo> todos = _todos;
        return Task.FromResult(todos);
    }

    public Task<Todo?> GetByIdAsync(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(todo);
    }

    public Task<TodoResponse> UpdateTodoAsync(Todo todo)
    {
        var existing = _todos.FirstOrDefault(t => t.Id == todo.Id);
        if (existing != null)
        {
            existing.Title = todo.Title;
            existing.Description = todo.Description;
            existing.ExpirationDate = todo.ExpirationDate;
            existing.Status = todo.Status;
        }

        var response = new TodoResponse
        {
            Id = existing.Id,
            Title = existing.Title,
            Description = existing.Description,
            ExpirationDate = existing.ExpirationDate,
            Status = existing.Status
        };
        
        return Task.FromResult(response);
    }
}
