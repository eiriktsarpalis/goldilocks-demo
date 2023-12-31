﻿using Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.WriteIndented = true;
});

WebApplication app = builder.Build();

app.MapGet("/todos", () => Todos.GetAllTodos());
app.MapGet("/todos/{id}", (int id) =>
    Todos.GetAllTodos().FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();