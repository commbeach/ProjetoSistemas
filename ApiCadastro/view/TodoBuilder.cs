using NSwag.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.models;

namespace TodoApi.view{

    public static class RenderBuilder
    {
        public static void RenderBuild(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<PessoaDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            builder.Services.AddDbContext<EnderecoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddOpenApiDocument(config =>
                {
                    config.DocumentName = "TodoAPI";
                    config.Title = "TodoAPI v1";
                    config.Version = "v1";
                });


        }
    }


}