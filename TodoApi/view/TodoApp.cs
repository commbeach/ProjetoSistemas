using NSwag.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TodoApi.models;

namespace TodoApi.view{

    public static class RendeApp
    {
        public static void RenderMenu(this WebApplication builder)
        {
           if (builder.Environment.IsDevelopment())
                {
                    builder.UseOpenApi();
                    builder.UseSwaggerUi(config =>
                    {
                        config.DocumentTitle = "TodoAPI";
                        config.Path = "/swagger";
                        config.DocumentPath = "/swagger/{documentName}/swagger.json";
                        config.DocExpansion = "list";
                    });
                }

        }
    }


}