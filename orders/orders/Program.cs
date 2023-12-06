using orders.middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<AuthorizationHeaderMiddleware>();

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