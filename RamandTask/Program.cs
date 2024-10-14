using Application.UserFilters;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Persistence.EF.Context;
using Persistence.EF.Users;
using RamandTask.DI;
using RamandTask.Middlewares;

var builder = WebApplication.CreateBuilder(args);

SqlMapper.AddTypeHandler(new UserNameTypeHandler());
SqlMapper.AddTypeHandler(new PasswordTypeHandler());

builder.RegisterAutoFac(builder.Host);
builder.Services.AddSwagger(builder.Configuration);
// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ReportApiVersions = true;
});

builder.Services.RegisterDatabase();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUserContext, UserContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

// Other middlewares
app.UseRouting();

app.MapControllers();

app.Run();
