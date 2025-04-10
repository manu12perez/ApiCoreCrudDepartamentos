//using ApiCoreCrudDepartamentos.Data;
//using ApiCoreCrudDepartamentos.Repositories;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

///***********************************************************************************************************/
//string connectionString = builder.Configuration.GetConnectionString("SqlAzure");
//builder.Services.AddDbContext<DepartamentosContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddTransient<RepositoryDepartamentos>();
///***********************************************************************************************************/

//builder.Services.AddControllers();
//// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //app.MapOpenApi();
//}
///***********************************************************************************************************/
//app.MapOpenApi();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/openapi/v1.json", "Api Crud Departamentos");
//    options.RoutePrefix = "";
//});
///***********************************************************************************************************/

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


using ApiCoreCrudDepartamentos.Data;
using ApiCoreCrudDepartamentos.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using NSwag.AspNetCore;
using NSwag;
 
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString =
    builder.Configuration.GetConnectionString("SqlAzure");
builder.Services.AddTransient<RepositoryDepartamentos>();
builder.Services.AddDbContext<DepartamentosContext>
    (options => options.UseSqlServer(connectionString));
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument(config =>
{
    config.DocumentName = "v1";
    config.Title = "Api Crud departamentos";
    config.Version = "v1";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction()) // Both environments need Swagger
{
    app.UseOpenApi(); // Serves the OpenAPI document
    app.UseSwaggerUi(); // Optional: Serves Swagger UI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();