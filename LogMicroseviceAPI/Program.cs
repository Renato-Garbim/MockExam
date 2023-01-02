using LogMicroseviceAPI.StartupConfig;
using Microsoft.EntityFrameworkCore;
using RequestLogInfra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connection = @"Server=localhost;initial catalog=APIMockUp.AspNetCore.logRequestDB;Trusted_Connection=True;ConnectRetryCount=0; MultipleActiveResultSets=True";
//var connection = @"Server=localhost;initial catalog=HeroDB;Trusted_Connection=True;ConnectRetryCount=0";

builder.Services.AddDbContext<RequestLogContext>(options => options.UseSqlServer(connection));

builder.Services.StartRegisterServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
