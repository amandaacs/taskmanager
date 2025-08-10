using System;
using TaskManager.TaskManager.Application.DTOs;
using TaskManager.TaskManager.Domain.Entities;

namespace TaskManager.TaskManager.Application.Interfaces;

public interface ITodoRepository
{
    public Task<IEnumerable<Todo>> GetAllTodosAsync();
    public Task<Todo?> GetByIdAsync(int id);
    public Task AddTodoAsync(Todo todo);
    public Task<TodoResponse> UpdateTodoAsync(Todo todo);
    public Task DeleteTodoAsync(int id);

}
