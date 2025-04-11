using API_ECommerce.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddTransient<EcommerceContext, EcommerceContext>();

var app = builder.Build();

app.MapControllers();

app.Run();