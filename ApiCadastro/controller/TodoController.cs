using NSwag.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.models;

namespace TodoApi.controller{

    public static class TodoEndpoints
    {
        public static void ParaEndpoints(this IEndpointRouteBuilder builder)
        {
            builder.MapGet("/pessoas", async (PessoaDb db) =>
            {
                var pessoas = await db.Pessoas.ToListAsync();
                
                var pessoasComEnderecos = new List<object>();

                foreach (var pessoa in pessoas)
                {
                    var enderecos = await db.Enderecos.Where(e => e.Id_Pessoa == pessoa.Id).ToListAsync();
                    pessoasComEnderecos.Add(new{pessoa,enderecos});
                }

                return Results.Ok(pessoasComEnderecos);
            });

            //builder.MapGet("Pessoas/complete", async (PessoaDb db) =>
                //await db.Todos.Where(t => t.IsComplete).ToListAsync());

            builder.MapGet("/Pessoa/{id}", async (int id, PessoaDb db) =>
                {
                var pessoa = await db.Pessoas.FindAsync(id);
                if (pessoa is null) return Results.NotFound();

                var enderecos = await db.Enderecos.Where(e => e.Id_Pessoa == id).ToListAsync();
                return Results.Ok(new { pessoa, enderecos });
            });

            builder.MapPost("Pessoa", async (Pessoa todo, PessoaDb db) =>
            {
                db.Pessoas.Add(todo);
                await db.SaveChangesAsync();
                return Results.Created($"Pessoa {todo.Id}", todo);
            });

             builder.MapPost("Endereco", async (Endereco end, PessoaDb db) =>
            {
                db.Enderecos.Add(end);
                await db.SaveChangesAsync();
                return Results.Created($"Endereco {end.Id}", end);
            });

            builder.MapPut("Pessoa/{id}", async (int id, Pessoa inputTodo, PessoaDb db) =>
            {
                var todo = await db.Pessoas.FindAsync(id);
                if (todo is null) return Results.NotFound();

                todo.Name = inputTodo.Name;
                todo.IsComplete = inputTodo.IsComplete;
                await db.SaveChangesAsync();
                return Results.NoContent();
            });

            builder.MapDelete("Pessoa/{id}", async (int id, PessoaDb db) =>
            {
                if (await db.Pessoas.FindAsync(id) is Pessoa todo)
                {
                    db.Pessoas.Remove(todo);
                    await db.SaveChangesAsync();
                    return Results.NoContent();
                }

                return Results.NotFound();
            });
        }
    }


}