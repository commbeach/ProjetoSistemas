using NSwag.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.models;

namespace TodoApi.controller{

    public static class TodoEndpoints
    {
        public static void ParaEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/todoitems", async (TodoDb db) =>
                await db.Todos.ToListAsync());

            builder.MapGet("/todoitems/complete", async (TodoDb db) =>
                await db.Todos.Where(t => t.IsComplete).ToListAsync());

            builder.MapGet("/todoitems/{id}", async (int id, TodoDb db) =>
                await db.Todos.FindAsync(id) is Todo todo
                    ? Results.Ok(todo)
                    : Results.NotFound());

            builder.MapPost("/todoitems", async (Todo todo, TodoDb db) =>
            {
                db.Todos.Add(todo);
                await db.SaveChangesAsync();
                return Results.Created($"/todoitems/{todo.Id}", todo);
            });

            builder.MapPut("/todoitems/{id}", async (int id, Todo inputTodo, TodoDb db) =>
            {
                var todo = await db.Todos.FindAsync(id);
                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            builder.MapDelete("/todoitems/{id}", async (int id, TodoDb db) =>
            {
                if (await db.Todos.FindAsync(id) is Todo todo)
                {
                    db.Todos.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });
        }
    }


}