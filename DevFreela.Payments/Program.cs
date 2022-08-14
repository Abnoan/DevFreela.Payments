using DevFreela.Payments.API.Consumers;
using DevFreela.Payments.API.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevFreela.Payments.API", Version = "v1" });
});

builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddHostedService<ProcessPaymentConsumer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();    
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevFreela.Payments.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
