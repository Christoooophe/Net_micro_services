using OrderService.Models;
using OrderService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<OrderDatabaseSettings>(
    builder.Configuration.GetSection("OrderDatabase"));


builder.Services.AddScoped<IOrdersService, OrdersService>();


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

