using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string? cnnStr = builder.Configuration.GetConnectionString("DefaultConnection");

//Registra o AppDbContext no cont�iner de servi�os, permitindo o framework gerenciar automaticamente sua cria��o e destrui��o ao longo do ciclo de vida da aplica��o.
builder.Services.AddDbContext<AppDbContext>(x =>
    x.UseSqlServer(cnnStr)
    );

builder.Services.AddEndpointsApiExplorer();
//Swagger ir� usar o nome completo das classes (Namespace.ClassName) como identificador no esquema da API.
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.FullName);
});

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>(); //Sempre cria uma nova instancia da categoria
var app = builder.Build();

//configura o modo como cada requisi��o vai funcionar 
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    options.RoutePrefix = "";  // Isso far� o Swagger UI ser acess�vel na raiz
});

app.MapPost(
    pattern:"/v1/categories",
    handler:async(CreateCategoryRequest request, ICategoryHandler handler) 
    => await handler.CreateAsync(request)) //Retornar sempre JSON
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova categoria")
    .Produces<Response<Category?>>(); 

    app.MapDelete(
    pattern:"/v1/categories/{id}",
    handler:async(long id, ICategoryHandler handler) 
    => 
    { 
        var request = new DeleteCategoryRequest
        {
            Id = id,
            UserId = "teste@gmail.com"
        };
        return await handler.DeleteAsync(request);
        }) //Retornar sempre JSON
    .WithName("Categories: Delete")
    .WithSummary("Exclui uma categoria")
    .Produces<Response<Category>>(); 

    app.MapPut(
    pattern:"/v1/categories/{id}",
    handler:async(long id, UpdateCategoryRequest request, ICategoryHandler handler) 
    => 
    {
        request.Id = id;
        return await handler.UpdateAsync(request);
    }) //Retornar sempre JSON

    .WithName("Categories: Update")
    .WithSummary("Atualiza uma categoria")
    .Produces<Response<Category?>>(); 

    app.MapGet(
    pattern:"/v1/categories",
    handler:async( ICategoryHandler handler) 
    => 
    { 
        var request = new GetAllCategoriesRequest
        {
            UserId = "teste@gmail.com"
        };
        return await handler.GetAllAsync(request);
        }) //Retornar sempre JSON
    .WithName("Categories: Get All")
    .WithSummary("Retorna todas as categorias de um usuário")
    .Produces<PagedResponse<List<Category>?>>(); 

app.MapGet(
    pattern:"/v1/categories/{id}",
    handler:async(long id, ICategoryHandler handler) 
    => 
    { 
        var request = new GetCategoryByIdRequest
        {
            Id = id,
            UserId = "teste@gmail.com"
        };
        return await handler.GetByIdAsync(request);
        }) //Retornar sempre JSON
    .WithName("Categories: Get by Id")
    .WithSummary("Retorna uma categoria")
    .Produces<Response<Category>>(); 

    app.Run();



