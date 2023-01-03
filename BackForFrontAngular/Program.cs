using BackForFrontAngular.Message;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<IMessageProducer, MessageProducer>();

//builder.Services.AddSingleton(serviceProvider =>
//        {            
//            var uri = new Uri("amqp://guest:guest@rabbit:5672/CUSTOM_HOST");
//            return new ConnectionFactory
//            {
//                Uri = uri,
//                DispatchConsumersAsync = true
//            };
//});



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
