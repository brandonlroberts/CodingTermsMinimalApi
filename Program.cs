using CodingTermsMinimalApi.Dal.Data;
using CodingTermsMinimalApi.Dal.Repositories;
using CodingTermsMinimalApi.Dal.Repositories.Interfaces;
using CodingTermsMinimalApi.Models;
using CodingTermsMinimalApi.Services;
using CodingTermsMinimalApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ITermService, TermService>();
builder.Services.AddScoped<ITermRepo, TermRepo>();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      builder =>
//                      {
//                          builder
//                          .WithOrigins("https://localhost:7060", "http://www.contoso.com");
//                      });
//});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("https://localhost:7060")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

app.UseSwagger();

app.MapPost("/create", (Term term, [FromServices] ITermService service) => service.Create(term));
app.MapPut("/update", (Term term, [FromServices] ITermService service) => service.Update(term));
app.MapGet("/get", (int id, [FromServices] ITermService service) => service.Get(id));
app.MapPut("/delete", (int id, [FromServices] ITermService service) => service.Delete(id));
app.MapGet("/list", ([FromServices] ITermService service) => service.List());

app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins);

app.Run();
