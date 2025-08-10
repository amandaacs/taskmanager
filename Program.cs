using TaskManager.TaskManager.Application.Interfaces;
using TaskManager.TaskManager.Application.UseCases;
using TaskManager.TaskManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITodoRepository, TodoRepository>();

// use cases
builder.Services.AddScoped<CreateTodo>();
builder.Services.AddScoped<ListTodos>();
builder.Services.AddScoped<FindTodoById>();
builder.Services.AddScoped<UpdateTodo>();
builder.Services.AddScoped<DeleteTodo>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

