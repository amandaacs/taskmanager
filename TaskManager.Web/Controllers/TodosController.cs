using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.TaskManager.Application.DTOs;
using TaskManager.TaskManager.Application.Interfaces;
using TaskManager.TaskManager.Application.UseCases;
using TaskManager.TaskManager.Domain.Entities;

namespace TaskManager.TaskManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ListTodos _listTodos;
        private readonly FindTodoById _findTodoById;
        private readonly CreateTodo _createTodo;
        private readonly UpdateTodo _updateTodo;
        private readonly DeleteTodo _deleteTodo;
        public TodosController(
            ListTodos listTodos,
            FindTodoById findTodoById,
            CreateTodo createTodo,
            UpdateTodo updateTodo,
            DeleteTodo deleteTodo)
        {
            _listTodos = listTodos;
            _findTodoById = findTodoById;
            _createTodo = createTodo;
            _updateTodo = updateTodo;
            _deleteTodo = deleteTodo;
        }

        // GET /api/todos
        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var result = await _listTodos.ExecuteAsync();
            return Ok(result);
        }

        // GET /api/todos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(int id)
        {
            var result = await _findTodoById.ExecuteAsync(id);
            return Ok(result);
        }

        // POST /api/todos
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] CreateTodoRequest request)
        {
            var result = await _createTodo.ExecuteAsync(request);
            return CreatedAtAction(nameof(GetTodoById), new { id = result.Id }, result);
        }

        // PUT /api/todos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] UpdateTodoRequest request)
        {
            var result = await _updateTodo.ExecuteAsync(id, request);
            return Ok(result);
        }

        // DELETE /api/todos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            await _deleteTodo.ExecuteAsync(id);
            return NoContent();
        }
    }
}
