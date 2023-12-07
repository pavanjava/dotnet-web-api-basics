using Microsoft.Extensions.Options;
using MongoDB.Driver;
using orders.middlewares;
using orders.models;
using orders.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<AuthorizationHeaderMiddleware>();
builder.Services.Configure<OrderStoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(OrderStoreDatabaseSettings)));
builder.Services.AddSingleton<IOrderStoreDatabaseSettings>(provider =>
    provider.GetRequiredService<IOptions<OrderStoreDatabaseSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(provider =>
    new MongoClient(builder.Configuration.GetValue<string>("OrderStoreDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IOrderService, OrderService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// middleware components pipeline
app.UseHttpsRedirection();
app.UseMiddleware<AuthorizationHeaderMiddleware>();
app.UseAuthorization();
app.UseRouting();


// Routing
app.MapControllers();

app.Run();